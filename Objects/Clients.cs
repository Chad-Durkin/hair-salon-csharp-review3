using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace HairSalon
{
    public class Client
    {
        private int _id;
        private string _name;
        private int _stylistId;

        public Client(string name, int stylistId, int id = 0)
        {
            _name = name;
            _stylistId = stylistId;
            _id = id;
        }


    }
}
