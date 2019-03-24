using AutoMapper;
using FestivalApp.API.DTO;
using FestivalApp.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FestivalApp.API.Controllers
{
    [RoutePrefix("api")]
    public class FestivalController : ApiController
    {
        private FestivalService festivalService;

        public FestivalController()
        {
            festivalService = new FestivalService();
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
                    return Ok("Festival type succesfully created");
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
                    return Ok("Festival type succesfully updated.");
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
        [Route("festivals")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var festival = festivalService.Get(id);
                if (festival == null)
                    return NotFound();

                festivalService.Delete(id);
                return Ok("Festival type succesfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }
        }
    }
}
