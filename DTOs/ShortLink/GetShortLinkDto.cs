using System;

namespace LinkShortener.DTOs.ShortLink
{
    public class GetShortLinkDto
    {
         public string ShortURL { get; set; }
        //public string LongURL { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}