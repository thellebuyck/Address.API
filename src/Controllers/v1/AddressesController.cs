using Address.API.Application.Business.Commands;
using Address.API.Application.Business.Queries;
using Address.API.Application.Business.Views;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Address.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AddressesController : ApiController
    {
        // GET: api/<AddressesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllAddressesQuery();
            var response = await Mediator.Send(query);

            return Ok(response);
        }


        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAddressCommand command)
        {
            if (command == null)
            {
                return UnprocessableEntity("Unable to process this request");
            }
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
