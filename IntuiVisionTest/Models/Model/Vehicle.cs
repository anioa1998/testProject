using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IntuiVisionTest.Models.Model
{
	public class Vehicle
	{
		//Docelowo dodanie Id ułatwiłoby tworzenie powiązań w bazie i przechowywanie informacji o pojeździe.
		//Jeżeli zmieniałaby się populacja miasta (a takie badania nie są zbyt często, więc potencjalnie nie obciążałoby to bazy w kwestii wydajności)
		//to utrzymanie Id pojazdu "up-to-date" w tabeli mogłoby odbywać się za pomocą triggera na tabeli Cities wywoływanego przez zmianę
		[Required]
		public long MinPopulation { get; set; }

		[Required]
		public long MaxPopulation { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}

