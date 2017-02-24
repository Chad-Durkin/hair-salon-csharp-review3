using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace HairSalon
{
    public class Stylist
    {
        private int _id;
        private string _name;

        public Stylist(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        
    }
}
