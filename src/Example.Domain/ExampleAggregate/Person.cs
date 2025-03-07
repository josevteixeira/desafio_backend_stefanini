﻿namespace Example.Domain.ExampleAggregate
{
    public sealed class Person
    {
        private Person(string name, int age, string document, int cityId)
        {
            this.Name = name;
            this.Age = age;
            this.Document = document;
            this.CityId = cityId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Document { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public static Person Create(string name, int age, string document, int cityId)
        {
            if (string.IsNullOrEmpty(name)) 
                throw new ArgumentException("Invalid " + nameof(name));

            if (age == 0)
                throw new ArgumentException("Invalid " + nameof(age));

            if (string.IsNullOrEmpty(document) || document.Length != 11)
                throw new ArgumentException("Invalid " + nameof(document));

            if (cityId == 0)
                throw new ArgumentException("Invalid " + nameof(cityId));

            return new Person(name, age, document, cityId);
        }

        public void Update(string name, int age, string document)
        {
            if (!string.IsNullOrEmpty(name)) 
                Name = name;

            if (age > 50)
                throw new InvalidAgeExceptions();

            if (age != 0)
                Age = age;

            if (string.IsNullOrEmpty(document) || document.Length != 11)
                throw new ArgumentException("Invalid " + nameof(document));
        }
    }
}
