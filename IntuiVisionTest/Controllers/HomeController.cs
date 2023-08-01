using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntuiVisionTest.Models.Dto;
using IntuiVisionTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntuiVisionTest.Controllers
{
    //W tym rozwiązaniu zastosowana została walidacja poprzez dataannotation w modelach. Bardziej skomplikowana walidacja może wymagać
    //utworzenia specjalnego helpera np. ValidationHelper, który będzie sprawdzał niezbędne warunki i rzucał wyjątki 

    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public HomeController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet("GetByCity")]
        public ActionResult<CityDTO> GetCityByDto([FromBody]CityDTO cityDto)
        {
            return Ok(new CityDTO());
        }

        [HttpGet("GetRandom")]
        public ActionResult<CityDTO> GetCityRandom()
        {
            return Ok(new CityDTO());
        }

        [HttpGet("GetByVehicle/{vehicle}")]
        public ActionResult<List<CityDTO>> GetCityByVehicle([FromQuery]string vehicle)
        {
            return Ok(new List<CityDTO>());
        }
    }
}

