﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBridgeTestTask.Core.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Color { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "tail_length")]
        public int TailLength { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Weight { get; set; }
    }
}