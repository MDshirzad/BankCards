﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Entity
{
    public class Person
    {
        public Person()
        {
            HaveMultipleCards = false;

        }

        public int Id { get; set; }
        
        public string Name { get; set; }    
        public string Family { get; set; }
        public bool HaveMultipleCards { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();

    }
}
