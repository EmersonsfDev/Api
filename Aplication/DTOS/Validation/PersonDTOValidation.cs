using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Aplication.DTOS.Validation
{
    public class PersonDTOValidation : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Nome deve ser inserido");
            RuleFor(x=> x.Document).NotEmpty().NotNull().WithMessage("documento deve ser inserido");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("telefone deve ser inserido");
        }


    }

  
}
