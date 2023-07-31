using Bank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModel
{
    public class PersonView
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Family { get; set; }
        public string CardsNumber { get; set; } 
        public bool HaveMultipleCards { get; set; }
        public DateTime RegDate { get; set; }

    }
}
