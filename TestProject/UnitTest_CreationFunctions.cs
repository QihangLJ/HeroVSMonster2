using CreationFunctions;

namespace TestProject
{
    [TestClass]
    public class UnitTest_CreationFunctions
    {
        [TestMethod]
        public void UserInputValue_ValueIsAccepted()
        {
            //Arrange
            var consoleInput = new StringReader("42");
            Console.SetIn(consoleInput);

            string msg = "Enter a value for {0} ({1}-{2}):", item = "Health";
            int min = 1, max = 100, error = 3;

            //Act
            float result = Creation.PersonalizeAttribute(msg, item, min, max, error);

            //Assert
            Assert.AreEqual(42.0f, result);
        }

        [TestMethod]
        public void UserInputValue_ValuNotAccepted_AssignMinValue()
        {
            //Arrange
            var consoleInput = new StringReader("200");
            Console.SetIn(consoleInput);

            string msg = "Enter a value for {0} ({1}-{2}):", item = "Health";
            int min = 1, max = 100, error = 0; //Declaramos error = 0, para que nos salta el error al primer input.

            //Act
            float result = Creation.PersonalizeAttribute(msg, item, min, max, error);

            //Assert
            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void AssignValueToAttribute_AssignCorrectValues()
        {
            //Arrange
            float attributeOne = 0.0f, attributeTwo = 0.0f, attributeThree = 0.0f;
            int valueOne = 10, valueTwo = 20, valueThree = 30;

            //Act
            Creation.AssignAttributeValue(ref attributeOne, valueOne, ref attributeTwo, valueTwo, ref attributeThree, valueThree);

            //Assert
            Assert.AreEqual(valueOne, attributeOne);
            Assert.AreEqual(valueTwo, attributeTwo);
            Assert.AreEqual(valueThree, attributeThree);
        }

        [TestMethod]
        public void AssignRandomToAttribute_AssignCorrectValues_ValuesAreInRange()
        {
            //Arrange
            float attributeOne = 0.0f, attributeTwo = 0.0f, attributeThree = 0.0f;
            int minValueOne = 1, minValueTwo = 10, minValueThree = 50;
            int maxValueOne = 10, maxValueTwo = 50, maxValueThree = 100;

            //Act
            Creation.AssignAttributeValue(ref attributeOne, minValueOne, maxValueOne, ref attributeTwo, minValueTwo, maxValueTwo, ref attributeThree, minValueThree, maxValueThree);

            //Assert
            Assert.IsTrue(attributeOne >= minValueOne && attributeOne <=maxValueOne);
            Assert.IsTrue(attributeTwo >= minValueTwo && attributeTwo <= maxValueTwo);
            Assert.IsTrue(attributeThree >= minValueThree && attributeThree <= maxValueThree);
        }

        [TestMethod]
        public void CreateFloatArray_ReturnFloatArray()
        {
            //Arrange
            float valueOne = 10.0f, valueTwo = 20.0f, valueThree = 30.0f, valueFour = 40.0f;

            //Act
            float[] result = Creation.CreateFloatArray(valueOne, valueTwo, valueThree, valueFour);

            //Assert
            Assert.AreEqual(valueOne, result[0]);
            Assert.AreEqual(valueTwo, result[1]);
            Assert.AreEqual(valueThree, result[2]);
            Assert.AreEqual(valueFour, result[3]);
        }

        [TestMethod]
        public void CreateStringArray_ReturnStringArray()
        {
            //Arrange
            string valueOne = "nameOne", valueTwo = "nameTwo", valueThree = "nameThree", valueFour = "nameFour";

            //Act
            string[] result = Creation.CreateStringArray(valueOne, valueTwo, valueThree, valueFour);

            //Assert
            Assert.AreEqual(valueOne, result[0]);
            Assert.AreEqual(valueTwo, result[1]);
            Assert.AreEqual(valueThree, result[2]);
            Assert.AreEqual(valueFour, result[3]);
        }
    }
}