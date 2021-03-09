﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AspCore_Bank.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public List<Client> Clients { get; set; }
    }
}
