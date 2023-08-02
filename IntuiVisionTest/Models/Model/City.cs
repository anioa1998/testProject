using System;
using System.ComponentModel.DataAnnotations;
namespace IntuiVisionTest.Models.Model
{
	public class City
	{
        [Key]
        public long Id { get; set; }
		public string Name { get; set; }
        public long Population { get; set; }

	}
}

