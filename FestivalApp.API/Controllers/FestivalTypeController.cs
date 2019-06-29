using AutoMapper;
using FestivalApp.API.DTO;
using FestivalApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;

namespace FestivalApp.API.Controllers
{
    [RoutePrefix("api")]
    public class FestivalTypeController : ApiController
    {
        private FestivalTypeService festivalTypeService;
        private UserService userService;

        public FestivalTypeController()
        {
            festivalTypeService = new FestivalTypeService();
            userService = new UserService();
        }

        [HttpGet]
        [Route("festival-types")]
        public IHttpActionResult GetAll()
        {
            var festivalTypes = festivalTypeService.GetAll();
            var festivalTypesDTO = Mapper.Map<IEnumerable<FestivalType>, IEnumerable<FestivalTypeDTO>>(festivalTypes);
            return Ok(festivalTypesDTO);
        }

        [HttpGet]
        [Route("festival-types/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var festivalType = festivalTypeService.Get(id);
            if (festivalType == null)
                return NotFound();

            var festivalTypeDTO = Mapper.Map<FestivalType, FestivalTypeDTO>(festivalType);
            return Ok(festivalTypeDTO);
        }

        [HttpGet]
        [Route("festival-types/favorites")]
        public IHttpActionResult GetFavorites(string username)
        {
            try
            {
                var festivalTypes = festivalTypeService.GetFavorites(username);
                var festivalTypesDTO = Mapper.Map<IEnumerable<FestivalType>, IEnumerable<FestivalTypeDTO>>(festivalTypes);

                return Ok(festivalTypesDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception");
            }
        }

        [HttpPost]
        [Route("festival-types")]
        public IHttpActionResult Create(FestivalTypeDTO festivalTypeDTO)
        {
            try
            {
                var festivalType = Mapper.Map<FestivalTypeDTO, FestivalType>(festivalTypeDTO);
                festivalTypeService.Create(festivalType);
                return Ok("Festival type succesfully created");
            }
            catch (Exception ex)
            {
                return BadRequest("Exception");
            }
        }

        [HttpPost]
        [Route("festival-types/add-favorite")]
        public IHttpActionResult AddToFavorites(UserFestivalTypeDTO userFestivalTypeDto)
        {
            try
            {
                var user = userService.GetByUsername(userFestivalTypeDto.Username);
                festivalTypeService.AddToFavorites(user.Id, userFestivalTypeDto.Id);

                return Ok("Festival type added to favorites.");
            }
            catch(DbUpdateException ex)
            {
                return BadRequest("Festival type is already in favorites.");
            }
            catch (Exception ex)
            {
                return BadRequest("Exception");
            }
        }

        [HttpPost]
        [Route("festival-types/delete-favorite")]
        public IHttpActionResult RemoveFromFavorite(UserFestivalTypeDTO userFestivalTypeDto)
        {
            try
            {
                var user = userService.GetByUsername(userFestivalTypeDto.Username);
                festivalTypeService.RemoveFromFavorites(user.Id, userFestivalTypeDto.Id);

                return Ok("Festival type removed from favorites.");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Festival type is not in favorites.");
            }
            catch (Exception ex)
            {
                return BadRequest("Exception");
            }
        }

        [HttpDelete]
        [Route("festival-types")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var festivalType = festivalTypeService.Get(id);
                if (festivalType == null)
                    return NotFound();

                festivalTypeService.Delete(id);
                return Ok("Festival type succesfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest("Exception");
            }
        }
    }
}
