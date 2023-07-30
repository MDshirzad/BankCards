using Bank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace Bank.Model.Da
{
    public class DataAccessPerson: DataAccessCard
    {

        #region Variables and Instances

        private static string _ConnectionString = "Data Source=.;Initial Catalog=Bank;Integrated Security=true";
        private SqlCommand _command;
        private SqlConnection _con = new SqlConnection(_ConnectionString);
        #endregion
        
        
        public List<Person> ReadAll()
        {
            return db.People.Include("Cards").ToList();
            
        }
        public List<Person> Read(string strSearch)
        {
            return db.People.Include("Cards").Where(s=>s.Family.Contains(strSearch)|| s.Name.Contains(strSearch)).ToList();

        }
        public string Create(Person person) {

           
            
            try
            {
                _con.Open();
                var personExists = checker(person);
                var cardExists = checker(person.Cards[0]);
                if (cardExists)
                {
                    return "کارت موجود است";
                }
                else { 

                 if (personExists != null)
                {
                     // Person Exists and Card not exists
                    
                        string queryperson = "INSERT INTO dbo.Cards (CardNumber,RegistrationDate,Person_Id) VALUES (@CardNumber,@RegistrationDate,@person_Id)";
                        
                        var card = person.Cards[0];
                        _command = new SqlCommand(queryperson,_con);
                        _command.Parameters.Add("@CardNumber", card.CardNumber);
                        _command.Parameters.Add("@RegistrationDate", card.RegistrationDate);
                        _command.Parameters.Add("@person_Id", personExists.Id);
                        _command.ExecuteNonQuery();
                        return $"کارت جدید ثبت شد";

                    
                }

                    else
                    {// Person and Cart are not exist

                        db.People.Add(person);
                        db.SaveChanges();
                        return "اطلاعات ثبت شد";

                    }
                }

            }
            catch (Exception ex) {
                return ex.Message;
            }
            finally { 
            _con.Close();
            }
        }
        
        public Person checker(Person person)
        {
            var rPerson = from item in db.People where ((person.Name == item.Name) ? true : false) && ((person.Family == item.Family) ? true : false) select item;
            if (rPerson.FirstOrDefault() != null)
            {
                return rPerson.FirstOrDefault();
            }
        
            return null;
        }

    }
}
