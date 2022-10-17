using RestSharp;
using Session3_Homework.DataModels;
using Session3_Homework.Resources;
using Session3_Homework.Tests.TestData;

namespace Session3_Homework.Helpers
{
    /// <summary>
    /// Demo class containing all methods for pet
    /// </summary>
    public class PetHelper
    {
        /// <summary>
        /// Send POST request to add new pet
        /// </summary>
        public static async Task<PetModel> AddNewPet(RestClient client)
        {
            var newpetData = PetData.petModel();
            var postRequest = new RestRequest(Endpoints.PostPet());

            //Send Post Request to add new pet
            postRequest.AddJsonBody(newpetData);
            var postResponse = await client.ExecutePostAsync<PetModel>(postRequest);

            var createdPetData = newpetData;
            return createdPetData;
        }
    }
}