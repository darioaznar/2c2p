using _2C2P___Aznar.Models;
using _2C2P___Aznar.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace _2C2P___Aznar.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        private readonly IMapper _mapper;
        public ICustomerRepository CustomerRepository { get; set; }


        public CustomerController(ICustomerRepository repo, IMapper mapper)
        {
            CustomerRepository = repo;
            _mapper = mapper;
        }



        /// <summary>
        /// InquiryCriteria passes in post inside body
        /// </summary>
        /// <param name="inquiryCriteria"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)System.Net.HttpStatusCode.OK)]


        public async Task<IActionResult> Get([FromBodyAttribute][Required(AllowEmptyStrings = false)] InquiryCriteriaDto inquiryCriteria)
        {
            if (ModelState.IsValid)
            {
                if (inquiryCriteria != null)
                {
                    if (inquiryCriteria.CustomerID.HasValue)
                    {
                        var item = await CustomerRepository.Find(inquiryCriteria.CustomerID.Value);
                        if (item == null)
                        {
                            return NotFound();
                        }
                        return Ok(_mapper.Map<CustomerDto>(item));
                    }
                    else
                    {
                        var item = await CustomerRepository.FindByEmail(inquiryCriteria.Email);
                        return GenerateItemResponse(item);
                    }


                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        private IActionResult GenerateItemResponse(Customer item)
        {
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDto>(item));
        }
    }
}
