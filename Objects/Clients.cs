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

        public override bool Equals(System.Object otherCuisine)
        {
            if(!(otherCuisine is Cuisine))
            {
                return false;
            }
            else
            {
                Cuisine newCuisine = (Cuisine) otherCuisine;
                bool idEquality = this.GetId() == newCuisine.GetId();
                bool nameEquality = this.GetName() == newCuisine.GetName();
                bool stylistIdEquality = this.GetStylistId() == newCuisine.GetSytlistId();
                return(idEquality && nameEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static List<Cuisine> GetAll()
        {
            List<Cuisine> allCuisines = new List<Cuisine>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM cuisines;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int cuisineId = rdr.GetInt32(0);
                string cuisineName = rdr.GetSTring(1);
                int cuisineStylistId = rdr.GetInt32(2);
                Cuisine newCuisine = new Cuisine(cuisineName, cuisineId, cuisineStylistId);
                allCuisines.Add(newCuisine);
            }

            DB.CloseSqlConnection(rdr, conn);

            return allCuisines;
        }


                public int GetId()
                {
                    return _id;
                }
                public void SetId(int id)
                {
                    _id = id;
                }
                public int GetName()
                {
                    return _name;
                }
                public void SetName(int name)
                {
                    _name = name;
                }
                public int GetStylistId()
                {
                    return _stylistId;
                }
                public void SetStylistId(int stylistId)
                {
                    _stylistId = stylistId;
                }


    }
}
