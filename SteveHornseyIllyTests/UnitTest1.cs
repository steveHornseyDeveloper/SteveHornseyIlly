using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteveHornseyIlly.Model;
using SteveHornseyIlly.Repository;

namespace SteveHornseyIllyTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPeopleDifferentName()
        {
            var person1 = new Person
            {
                Name = "Steve",
                DateOfBirth = new DateTime(1990, 09, 01),
                FavouriteColor = "Blue",
                CarOwned = "Jaguar",
                NumberOfPets = 5
            };
            var person2 = new Person
            {
                Name = "John",
                DateOfBirth = new DateTime(1990, 09, 01),
                FavouriteColor = "Blue",
                CarOwned = "Jaguar",
                NumberOfPets = 5
            };

            var objectComparer = new ObjectComparer();
            var output = objectComparer.CompareObject(person1, person2);

            Assert.IsTrue(output.Count == 1);
            Assert.IsTrue(output.Exists(x => x.PropertyName == "Name"));
        }

        [TestMethod]
        public void TestPeopleSameObject()
        {
            var person1 = new Person
            {
                Name = "Steve",
                DateOfBirth = new DateTime(1990, 09, 01),
                FavouriteColor = "Blue",
                CarOwned = "Jaguar",
                NumberOfPets = 5
            };
            var person2 = new Person
            {
                Name = "Steve",
                DateOfBirth = new DateTime(1990, 09, 01),
                FavouriteColor = "Blue",
                CarOwned = "Jaguar",
                NumberOfPets = 5
            };

            var objectComparer = new ObjectComparer();
            var output = objectComparer.CompareObject(person1, person2);

            Assert.IsTrue(output.Count == 0);
        }

        [TestMethod]
        public void TestPeopleSameReference()
        {

            var person1 = new Person
            {
                Name = "Steve",
                DateOfBirth = new DateTime(1990, 09, 01),
                FavouriteColor = "Blue",
                CarOwned = "Jaguar",
                NumberOfPets = 5
            };
            var person2 = new Person
            {
                Name = "John",
                DateOfBirth = new DateTime(1990, 09, 01),
                FavouriteColor = "Blue",
                CarOwned = "Jaguar",
                NumberOfPets = 5
            };

            var objectComparer = new ObjectComparer();
            var output = objectComparer.CompareObject(person1, person2);

            Assert.IsTrue(output.Count == 1);
        }
        [TestMethod]
        public void TestCarDifferences()
        {
            var car1 = new Car
            {
                Name = "Marco the Polo",
                Colour = "Red",
                NumberOfWheels = 4,
                RegistrationNumber = "A42 1CD"
            };
            var car2 = new Car
            {
                Name = "Robin the unreliant",
                Colour = "Blue",
                NumberOfWheels = 3,
                RegistrationNumber = "A41 1CD"
            };

            var objectComparer = new ObjectComparer();
            var output = objectComparer.CompareObject(car1, car2);

            Assert.IsTrue(output.Count == 4);
            Assert.IsTrue(output.Exists(x => x.PropertyName == "Name"));
            Assert.IsTrue(output.Exists(x => x.PropertyName == "Colour"));
            Assert.IsTrue(output.Exists(x => x.PropertyName == "Number Of Wheels"));
            Assert.IsTrue(output.Exists(x => x.PropertyName == "Registration Number"));
        }
    }
}
