using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class StylistTest : IDisposable
    {
        public StylistTest()
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

        [Fact]
        public void Test_IdentityTest_ReturnTrueIfStylistsAreIdentical()
        {
            // Arrange
            Stylist stylist1 = new Stylist("beth");
            Stylist stylist2 = new Stylist("beth");

            // Act

            // Assert
            Assert.Equal(stylist1, stylist2);
        }

        [Fact]
        public void Test_Save_SaveStylistsInDatabase()
        {
            // Arrange
            Stylist stylist1 = new Stylist("beth");
            stylist1.Save();

            // Act
            Stylist stylist2 = Stylist.GetAll()[0];

            // Assert
            Assert.Equal(stylist1, stylist2);
        }

        [Fact]
        public void Test_Find_LocateStylistInDatabase_ReturnDesiredStylist()
        {
            // Arrange
            Stylist stylist1 = new Stylist("beth");
            stylist1.Save();

            // Act
            Stylist stylist2 = Stylist.Find(stylist1.GetId());

            // Assert
            Assert.Equal(stylist1, stylist2);
        }

        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
        }
    }
}
