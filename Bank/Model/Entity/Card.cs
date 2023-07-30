using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Entity
{
    public class Card
        
    {
        public Card() { 
        
           
        }

        public int Id { get; set; }
        
        public string CardNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Person Person { get; set; }
    }
}
