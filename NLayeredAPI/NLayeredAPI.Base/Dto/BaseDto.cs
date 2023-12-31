﻿using System.ComponentModel.DataAnnotations;

namespace NLayeredAPI.Base.Dto
{
    public class BaseDto
    {
        public int Id { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [MaxLength(500)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}
