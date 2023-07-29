using Bank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Bank.Model.Da
{
    public class DataAccess
    {
        private DB db = new DB();

     

        public string Create(Person person)
        {
           
            try
            {
                if (!checker(person))
                {
                    db.People.Add(person);
                    db.SaveChanges();
                    return " اطلاعات با موفقیت ثبت شد";
                }
                return "اطلاعات تکراری است";
            }
            catch (Exception ex)
            {

                return "ارور در هنگام ثبت"+ex.Message;
            }
        }
      
        private bool checker(Person person)
        {
            var rPerson = from item in db.People where ((person.Name == item.Name) ? true : false) && ((person.Family == item.Family) ? true : false) select item;
            if (rPerson.FirstOrDefault() != null)
            {
                return true;
            }

            var cards = db.Cards;
            foreach (var item in cards)
            {
                if (person.Cards[0].CardNumber == item.CardNumber) { return true; }
              
            }
           
            
            return false;
        }

    }
}
