using System;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using NextConfPro.Web.Models;
using static NextConfPro.Web.Utility.SD;
namespace NextConfPro.Web.Service
{
	public class BaseService: IBaseService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BaseService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            var client = _httpClientFactory.CreateClient("EventAPI");
			var message = new HttpRequestMessage();
			message.Headers.Add("Accept", "application/json");
			//token
			message.RequestUri = new Uri(requestDto.Url);

			if (requestDto.Data != null)
			{
				message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
			}

			var apiResponse = null as HttpResponseMessage;

			switch (requestDto.ApiType)
			{
				case ApiType.POST:
					message.Method = HttpMethod.Post;
					break;
				case ApiType.PUT:
					message.Method = HttpMethod.Put;
					break;
				case ApiType.DELETE:
					message.Method = HttpMethod.Delete;
					break;
				default:
					message.Method = HttpMethod.Get;
					break;
			}

			apiResponse = await client.SendAsync(message);
			try
			{
				switch (apiResponse.StatusCode)
				{
					case HttpStatusCode.NotFound:
						return new(){IsSuccess = false, Message = "Not Found"};
					case HttpStatusCode.Unauthorized:
						return new() { IsSuccess = false, Message = "Unauthorized" };
					case HttpStatusCode.Forbidden:
						return new() { IsSuccess = false, Message = "Forbidden" };
					case HttpStatusCode.InternalServerError:
						return new() { IsSuccess = false, Message = "Internal Server Error" };
					default: 
						var apiContent = await apiResponse.Content.ReadAsStringAsync();
						var responseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
						return responseDto;
				}
			}
			catch (Exception ex)
			{
				var dto = new ResponseDto
				{
					IsSuccess = false,
					Message = ex.Message.ToString()
				};
				return dto;
			}
        }
    }
}

