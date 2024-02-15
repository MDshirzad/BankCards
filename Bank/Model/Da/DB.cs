using Bank.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Da
{
    public class DB:DbContext
    {
        public DB():base(getString())
        {
        }
      static  private string getString()
        {

            return $"Data Source=.;Initial Catalog=Bank;AttachDbFilename={Directory.GetCurrentDirectory()}/CardData.mdf;Integrated Security=true";
        }
        public DbSet<Person>People { get; set; }

        public DbSet<Card> Cards { get; set; }

    }
}
