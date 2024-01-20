using UsefullFunction;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CreationFunctions
{
    public class Creation
    {
        public static float PersonalizeAttribute(string message, string item, int minValue, int maxValue, int maxError)
        //Metodo para assignar un valor (introducido por el usuario) a un atributo en especifico, para el modo personalizado.
        {
            const string AutoAssign = "Auto assigned";
            const int Error = -1;

            float attribute;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message, item, minValue, maxValue);
            Console.ForegroundColor = ConsoleColor.Green;
            attribute = Utility.AssignValueInRange(maxError, minValue, maxValue);
            if (attribute == Error)
            {
                Console.WriteLine(AutoAssign.ToUpper());
                attribute = minValue;
            }
            return attribute;
        }

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

            attributeOne = PersonalizeAttribute(MsgWarning, Health, minValueOne, maxValueOne, maxError);
            attributeTwo = PersonalizeAttribute(MsgWarning, Damage, minValueTwo, maxValueTwo, maxError);
            attributeThree = PersonalizeAttribute(MsgWarning, DamageReduction, minValueThree, maxValueThree, maxError);

            Console.WriteLine();
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
            return [valueOne, valueTwo, valueThree, valueFour];
        }

        public static string[] CreateStringArray(string nameOne, string nameTwo, string nameThree, string nameFour)
        //Crea una array con los nombres de los heroes.
        {
            return [nameOne, nameTwo, nameThree, nameFour];
        }
    }
}
