using CodeBridgeTestTask.API.Controllers;
using CodeBridgeTestTask.Core.Entities;
using CodeBridgeTestTask.DAL.Helpers;
using CodeBridgeTestTask.Infrastructure.Data.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeBridgeTestTask.Tests
{
    public class DogsControllerTest
    {
        #region Property  
        public Mock<IDogsRepository> mock = new Mock<IDogsRepository>();
        #endregion

        public DogsControllerTest()
        {
            IList<Dog> dogs = new List<Dog>()
            {
                new Dog("Neo", "red & amber", 22, 32),
                new Dog("Jessy", "black & white", 7, 14)
            };
            PagedList<Dog> pl = new PagedList<Dog>(dogs.ToList(), dogs.Count, 1, dogs.Count);

            mock.Setup(rep => rep.GetDogsAsync(null, null))
                .ReturnsAsync(pl);
            mock.Setup(rep => rep.AddDogAsync(It.IsAny<Dog>()))
               .Callback((Dog dog) =>
               {
                   dog.Id = dogs.Count + 1;
                   dogs.Add(dog);
               });
            mock.SetupAllProperties();
        }

        [Fact]
        public async void GetDogs_ShouldReturnDogs()
        {
            DogsController controller = new DogsController(mock.Object);
            var result = await controller.GetAllAsync(null, null);
            Assert.NotNull(result);
        }

        [Fact]
        public async void AddDog_ShouldCreateANewDog_ReturnsCreated_Dog()
        {
            DogsController controller = new DogsController(mock.Object);
            var result = await controller.CreateAsync(new Dog("Lucky", "red", 12, 17));
            Assert.NotNull(result);
        }
    }
}