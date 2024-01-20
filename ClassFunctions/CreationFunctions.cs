using UsefullFunction;

namespace CreationFunctions
{
    public class Creation
    {
        public static void AssignAttributeValue(ref float attributeOne, int valueOne, ref float attributeTwo, int valueTwo, ref float attributeThree, int valueThree)
        //Asigna los valores al atributo de cada personaje, para los niveles "EASY" y "DIFFICULT".
        {
            attributeOne = valueOne;
            attributeTwo = valueTwo;
            attributeThree = valueThree;
        }

        public static void AssignAttributeValue(ref float attributeOne, int minValueOne, int maxValueOne, ref float attributeTwo, int minValueTwo, int maxValueTwo, ref float attributeThree, int minValueThree, int maxValueThree, int maxError)
        //Asigna los valores al atributo de cada personaje, para el nivel "PERSONALIZED".
        {
            const string MsgWarning = "Enter a {0} value between {1} - {2}:";
            const string Health = "HEALTH";
            const string Damage = "DAMAGE";
            const string DamageReduction = "DAMAGE REDUCTION";
            const int Error = -1;

            Console.WriteLine(MsgWarning, Health, minValueOne, maxValueOne);
            attributeOne = Utility.AssignValueInRange(maxError, minValueOne, maxValueOne);
            if (attributeOne == Error)
                attributeOne = minValueOne;

            Console.WriteLine(MsgWarning, Damage, minValueTwo, maxValueTwo);
            attributeTwo = Utility.AssignValueInRange(maxError, minValueTwo, maxValueTwo);
            if (attributeTwo == Error)
                attributeTwo = minValueTwo;

            Console.WriteLine(MsgWarning, DamageReduction, minValueThree, maxValueThree);
            attributeThree = Utility.AssignValueInRange(maxError, minValueThree, maxValueThree);
            if (attributeThree == Error)
                attributeThree = minValueThree;
        }

        public static void AssignAttributeValue(ref float attributeOne, int minValueOne, int maxValueOne, ref float attributeTwo, int minValueTwo, int maxValueTwo, ref float attributeThree, int minValueThree, int maxValueThree)
        //Asigna los valores al atributo de cada personaje, para el nivel "RANDOM".
        {
            Random randValue = new();

            attributeOne = randValue.Next(minValueOne, maxValueOne);
            attributeTwo = randValue.Next(minValueTwo, maxValueTwo);
            attributeThree = randValue.Next(minValueThree, maxValueThree);
        }

        public static float[] CreateFloatArray(float valueOne, float valueTwo, float valueThree, float valueFour)
        //Crea una array con la vida de los heroes.
        {
            float[] valuesArray = { valueOne, valueTwo, valueThree, valueFour };
            return valuesArray;
        }

        public static string[] CreateStringArray(string nameOne, string nameTwo, string nameThree, string nameFour)
        //Crea una array con los nombres de los heroes.
        {
            string[] nameArray = { nameOne, nameTwo, nameThree, nameFour };
            return nameArray;
        }
    }
}
