﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.UI.Models.Dtos.Person
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expiredate { get; set; }
        public Roles Role { get; set; }
    }
}