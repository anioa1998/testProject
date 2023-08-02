using System;
using IntuiVisionTest.Models.Dto;

namespace IntuiVisionTest.Repositories.Interfaces
{
	public interface IVehicleRepository
	{
		void GetVehiclesToCityDtos(List<CityDTO> cityDtos);

		string? GetVehicleToPopulation(long population);
	}
}

