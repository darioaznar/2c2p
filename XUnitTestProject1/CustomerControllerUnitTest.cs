

using _2C2P___Aznar;
using _2C2P___Aznar.Controllers;
using _2C2P___Aznar.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;


namespace XUnitTestProject1
{
    [TestClass]
    public class CustomerControllerUnitTest
    {

        MockRepository repository;
        CustomerController customerApi;
        IMapper mapper;

        [TestInitialize]
        public void InitializeForTests()
        {
            repository = new MockRepository();


            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();

            customerApi = new CustomerController(repository, mapper);
        }

        [TestMethod]
        public async Task GetCustomer_Should_Return_Customer1()
        {
            IActionResult actionResult = await customerApi.Get(new InquiryCriteriaDto() { CustomerID = 1 });

            Assert.IsNotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.IsNotNull(result);

            Assert.AreEqual(((CustomerDto)result.Value).customerID, 1);
        }

        [TestMethod]
        public async Task GetCustomer_Should_Customer1WithGetTwoTransactions()
        {

            IActionResult actionResult = await customerApi.Get(new InquiryCriteriaDto() { Email = "user@domain.com" });

            Assert.IsNotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.IsNotNull(result);

            Assert.AreEqual(((CustomerDto)result.Value).Transactions.Count, 2);



        }



        [TestMethod]
        public async Task GetCustomer_Should_Return_NotFound()
        {

            IActionResult actionResult = await customerApi.Get(new InquiryCriteriaDto() { CustomerID = 1342424 });

            Assert.IsNotNull(actionResult);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));



        }

    }
}
