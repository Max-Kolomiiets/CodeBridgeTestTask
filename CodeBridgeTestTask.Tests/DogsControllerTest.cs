using CodeBridgeTestTask.API.Controllers;
using CodeBridgeTestTask.Core.Entities;
using CodeBridgeTestTask.DAL.Helpers;
using CodeBridgeTestTask.Infrastructure.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
        }

        [Fact]
        public async void GetDogs_ShouldReturnDogs()
        {
            IList<Dog> dogs = new List<Dog>()
            {
                new Dog("Neo", "red & amber", 22, 32),
                new Dog("Jessy", "black & white", 7, 14)
            };
            PagedList<Dog> pl = new PagedList<Dog>(dogs.ToList(), dogs.Count, 1, dogs.Count);

            mock.Setup(rep => rep.GetDogsAsync(null, null))
                .ReturnsAsync(pl);

            DogsController controller = new DogsController(mock.Object);

            var result = await controller.GetAllAsync(null, null);

            Assert.NotNull(result);
        }
    }
}