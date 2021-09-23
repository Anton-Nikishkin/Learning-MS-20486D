﻿using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }

        [Display(Name = "Common Name:")]
        public string CommonName { get; set; }

        [Display(Name = "Butterfly Family:")]
        public Family? ButterflyFamily { get; set; }

        [Display(Name = "Butterflies Quantity:")]
        public int? Quantity { get; set; }

        [Display(Name = "Characteristics:")]
        public string Characteristics { get; set; }

        [Display(Name = "Updated on:")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Butterflies Picture:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }
    }
}
