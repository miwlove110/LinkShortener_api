using System;
using LinkShortener.Services.ShortLink;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShortLinkController : ControllerBase
    {
        private readonly IShortLinkService _shortLinkService;

        public ShortLinkController(IShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;

        }


        // [Authorize]
        // public IActionResult Get()
        // {
        //     return Ok();
        // }

        [Authorize]
        [HttpPost("/GenerateLinkShorten")]
        public IActionResult GenerateShortURL( string Url, DateTime? expiredDate = null)
        {
            return Ok(_shortLinkService.GenerateShortURL(Url,expiredDate).Result);
        }


        // [HttpGet("/GetURL")]
        // public IActionResult GetURL(string shortURL)
        // {
        //     var objShortLink = _shortLinkService.GetURL(shortURL).Result;

        //     if (objShortLink.ShortURL is null)
        //     {
        //         return NotFound();
        //     }else{
        //         return Ok(objShortLink);
        //     }
        // }

    }
}