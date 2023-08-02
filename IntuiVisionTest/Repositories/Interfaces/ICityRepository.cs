using System;
using IntuiVisionTest.Models.Dto;
using IntuiVisionTest.Models.Model;

namespace IntuiVisionTest.Repositories.Interfaces
{
	public interface ICityRepository
	{
		CityDTO GetCityByCityDraft(CityDTO city);

		CityDTO GetRandomCity();

		List<CityDTO> GetCitiesByVehicle(string vehicle);

		bool CreateNewCity(CityDTO city);
	}
}

