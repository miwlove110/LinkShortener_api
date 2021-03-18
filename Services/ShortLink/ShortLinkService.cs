using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LinkShortener.Data;
using LinkShortener.DTOs.ShortLink;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinkShortener.Services.ShortLink
{
    public class ShortLinkService : ServiceBase, IShortLinkService
    {

         private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        
        private readonly IMapper _mapper;
        private readonly AppDBContext _dBContext;
        private readonly ILogger<ShortLinkService> _log;
        private readonly IHttpContextAccessor _httpContext;
        public ShortLinkService(IMapper mapper, IHttpContextAccessor httpContext, AppDBContext dBContext, ILogger<ShortLinkService> log) : base(dBContext,mapper,httpContext)
        {
             this._httpContext = httpContext;
            this._log = log;
            this._mapper = mapper;
            this._dBContext = dBContext;
        }

        public async Task<GetShortLinkDto> GenerateShortURL(string Url, DateTime? expiredDate = null)
        {
            
            var dto = new GetShortLinkDto();
           

                 //Check ExpiredDate if is null Add expiredDate 3 Month
                if (expiredDate is null)
                {
                    var nowdate = Now();
                    expiredDate = nowdate.AddDays(7);
                }

                var baseUrl = "http://ssml.cc/";
                var shortURL = CheckAndGenerateShortUrl(baseUrl);
                
                 //Add To Medel
                var shortLink = new Models.ShortLink.ShortLink();
                shortLink.LongURL = Url;
                shortLink.ShortURL = shortURL;
                shortLink.ExpiredDate = expiredDate.Value.Date;
                shortLink.CreatedById = Guid.Parse(GetUserId()) ;
                shortLink.CreatedDate = Now();

                //Save Change
                await _dBContext.ShortLinks.AddAsync(shortLink);
                await _dBContext.SaveChangesAsync();

                 //Map To Dto
                dto = _mapper.Map<GetShortLinkDto>(shortLink);

                //Return
                return  dto;

        }

        public async Task<GetShortLinkDto> GetURL(string URL)
        {
            var shortlinkDto = new GetShortLinkDto();
            var objShortLink = await _dBContext.ShortLinks.Where(x=> x.ShortURL == URL && x.ExpiredDate > Now().Date).SingleOrDefaultAsync();

            if (objShortLink != null)
            {
               shortlinkDto = _mapper.Map<GetShortLinkDto>(objShortLink);
            }

            return shortlinkDto;
        }

        private string CheckAndGenerateShortUrl(string baseUrl)
        {
             int num = 7;
              var shortURL = baseUrl;
                //GenerateShortURL
                shortURL += $"/{GenerateShortString(num)}";


            return shortURL;
        }

        private string GenerateShortString(int length)
        {
            char[] s = new char[length];
            Random rnd = new Random();
            for (int x = 0; x < length; x++)
            {
                s[x] = Alphabet[rnd.Next(Alphabet.Length)];
            }
           // Thread.Sleep(10);
            return new String(s);

        }
        
    }
}