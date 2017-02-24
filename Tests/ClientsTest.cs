using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_ClientEmptyAtFirst()
        {
            // Arrange
            int result = Client.GetAll().Count;

            // Act

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_IdentityTest_ReturnTrueIfClientsAreIdentical()
        {
            // Arrange
            Client client1 = new Client("olivia", 0);
            Client client2 = new Client("olivia", 0);

            // Act
            // Assert
            Assert.Equal(client1, client2);
        }

        [Fact]
        public void Test_Save_SaveClientsInDatabase()
        {
            // Arrange
            Client client1 = new Client("olivia", 0);
            client1.Save();

            // Act
            Client client2 = Client.GetAll()[0];

            Console.WriteLine(client1.GetId());
            Console.WriteLine(client2.GetId());

            // Assert
            Assert.Equal(client1, client2);
        }

        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
        }
    }
}
