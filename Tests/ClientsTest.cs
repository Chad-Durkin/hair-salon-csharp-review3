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

            // Assert
            Assert.Equal(client1, client2);
        }

        [Fact]
        public void Test_Find_LocateStylistInDatabase_ReturnDesiredStylist()
        {
            // Arrange
            Client client1 = new Client("olivia", 0);
            client1.Save();

            // Act
            Client client2 = Client.Find(client1.GetId());

            // Assert
            Assert.Equal(client1, client2);
        }

        [Fact]
        public void Test_GetClients_RetrievesAllClientsWithStylist()
        {
              // Arrange
            Stylist testStylist = new Stylist("martha");
            testStylist.Save();
            Stylist testStylist2 = new Stylist("beth");
            testStylist.Save();

            // Act
            Client firstClient = new Client("jeff", testStylist.GetId());
            Client secondClient = new Client("jeffs brother", testStylist2.GetId());
            Client thirdClient = new Client("jeffs mom", testStylist2.GetId());
            firstClient.Save();
            secondClient.Save();
            thirdClient.Save();

            List<Client> testClientList = new List<Client> {firstClient};
            List<Client> resultClientList = testStylist.GetClients();

            // Assert
            Assert.Equal(testClientList, resultClientList);
        }

        [Fact]
        public void Test_Clients_Update_ChangeClientsInfo()
        {
            // Arrange
            Stylist stylist1 = new Stylist("beth");
            stylist1.Save();
            Client client1 = new Client("martha", stylist1.GetId());
            Client client2 = new Client("marthas brother", stylist1.GetId());
            client1.Save();

            // Act
            client1.Update("marthas brother");
            client1.SetId(0);
            stylist1.SetId(0);

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
