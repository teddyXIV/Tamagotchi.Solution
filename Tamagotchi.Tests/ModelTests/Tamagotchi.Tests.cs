using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.Models;

namespace Tamagotchi.Tests
{
    [TestClass]
    public class PetTests
    {
        [TestMethod]
        public void PetConstructor_InstantiatesAnInstanceOfPet()
        {
            Pet randolph = new("randolph", 0, 10, 3, 9);
            Assert.AreEqual(randolph.GetType(), typeof(Pet));
        }
        [TestMethod]
        public void PetConstructor_GetName_String()
        {
            string name = "randolph";
            Pet randolph = new Pet(name, 0, 10, 3, 9);
            Assert.AreEqual(randolph.Name, name);

        }
    }
}