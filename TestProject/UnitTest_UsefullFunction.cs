using UsefullFunction;

namespace TestProject
{
    [TestClass]
    public class UnitTest_UsefullFunction
    {
        [TestMethod]
        public void CheckRangeLimit_ValueInsideTheRange_ReturnTrue()
        {
            //Arrange
            int valueInside = 5, min = 1, max = 10;

            //Act
            bool result = Utility.CheckRangeLimit(valueInside, min, max);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckRangeLimit_ValueOutsideTheRange_ReturnFalse()
        {
            //Arrange
            int valueOutside = 15, min = 1, max = 10;

            //Act
            bool result = Utility.CheckRangeLimit(valueOutside, min, max);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AssignValueInRange_InsideValue_ReturnValidValue()
        {
            //Arrange
            int maxError = 3, min = 1, max = 10;

            var consoleInput = new StringReader("5"); //Simula el input.
            Console.SetIn(consoleInput);

            //Act
            int result = Utility.AssignValueInRange(maxError, min, max);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void AssignValueInRange_OutsideValues_ReturnExhaustedAttemptsForInvalidValues()
        {
            //Arrange
            int maxError = 3, min = 1, max = 10;

            var consoleInput = new StringReader("15\n12\n11"); //Simula el input 3 veces.
            Console.SetIn(consoleInput);
            
            //Act
            int result = Utility.AssignValueInRange(maxError, min, max);

            //Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void EnterCharacterNames_ReturnUserInputCorrectly()
        {
            //Arrange
            string inputNames = "Archer, Barbarian, Wizard, Druid";

            var consoleInput = new StringReader(inputNames);
            Console.SetIn(consoleInput);

            //Act
            string result = Utility.EnterCharacterNames();

            //Assert
            Assert.AreEqual(inputNames, result);
        }

        [TestMethod]
        public void AssignNameWithString_AssignNamesCorrectly()
        {
            //Arrange
            string inputName = "Archer, Barbarian, Wizard, Druid", firstName = "", secondName = "", thirdName = "", fourthName = "";

            //Act
            Utility.AssignNameWithString(inputName, ref firstName, ref secondName, ref thirdName, ref fourthName);

            //Assert
            Assert.AreEqual("Archer", firstName);
            Assert.AreEqual("Barbarian", secondName);
            Assert.AreEqual("Wizard", thirdName);
            Assert.AreEqual("Druid", fourthName);
        }

        [TestMethod]
        public void CopyFloatArray_CreateCorrectCopy_ReturnTheCopy()
        {
            //Arrange
            float[] original = [1.0f, 2.0f, 3.0f, 4.0f];

            //Act
            float[] copied = Utility.CopyFloatArray(original);

            //Assert
            for (int i = 0; i < copied.Length; i++)
            {
                Assert.AreEqual(original[i], copied[i]);
            }
        }

        [TestMethod]
        public void CopyStringArray_CreateCorrectCopy_ReturnTheCopy()
        {
            //Arrange
            string[] original = { "Archer", "Barbarian", "Wizard", "Druid" };

            //Act
            string[] copied = Utility.CopyStringArray(original);

            //Assert
            for (int i = 0; i < copied.Length; i++)
            {
                Assert.AreEqual(original[i], copied[i]);
            }
        }

        [TestMethod]
        public void ExchangeFloatVariable_ExchangeTheValuesOfTwoVariables()
        {
            //Arrange
            float valueOne = 1.0f, valueTwo = 2.0f;

            //Act
            Utility.ExchangeFloatVariable(ref valueOne, ref valueTwo);

            //Assert
            Assert.AreEqual(2.0f, valueOne);
            Assert.AreEqual(1.0f, valueTwo);
        }

        [TestMethod]
        public void ExchangeStringVariable_ShouldExchangeValues()
        {
            //Arrange
            string valueOne = "Archer", valueTwo = "Barbarian";

            //Act
            Utility.ExchangeStringVariable(ref valueOne, ref valueTwo);

            //Assert
            Assert.AreEqual("Barbarian", valueOne);
            Assert.AreEqual("Archer", valueTwo);
        }

        [TestMethod]
        public void Probability_HighProbability_ReturnTrue_InsideTheProbability()
        {
            //Arrange
            int highProbability = 100;

            //Act
            bool highProbabilityResult = Utility.Probability(highProbability);

            //Assert
            Assert.IsTrue(highProbabilityResult);
        }

        [TestMethod]
        public void Probability_LowProbability_ReturnFalse_OutsideTheProbability()
        {
            //Arrange
            int lowProbability = 0;

            //Act
            bool lowProbabilityResult = Utility.Probability(lowProbability);

            //Assert
            Assert.IsFalse(lowProbabilityResult);
        }
    }
}
