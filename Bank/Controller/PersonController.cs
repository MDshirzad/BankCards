using Bank.Model.Da;
using Bank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Controller
{
    public class PersonController
    {
        private DataAccess dataAccess = new DataAccess();
        public string Create(Person person)
        {
            return dataAccess.Create(person);

        }
    }
}
