using System;
using System.Collections;
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

        [HttpPost]
        public async Task<IActionResult> EventCreate(EventDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _eventService.CreateEventAsync(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(EventIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> EventDelete(int id)
        {
            ResponseDto? response = await _eventService.GetEventByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<EventDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EventDelete(EventDto eventDto)
        {
            ResponseDto? response = await _eventService.DeleteEventAsync(eventDto.Id);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(EventIndex));
            }
            return View(eventDto);
        }
    }
}

