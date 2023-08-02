using System;
using IntuiVisionTest.Models;
using IntuiVisionTest.Models.Dto;
using IntuiVisionTest.Repositories.Interfaces;

namespace IntuiVisionTest.Repositories
{
	public class VehicleRepository : IVehicleRepository
	{
        protected readonly AppDbContext _dbContext;
        public VehicleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GetVehiclesToCityDtos(List<CityDTO> cityDtos)
        {
            //Tutaj warto by przemyśleć aktualne corner cases, bo gdyby nie było środku transportu dla danej populacji to warto by to zakomunikować/dodać
            foreach(var cityDto in cityDtos)
            {
                var vehicleType = _dbContext.Vehicles.SingleOrDefault(x => x.MinPopulation <= cityDto.Population && x.MaxPopulation >= cityDto.Population);
                cityDto.CommonVehicle = vehicleType.Name;
            }
        }

        public string? GetVehicleToPopulation(long population)
        {
            return _dbContext.Vehicles.Where(x => x.MinPopulation <= population && x.MaxPopulation >= population)
                                      .Select(x => x.Name)
                                      .SingleOrDefault();
        }
    }

}

