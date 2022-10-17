using Session3_Homework.Tests;
using Session3_Homework.DataModels;

namespace Session3_Homework.Tests.TestData
{
    public class PetData
    {
        public static PetModel petModel()
        {
            return new PetModel
            {
                Id = 1123,
                Name = "Zkye",
                Status = "Available",
                PhotoUrls = new string[] { "pic.photo" },
                Category = new Category()
                {
                    Id = 0,
                    Name = "CutePet"
                },
                Tags = new Tag[]
                {
                        new Tag()
                        {
                        Id = 0,
                        Name = "Hypoallergenic, soft fur"
                        }
                }
            };
        }
    }
}