using System;
using System.Collections;
using System.Collections.Generic;

namespace banking_app
{
    public class User
    {
        public string username;
        public string pin;
        public decimal balance;
        public List<Transaction> transactions = new List<Transaction>();
    }
}
