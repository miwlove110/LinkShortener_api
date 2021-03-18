using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkShortener.Models.ShortLink
{
    
    [Table("ShortLink", Schema = "shortLink")]
    public class ShortLink
    {
        [Key]
        public int Id { get; set; }
        public string ShortURL { get; set; }
        public string LongURL { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? UpdatedById { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}