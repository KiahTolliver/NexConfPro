using System;
using NextConfPro.Web.Models;
using NextConfPro.Web.Service.IService;
using NextConfPro.Web.Utility;
namespace NextConfPro.Web.Service
{
	public class EventService: IEventService
	{
		private IBaseService _baseService;
		public EventService(IBaseService baseService)
		{
			_baseService = baseService;
		}

        public async Task<ResponseDto?> CreateEventAsync(EventDto eventDto)
        {
            return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = eventDto,
				Url = SD.EventAPIBase + "/api/event/"
			});
        }

        public async Task<ResponseDto?> DeleteEventAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.EventAPIBase + "/api/event/" + id
			});
		}

		public async Task<ResponseDto?> GetAllEventsAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.EventAPIBase + "/api/event/"
			});
		}

		public async Task<ResponseDto?> GetEventByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.EventAPIBase + "/api/event/" + id
			});
		}

		public async Task<ResponseDto?> UpdateEventAsync(EventDto eventDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = eventDto,
				Url = SD.EventAPIBase + "/api/event/"
			});
		}
	}
			
}

