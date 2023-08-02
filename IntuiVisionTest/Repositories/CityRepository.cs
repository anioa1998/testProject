using System;
using AutoMapper;
using IntuiVisionTest.Models;
using IntuiVisionTest.Models.Dto;
using IntuiVisionTest.Models.Model;
using IntuiVisionTest.Repositories.Interfaces;

namespace IntuiVisionTest.Repositories
{
    public class CityRepository : ICityRepository
	{
        protected readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public CityRepository(AppDbContext dbContext, IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        //W normalnych warunkach zapisywanie wykonywałoby się z wykorzystaniem UnitOfWork gdyby było więcej tabel
        //Byłby odpowiedni walidator gdyby pozycji i warunków było więcej
        //Gdyby aplikacja miała więcej serwisów i zadań warto byłoby rozważyć zastosowanie CQRS i Mediator, obsługę poprzez asynchroniczne taski
       
        public bool CreateNewCity(CityDTO city)
        {
            
            try
            {
                _dbContext.Cities.Add(_mapper.Map<City>(city));
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CityDTO GetCityByCityDraft(CityDTO cityDto)
        {
            if (cityDto.Id.HasValue)
            {
                return _mapper.Map<CityDTO>(_dbContext.Cities.Single(x => x.Id == cityDto.Id.Value));
            }

            return _mapper.Map<CityDTO>(_dbContext.Cities.Single(x => x.Name == cityDto.Name &&
                                                 x.Population == cityDto.Population));

        }

        //Tutaj to powinno być lepiej rozwiązane, w szczególności gdyby była relacja w bazie byłoby prościej dograć to za pomocą Join/Include

        public List<CityDTO> GetCitiesByVehicle(string vehicle)
        {
            var idVehicleDict = new Dictionary<long, string>();

            var idPopulationDict = _dbContext.Cities.ToDictionary(x => x.Id, y => y.Population);

            foreach(var idPopulation in idPopulationDict)
            {
                var vehicleName = _vehicleRepository.GetVehicleToPopulation(idPopulation.Value);
                idVehicleDict.Add(idPopulation.Key, vehicleName ?? string.Empty);
            }

            var cityIds = idVehicleDict.Where(x => x.Value == vehicle).Select(x => x.Key).ToList();

            var cities = _dbContext.Cities.Where(x => cityIds.Contains(x.Id)).ToList();

            return _mapper.Map<List<CityDTO>>(cities);
        }

        public CityDTO GetRandomCity()
        {
            var random = new Random();

            var ids = _dbContext.Cities.Select(x => x.Id).ToList();
            var index = random.Next(ids.Count());

            var city = _dbContext.Cities.Find(ids[index]);

            return _mapper.Map<CityDTO>(city);
        }

    }
}

