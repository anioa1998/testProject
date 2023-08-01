using System;
using System.ComponentModel.DataAnnotations;

namespace IntuiVisionTest.Models.Dto
{
	public class CityDTO
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
		public long Population { get; set; }
		public string CommonVehicle { get; set; }
	}
}

