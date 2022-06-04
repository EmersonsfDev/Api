using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductID { get;private set; }
        public int PersonID { get;private set;}
        public DateTime Date { get; set; }

        public Product Product { get; private set; }    
        public Person Person { get; private set; }


        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id,int productId, int personId, DateTime? date)
        {
            DomainValidationExeption.When(id < 0, "ID  deve ser informado");
            Id = id;
            Validation(productId, personId, date);
        }

        private void Validation(int productID, int personID, DateTime? date)
        {
            DomainValidationExeption.When(productID < 0, "ID  produto deve ser informado");
            DomainValidationExeption.When(personID < 0, "ID  pessoa deve ser informado");

            ProductID = productID;
            PersonID = personID;
            Date = date.Value;
        
        }


    }
}
