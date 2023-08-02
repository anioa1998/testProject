using System;
using System.ComponentModel.DataAnnotations;

namespace IntuiVisionTest.Models.Dto
{
	public class CityDTO
	{ 
		public long? Id { get; set; }

		[Required]
		[MaxLength(187)] //Najdłuższa nazwa miasta, ceremonijna nazwa Bangkoku
        public string Name { get; set; }

		[Required]
        [Range(0, 40000000, ErrorMessage = "There's no larger city in the world than 40 M for now")]
        public long Population { get; set; }

		[MaxLength(50)]
		public string? CommonVehicle { get; set; }
	}
}

