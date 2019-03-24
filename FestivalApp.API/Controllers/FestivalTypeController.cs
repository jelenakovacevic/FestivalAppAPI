using AutoMapper;
using FestivalApp.API.DTO;
using FestivalApp.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FestivalApp.API.Controllers
{
    [RoutePrefix("api")]
    public class FestivalTypeController : ApiController
    {
        private FestivalTypeService festivalTypeService;

        public FestivalTypeController()
        {
            festivalTypeService = new FestivalTypeService();    
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
