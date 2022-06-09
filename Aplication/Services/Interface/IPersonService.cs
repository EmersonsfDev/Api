using Aplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Aplication.Services.PersonService;


namespace Aplication.Services.Interface
{
    public interface IPersonService
    {
         Task<ResultService<PersonDTO>> CreatAsync(PersonDTO personDTO);
    }
}
