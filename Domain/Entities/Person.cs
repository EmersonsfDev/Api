using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Person
    {
        public int Id { get;private set; }
        public string Name { get;private set; }
        public string Document { get;private set; }
        public string Phone { get;private set; }
        public ICollection<Purchase> Purchases { get; set; }
 

        public Person(string name, string document, string phone )
        {
            Validation( name,  document,  phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationExeption.When(id < 0, "id deve ser maior que zero");
            Id = id;    
            Validation( name, document, phone); 
        }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationExeption.When(string.IsNullOrEmpty(name), "nome deve ser informado");
            DomainValidationExeption.When(string.IsNullOrEmpty(document), "documento de ser informado");
            DomainValidationExeption.When(string.IsNullOrEmpty(phone), "phone deve ser informado");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
