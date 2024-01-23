using System;
using AutoMapper;
using NextConfPro.Services.EventAPI.Models;
using NextConfPro.Services.EventAPI.Models.Dto;

namespace NextConfPro.Services.EventAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<EventDto, Event>();
				config.CreateMap<Event, EventDto>();
			});

			return mappingConfig;
		}
	}
}

