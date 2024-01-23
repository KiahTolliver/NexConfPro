using System;
using System.ComponentModel.DataAnnotations;

namespace NextConfPro.Services.EventAPI.Models
{
	public class Event
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		[Required]
		public string Location { get; set; }
	}
}

