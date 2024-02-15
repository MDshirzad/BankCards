using Bank.Model.Da;
using Bank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Controller
{
    public class PersonController
    {
        private DataAccessPerson dataAccess = new DataAccessPerson();

        public List<Person> Read(string strSearch)
        {
          return dataAccess.Read(strSearch);
        }
        public List<Person> Readall()
        {
            var q = dataAccess.ReadAll(); 
            foreach (var item in q)
            {
                item.Cards[0].CardNumber=Decode(item.Cards[0].CardNumber);
            }
            return q;
        }
        public string Create(Person person)
        {
            var card = person.Cards[0];
            card.CardNumber = Encode(card.CardNumber);
            return dataAccess.Create(person);

        }
        private string Encode(string cardnumber)
        {

            byte[] encData_byte = new byte[cardnumber.Length];

            encData_byte = System.Text.Encoding.UTF8.GetBytes(cardnumber);
            string encodeddata = Convert.ToBase64String(encData_byte);
            return encodeddata;


        }
        private string Decode(string encodedepass)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8decoder = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedepass);
            int charcount = utf8decoder.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charcount];

            utf8decoder.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

            string result = new string(decoded_char);
            return result;



        }

    }
}
