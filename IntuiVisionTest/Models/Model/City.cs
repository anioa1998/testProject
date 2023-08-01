using System;
using System.ComponentModel.DataAnnotations;
namespace IntuiVisionTest.Models.Model
{
	public class City
	{
        [Key]
        public long Id { get; set; }

		[Required]
		[MaxLength(187)] //Najdłuższa nazwa miasta, ceremonijna nazwa Bangkoku
		public string Name { get; set; }

		[Required]
		public long Population { get; set; }

	}
}

