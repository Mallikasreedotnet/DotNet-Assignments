﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Dtos
{
    public class ParentDto
    {
        public int StudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }
    }
}
