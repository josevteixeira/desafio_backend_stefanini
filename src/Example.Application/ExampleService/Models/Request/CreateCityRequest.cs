﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Models.Request
{
    public record CreateCityRequest
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
}
