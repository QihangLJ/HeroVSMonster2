using BattleFunctions;
using UsefullFunction;

namespace MessagePrints
{
    public class Print
    {
        public static void MenuGame()
        //Muestra el menu del juego.
        {
            const string MsgMenu = "Welcome to Hero VS Monster 2: \n1.Start a new battle \n0.Exit";
            Console.WriteLine(MsgMenu);
        }

        public static void MenuGameDifficulty()
        //Muestra el menu de modos de juego o digicultades del juego.
        {
            const string MsgFirstDifficulty = "1.Easy";
            const string MsgSecondDifficulty = "2.Difficult";
            const string MsgThirdDifficulty = "3.Personalized";
            const string MsgFourthDifficulty = "4.Random";

            Console.WriteLine($"{MsgFirstDifficulty} \n{MsgSecondDifficulty} \n{MsgThirdDifficulty} \n{MsgFourthDifficulty}");
        }

        public static void ShowRoundCounter(ref int round)
        //Muestra un contador al inicio de cada ronda, que va aumentando segun las rondas que vaya pasando.
        {
            const string MsgWarning = "It's round: {0}";
            round++;
            Console.WriteLine(MsgWarning.ToUpper(), round);
        }

        public static void PrintHealthMessage(float[] healthArray, string[] nameArray)
        //Muestra la vida de los heroes o si estan muertos.
        {
            const string MsgSituation = "   - {0} have {1} HP";
            const string MsgDead = "   - {0} is DEAD";

            for (int i = 0; i < healthArray.Length; i++)
            {
                if (Battle.CheckIsDead(healthArray[i]))
                {
                    Console.WriteLine(MsgDead, nameArray[i].ToUpper());
                }
                else
                {
                    Console.WriteLine(MsgSituation, nameArray[i].ToUpper(), healthArray[i]);
                }
            }
        }

        public static void ShowSortedHealth(float[] healthArray, string[] nameArray)
        //Muestra de forma descendiente la situacion de los heroes en la batalla o si estan muertos.
        {
            const string MsgBattleSituation = "The battle situation is the next:";

            float[] DescendantHealthSort = Battle.SortCharacterDescendant(healthArray);
            string[] DescendantNameSort = Battle.SortCharacterDescendant(healthArray, nameArray);

            Console.WriteLine(MsgBattleSituation.ToUpper());

            PrintHealthMessage(DescendantHealthSort, DescendantNameSort);
        }

        public static int BattleAction(string name)
        //Muestra y pide al usuario introducir una opcion valida para seguir con las acciones del juego.
        {
            const string MsgToUser = "Select the action for {0}: \n1. Attack \n2. Protect \n3. Special ability";
            const int maxError = 3, minOption = 1, maxOption = 3;

            Console.WriteLine(MsgToUser, name.ToUpper());

            return Utility.AssignValueInRange(maxError, minOption, maxOption);
        }

        public static void ShowAttackInformation(string attackerName, float attackerDamage, string defensorName, float defensorHealth, float defensorDamageReduction)
        //Muestra los datos tras el ataque de un personaje.
        {
            const string MsgCausedDmg = "{0} attacks {1} with: {2} DMG";
            const string MsgReceiveDmg = "{0} defends himself and takes only: {1} DMG";
            const string MsgRemainingLife = "The Remaining life of {0}: {1} HP";
            const int Percentage = 100;

            Console.WriteLine(MsgCausedDmg, attackerName, defensorName, attackerDamage);
            Console.WriteLine(MsgReceiveDmg, defensorName, attackerDamage - (attackerDamage * (defensorDamageReduction / Percentage)));
            Console.WriteLine(MsgRemainingLife, defensorName, defensorHealth);
        }
    }
}
