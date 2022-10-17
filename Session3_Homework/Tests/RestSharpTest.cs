using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session3_Homework.DataModels;
using Session3_Homework.Helpers;
using Session3_Homework.Resources;
using System.Net;

namespace Session3_Homework.Tests
{
    [TestClass]
    public class Session3_Homework : APIBaseTest
    {
        private static List<PetModel> userCleanUpList = new List<PetModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            petData = await PetHelper.AddNewPet(restClient);
        }

        [TestMethod]
        public async Task DemoGetPet()
        {
            //Arrange
            var PetGetRequest = new RestRequest(Endpoints.GetPetByPetId(petData.Id));
            userCleanUpList.Add(petData);

            //Act
            var PetResponse = await restClient.ExecuteGetAsync<PetModel>(PetGetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, PetResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(petData.Id, PetResponse.Data.Id, "Pet ID did not match.");
            Assert.AreEqual(petData.Name, PetResponse.Data.Name, "Pet name did not match.");
            Assert.AreEqual(petData.Status, PetResponse.Data.Status, "Pet status did not match.");
            Assert.AreEqual(petData.PhotoUrls[0], PetResponse.Data.PhotoUrls[0], "Pet photo URL did not match.");
            Assert.AreEqual(petData.Tags[0].Id, PetResponse.Data.Tags[0].Id, "Pet tag ID did not match.");
            Assert.AreEqual(petData.Tags[0].Name, PetResponse.Data.Tags[0].Name, "Pet tag name did not match.");
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in userCleanUpList)
            {
                var deleteUserRequest = new RestRequest(Endpoints.GetPetByPetId(data.Id));
                var deleteUserResponse = await restClient.DeleteAsync(deleteUserRequest);
            }
        }
    }
}