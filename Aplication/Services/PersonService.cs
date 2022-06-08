using Aplication.DTOS;
using Aplication.DTOS.Validation;
using Aplication.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Aplication.Services.ResultService;
using Domain.Entities;
using Domain.Repositories;

namespace Aplication.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonService _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonService personRepository, IMapper mapper)
        {
            _mapper = mapper;
            _personRepository = personRepository;   
        }

        public async Task<ResultService<PersonDTO>> CreatAsync(PersonDTO personDTO)
        {

            if (personDTO == null)
                return (ResultService<PersonDTO>)ResultService.Fail<PersonDTO>("objeto deve ser informado");
           
            var result = new PersonDTOValidation().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validade", result);
            
            var person = _mapper.Map<PersonDTO>(personDTO);
            var data = await _personRepository.CreatAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));

        }

       
    }
}
