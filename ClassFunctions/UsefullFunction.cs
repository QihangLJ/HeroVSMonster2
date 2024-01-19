namespace UsefullFunction
{
    public class Utility
    {
        public static bool CheckRangeLimit(int value, int min, int max)
        //Comprueba si un valor esta dentro de los rangos que nosotros le indiquemos
        {
            return value >= min && value <= max;
        }
        public static int AssignValueInRange(int maxError, int min, int max)
        //Pide al usuario introducir un valor y comprueba que esta dentro del rango, si son valores fuera de rango entonces los errores se van acumulando.
        {
            const string MsgError = "Value are not valid!";
            const int ExhaustedAttemtps = -1;
            bool exitCondition = false;
            int errorAttempts = 0, userInput = 0;

            while (!exitCondition && errorAttempts < maxError)
            {
                userInput = Convert.ToInt32(Console.ReadLine());

                if (CheckRangeLimit(userInput, min, max))
                {
                    exitCondition = true;
                }
                else
                {
                    errorAttempts++;
                    Console.WriteLine(MsgError);
                }
            }
            //En caso de fallar 3 veces, devolvera -1 (ExhaustedAttemtps) indicando que el usuario se quedo sin intentos.
            return errorAttempts == maxError ? ExhaustedAttemtps : userInput;
        }
    }
}
