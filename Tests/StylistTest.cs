using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class StylistTest : IDisposable
    {
        public CuisineTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_StylistEmptyAtFirst()
        {
            // Arrange
            int result = Stylist.GetAll().Count;

            // Act

            // Assert
            Assert.Equal(0, result);
        }
    }
}
