using Bank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Da
{
    public class DataAccessCard
    {
        protected DB db = new DB();

              
        public bool checker(Card c)
        {
            var result= db.Cards.Where(i=>i.CardNumber==c.CardNumber).FirstOrDefault();
             return result != null ? true : false;
         
        }
      

    }
}
