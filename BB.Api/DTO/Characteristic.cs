﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public class Characteristic
    {
        public Guid CharacteristicId { get; set; }

        public string Name { get; set; }

        public List<string> Options { get; set; }
    }
}