using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.ExampleAggregate
{
    public sealed class City
    {
        private City(string name, string state)
        {
            this.Name = name;
            this.State = state;;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }
    }
}
