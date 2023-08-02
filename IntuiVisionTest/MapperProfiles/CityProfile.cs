using System;
using AutoMapper;
using IntuiVisionTest.Models.Dto;
using IntuiVisionTest.Models.Model;

namespace IntuiVisionTest.MapperProfiles
{
	public class CityProfile : Profile
	{
		public CityProfile()
		{
			CreateMap<CityDTO, City>()
				.ForMember(
					dest => dest.Id,
					opt => opt.MapFrom(src => src.Id)
				)
				.ForMember(
					dest => dest.Name,
					opt => opt.MapFrom(src => src.Name)
				)
				.ForMember(
					dest => dest.Population,
					opt => opt.MapFrom(src => src.Population)
				);

			CreateMap<City, CityDTO>()
				.ForMember(
					dest => dest.Id,
					opt => opt.MapFrom(src => src.Id)
				)
				.ForMember(
					dest => dest.Name,
					opt => opt.MapFrom(src => src.Name)
				)
				.ForMember(
					dest => dest.Population,
					opt => opt.MapFrom(src => src.Population)
				);
		}
	}
}

