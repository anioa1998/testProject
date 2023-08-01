using System;
using IntuiVisionTest.Models;
using IntuiVisionTest.Repositories.Interfaces;

namespace IntuiVisionTest.Repositories
{
	public class CityRepository : ICityRepository
	{
        protected readonly AppDbContext _dbContext;
		public CityRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}

