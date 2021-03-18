using System;
using System.Threading.Tasks;
using LinkShortener.DTOs.ShortLink;

namespace LinkShortener.Services.ShortLink
{
    public interface IShortLinkService
    {
         Task<GetShortLinkDto> GenerateShortURL(string Url,DateTime? expiredDate = null);

         Task<GetShortLinkDto> GetURL(string URL);
    }
}