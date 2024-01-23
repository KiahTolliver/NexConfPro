using System;
namespace NextConfPro.Services.EventAPI.Models.Dto
{
	public class EventDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
    }
}

