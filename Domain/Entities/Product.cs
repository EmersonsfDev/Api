using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Product
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodeERP { get; private set; }
        public Decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get;  set; }
        public object Purchase { get; set; }


        public Product(string name,string codeErp, decimal price)
        {
            Validation(name, codeErp, price);   
        }

        public Product(int id, string name, string codeErp, decimal price)
        {
            DomainValidationExeption.When(id < 0, "id deve ser informado");
            Id = id;
            Validation(name, codeErp, price);   
        }

        private void Validation(string name, string codeErp, decimal price)
        {
            DomainValidationExeption.When(string.IsNullOrEmpty(name), "nome deve ser informado");
            Name = name;
            CodeERP = codeErp;
            Price = price;
        }


    }


}
