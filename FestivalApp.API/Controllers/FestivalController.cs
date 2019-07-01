using AutoMapper;
using FestivalApp.API.DTO;
using FestivalApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;

namespace FestivalApp.API.Controllers
{
    [RoutePrefix("api")]
    public class FestivalController : ApiController
    {
        private FestivalService festivalService;
        private UserService userService;

        public FestivalController()
        {
            festivalService = new FestivalService();
            userService = new UserService();
        }

        [HttpGet]
        [Route("festivals")]
        public IHttpActionResult GetAll()
        {
            var festivals = festivalService.GetAll();
            var festivalsDTO = Mapper.Map<IEnumerable<Festival>, IEnumerable<FestivalDTO>>(festivals);
            return Ok(festivalsDTO);
        }

        [HttpGet]
        [Route("festivals/festival-type/{id:int}")]
        public IHttpActionResult GetAllFromFestivalType(int id)
        {
            var festivals = festivalService.GetAll();
            var festivalsFromType = festivals.Where(x => x.FestivalTypeId == id);
            var festivalsDTO = Mapper.Map<IEnumerable<Festival>, IEnumerable<FestivalDTO>>(festivalsFromType);
            return Ok(festivalsDTO);
        }

        [HttpGet]
        [Route("festivals/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var festival = festivalService.Get(id);
            if (festival == null)
                return NotFound();

            var festivalDTO = Mapper.Map<Festival, FestivalDTO>(festival);
            return Ok(festivalDTO);
        }

        [HttpPost]
        [Route("festivals")]
        public IHttpActionResult Create(FestivalDTO festivalDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var festival = Mapper.Map<FestivalDTO, Festival>(festivalDTO);
                    festivalService.Create(festival);
                    return Ok("Festival succesfully created");
                }
                catch (Exception ex)
                {
                    return BadRequest("Something went wrong.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("festivals/attend")]
        public IHttpActionResult Attend(AttendDTO attendDTO)
        {
            try
            {
                var user = userService.GetByUsername(attendDTO.Username);
                var festival = festivalService.Get(attendDTO.Id);
                if (festival == null || user == null)
                    return NotFound();

                festivalService.Attend(user.Id, festival.Id);
                return Ok("You are now attending this festival.");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("You are already attending this festival.");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpPut]
        [Route("festivals/rate")]
        public IHttpActionResult Rate(float rate, int festivalId, string username)
        {
            try
            {
                var user = userService.GetByUsername(username);
                var festival = festivalService.Get(festivalId);
                if (festival == null || user == null)
                    return NotFound();

                festivalService.Rate(rate, festivalId, username);
                return Ok("You have successfully rated this festival.");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("You have already rated this festival.");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }

        [HttpPut]
        [Route("festivals")]
        public IHttpActionResult Update(FestivalDTO festivalDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var festival = Mapper.Map<FestivalDTO, Festival>(festivalDTO);
                    festivalService.Update(festival);
                    return Ok("Festival succesfully updated.");
                }
                catch (Exception ex)
                {
                    return BadRequest("Something went wrong.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("festivals/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var festival = festivalService.Get(id);
                if (festival == null)
                    return NotFound();

                festivalService.Delete(id);
                return Ok("Festival succesfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest("Could not delete festival.");
            }
        }
    }
}
