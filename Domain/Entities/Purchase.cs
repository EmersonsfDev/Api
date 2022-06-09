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

        public Product Product { get;  set; }    
        public Person Person { get;  set; }


        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        public Purchase(int id,int productId, int personId)
        {
            DomainValidationExeption.When(id < 0, "ID  deve ser informado");
            Id = id;
            Validation(productId, personId);
        }

        private void Validation(int productID, int personID)
        {
            DomainValidationExeption.When(productID < 0, "ID  produto deve ser informado");
            DomainValidationExeption.When(personID < 0, "ID  pessoa deve ser informado");

            ProductID = productID;
            PersonID = personID;
            Date = DateTime.Now;
        
        }


    }
}
