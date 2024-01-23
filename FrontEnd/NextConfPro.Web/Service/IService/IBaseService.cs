using System;
using NextConfPro.Web.Models;
namespace NextConfPro.Web.Service
{
	public interface IBaseService
	{
		Task<ResponseDto?>SendAsync(RequestDto requestDto);
	}
}

