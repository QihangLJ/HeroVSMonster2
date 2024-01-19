using CreationFunctions;
using BattleFunctions;
using UsefullFunction;
using MessagePrints;
using System.Xml.Linq;

namespace M03UF2PR1
{
    public class HeroVSMonster2
    {
        public static void Main()
        {
            const int StartGame = 1, ExitGame = 0, MaxError = 3, Error = -1, OFFSET = 1, SpecialAbilityCooldown = 5, AbilityEffectCooldown = 2,
                      FullDamageReduction = 100, TripleDamage = 3, Healing = 500;

            const int EasyMode = 1, DifficultMode = 2, PersonalizedMode = 3, RandomMode = 4, ArcherPosition = 0, BarbarianPosition = 1, WizardPosition = 2, DruidPosition = 3;

            const string MsgErrorInput = "You have run out of attempts!";
            const string MsgExit = "Leaving the game...";

            int userSelection, roundCount = 0, archerCooldownCount = 0, barbarianCooldownCount = 0;

            Print.MenuGame();
            userSelection = Utility.AssignValueInRange(MaxError, ExitGame, StartGame);
            
            if (userSelection == Error)
            {
                Console.WriteLine(MsgErrorInput);
            }
            else if (userSelection == StartGame)
            {
                    
            }
            else
            {
                Console.WriteLine(MsgExit);
            }
        }
    }
}
