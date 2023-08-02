using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IntuiVisionTest.Models.Dto;
using IntuiVisionTest.Models.Model;
using IntuiVisionTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntuiVisionTest.Controllers
{
    //W tym rozwiązaniu zastosowana została walidacja poprzez dataannotation w modelach. Bardziej skomplikowana walidacja może wymagać
    //utworzenia specjalnego helpera np. ValidationHelper, który będzie sprawdzał niezbędne warunki i rzucał wyjątki 

    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public HomeController(ICityRepository cityRepository, IVehicleRepository vehicleRepository)
        {
            _cityRepository = cityRepository;
            _vehicleRepository = vehicleRepository;
        }

        //W założeniach należałoby wyszczególnić czy mogą być zwracane puste listy, czy raczej jeżeli pusta lista => NotFound();

        [HttpGet("GetByCity")] //Raczej to powinien być post żeby obsłużyć fromBody CityDTO. Do query ciężko wrzucić cały model (wedle założeń)
        public ActionResult<CityDTO> GetCityByDto([FromBody]CityDTO cityDto)
        {
            if(ModelState.IsValid)
            {
                var result = _cityRepository.GetCityByCityDraft(cityDto);
                _vehicleRepository.GetVehiclesToCityDtos(new List<CityDTO>() { result });

                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetRandom")]
        public ActionResult<CityDTO> GetCityRandom()
        {
            var result = _cityRepository.GetRandomCity();
            _vehicleRepository.GetVehiclesToCityDtos(new List<CityDTO>() { result });

            return Ok(result);
        }

        [HttpGet("GetByVehicle/{vehicle}")]
        public ActionResult<List<CityDTO>> GetCityByVehicle(string vehicle) //Może lepiej enum żeby nie było ryzyka case sensitive itd.
        {
            var result = _cityRepository.GetCitiesByVehicle(vehicle);
            _vehicleRepository.GetVehiclesToCityDtos(result);
            return Ok(result);
        }

        [HttpPost("CreateCity")]
        public ActionResult CreateCity([FromBody] CityDTO cityDTO)
        {
            if (ModelState.IsValid)
            {
                var result = _cityRepository.CreateNewCity(cityDTO);

                if (result) return StatusCode(201); //Gdyby były widoki to zwracane byłoby Uri w metodzie Created() do odpowiedniego widoku

            }
            return BadRequest();
        }
    }
}

