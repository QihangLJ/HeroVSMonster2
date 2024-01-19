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
    }
}
