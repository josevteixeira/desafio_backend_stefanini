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

        public static City Create(string name, string state)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid " + nameof(name));

            if (string.IsNullOrEmpty(state) || state.Length > 2)
                throw new ArgumentException("Invalid " + nameof(state));

            return new City(name, state);
        }

        public void Update(string name, string state)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;

            if (!string.IsNullOrEmpty(state))
                State = state;
        }
    }
}
