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
    }
}
