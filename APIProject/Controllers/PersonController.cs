using Aplication.DTOS;
using Aplication.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreatAsync(personDTO);
            
            if(result.IsSucess)
             return  Ok(result);
            return BadRequest(result);
        }
    }
}
