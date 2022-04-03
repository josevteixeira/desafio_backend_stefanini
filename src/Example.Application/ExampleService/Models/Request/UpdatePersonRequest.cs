using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Models.Request
{
    public record UpdatePersonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
    }
}
