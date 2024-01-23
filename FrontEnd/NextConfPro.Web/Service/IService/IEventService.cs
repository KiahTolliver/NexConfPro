using System;
using NextConfPro.Web.Models;
namespace NextConfPro.Web.Service.IService
{
	public interface IEventService
	{
		Task<ResponseDto?> GetAllEventsAsync();
		Task<ResponseDto?> GetEventByIdAsync(int id);
		Task<ResponseDto?> CreateEventAsync(EventDto eventDto);
		Task<ResponseDto?> UpdateEventAsync(EventDto eventDto);
		Task<ResponseDto?> DeleteEventAsync(int id);

	}
}

