using UsefullFunction;

namespace BattleFunctions
{
    public class Battle
    {
        public static string[] RandomOrderBattle(string[] nameArray)
        //Nos crea un array de string con un orden aleatorio, utilizaremos la funcion "CopyStringArray" para evitar que "randomList" y "nameArray" se sincronizen.
        {
            const int OFFSET = 1, min = 0;
            int randomTurn;
            string[] randomList = Utility.CopyStringArray(nameArray);
            Random heroSelector = new Random();

            for (int i = randomList.Length - OFFSET; i > min; i--)
            {
                randomTurn = heroSelector.Next(min, i + OFFSET);

                Utility.ExchangeStringVariable(ref randomList[i], ref randomList[randomTurn]);
            }
            return randomList;
        }

        public static float[] SortCharacterDescendant(float[] array)
        //Ordena el array con las vidas de los heroes de forma DESCENDIENTE.
        {
            const int OFFSET = 1;
            float[] sortedArray = Utility.CopyFloatArray(array);

            for (int i = 0; i < sortedArray.Length - OFFSET; i++)
            {
                for (int j = i + OFFSET; j < sortedArray.Length; j++)
                {
                    if (sortedArray[i] < sortedArray[j])
                    {
                        Utility.ExchangeFloatVariable(ref sortedArray[i], ref sortedArray[j]);
                    }
                }
            }
            return sortedArray;
        }

        public static string[] SortCharacterDescendant(float[] floatArray, string[] stringArray)
        //Ordena el array con los nombres de los heroes segun la vida que tengan, de forma DESCENDIENTE.
        {
            const int OFFSET = 1;
            float[] sortedFloatArray = Utility.CopyFloatArray(floatArray); //La utilizaremos como referencia para cambiar los nombres segun sus vida.
            string[] sortedStringArray = Utility.CopyStringArray(stringArray);

            for (int i = 0; i < sortedFloatArray.Length - OFFSET; i++)
            {
                for (int j = i + OFFSET; j < sortedFloatArray.Length; j++)
                {
                    if (sortedFloatArray[i] < sortedFloatArray[j])
                    {
                        Utility.ExchangeFloatVariable(ref sortedFloatArray[i], ref sortedFloatArray[j]);
                        Utility.ExchangeStringVariable(ref sortedStringArray[i], ref sortedStringArray[j]);
                    }
                }
            }
            return sortedStringArray;
        }

        public static bool CheckIsDead(float health)
        //Valida si el personaje esta muerto o no.
        {
            return health <= 0;
        }

        public static bool CheckDefeat(float[] healthArray)
        //Valida si todos los heroes estan muertos, si es asi, gana el monstruo.
        {
            for (int i = 0; i < healthArray.Length; i++)
            {
                if (!CheckIsDead(healthArray[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static float Attacked(float attackerDamage, float defensorHealth, float defensorDamageReduction)
        //Devuelve la vida que le quedaria al personaje que es atacado, despues de haber hecho los calculos con el percentage de reducion de daño.
        {
            const int Percentage = 100;
            return defensorHealth - (attackerDamage - (attackerDamage * (defensorDamageReduction / Percentage)));
        }

        public static float Protection(float userDamageReduction)
        //Duplica la reduccion de daño en caso de que el personaje se proteja.
        {
            const int duplicate = 2;
            return userDamageReduction * duplicate;
        }

        public static float CriticalAttack(float heroDamage)
        //Avisa y devuelve el doble de daño por ser un critico.
        {
            const string MsgCritical = "CRITICAL ATTACK!";
            const float Double = 2;
            Console.WriteLine(MsgCritical);
            return heroDamage * Double;
        }

        public static float FailedAttack(float heroDamage)
        //Avisa y devuelve 0 ya que el heroe fallo el ataque.
        {
            const string MsgFailed = "FAILED THE ATTACK!";
            Console.WriteLine(MsgFailed);
            return heroDamage - heroDamage;
        }
    }
}
