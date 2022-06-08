using Aplication.DTOS;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Maping
{
    public class DTOToDomainMap :Profile
    {
        public DTOToDomainMap()
        {
            CreateMap<PersonDTO, Person>();
        }        
    }
}
