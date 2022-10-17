using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session3_Homework.DataModels;

namespace Session3_Homework.Tests
{
    public class APIBaseTest
    {
        public RestClient restClient { get; set; }

        public PetModel petData { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            restClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}