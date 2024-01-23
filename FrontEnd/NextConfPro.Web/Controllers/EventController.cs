using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NextConfPro.Web.Models;
using NextConfPro.Web.Service.IService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NextConfPro.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> EventIndex()
        {
            List<EventDto>? list = new();

            ResponseDto? response = await _eventService.GetAllEventsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EventDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> EventCreate()
        {
            return View();
        }
    }
}

