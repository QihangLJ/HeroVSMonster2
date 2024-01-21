using MessagePrints;

namespace TestProject
{
    [TestClass]
    public class UnitTest_Procedures
    {
        [TestMethod]
        public void TestForTheTesting() //Test simple para confirmar que pasa, el resto puede no pasar por question de los colores.
        {
            //Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            Print.TestProcedure();

            //Assert
            string expectedOutput = "test";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void PrintGameMenu_DisplayCorrectly()
        {
            //Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            Print.MenuGame();

            //Assert
            string expectedOutput = "WELCOME TO HERO VS MONSTER 2: \n1.Start a new battle \n0.Exit";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void PrintGameDifficultyMenu_DisplayCorrectly()
        {
            //Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            Print.MenuGameDifficulty();

            //Assert
            string expectedOutput = "CHOOSE THE GAME MODE: \n1.Easy \n2.Difficult \n3.Personalized \n4.Random";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void PrintRoundCounter_DisplayCorrectly()
        {
            //Arrange
            int round = 0;
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            Print.ShowRoundCounter(ref round);

            //Assert
            string expectedOutput = "ROUND: 1";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
            Assert.AreEqual(1, round); // Verifica que el valor de la variable "round" se haya incrementado correctamente
        }

        [TestMethod]
        public void PrintHealthMessage_DisplayCorrectly()
        {
            //Arrange
            float[] healthArray = [100.0f, 0.0f, 50.0f];
            string[] nameArray = ["HeroOne", "HeroTwo", "HeroThree"];

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            Print.PrintHealthMessage(healthArray, nameArray);

            //Assert
            string expectedOutput = "   - HeroOne have 100 HP \n   - HeroTwo is DEAD \n   - HeroThree have 50 HP";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void PrintSortedHealth_DisplayCorrectly()
        {
            //Arrange
            float[] healthArray = [100.0f, 50.0f, 75.0f];
            string[] nameArray = ["HeroOne", "HeroTwo", "HeroThree"];

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            //Act
            Print.ShowSortedHealth(healthArray, nameArray);

            //Assert
            string expectedOutput = "THE BATTLE SITUATION IS THE NEXT:\n   - HeroOne have 100 HP\n   - HeroThree have 75 HP\n   - HeroTwo have 50 HP";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void PrintBattleAction_DisplayCorrectly_AndReturnAction()
        {
            //Arrange
            var userInput = new StringReader("2");
            Console.SetIn(userInput);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            string playerName = "Hero";

            //Act
            int result = Print.BattleAction(playerName);

            //Assert
            string expectedOutput = "SELECT THE ACTION FOR HERO \n1. Attack \n2. Protect \n3. Special ability";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void PrintAttackInformation_DisplayCorrectly()
        {
            //Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            string attackerName = "Hero";
            float attackerDamage = 30.0f;
            string defensorName = "Monster";
            float defensorHealth = 70.0f;
            float defensorDamageReduction = 20.0f;

            //Act
            Print.ShowAttackInformation(attackerName, attackerDamage, defensorName, defensorHealth, defensorDamageReduction);

            //Assert
            string expectedOutput = "HERO attacks MONSTER with: 30 DMG \nMONSTER defends himself and takes only: 24 DMG \nThe Remaining life of MONSTER: 70 HP\n";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void CleanAndPrintTitle_DisplayCorrectly()
        {
            //Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            string print = "hello";

            //Act
            Print.CleanAndPrintTitle(print);

            //Assert
            string expectedOutput = "hello";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void PrintCharacterStats_DisplayCorrectly()
        {
            //Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            string role = "Monster";
            string name = "Monster";
            float health = 100.0f;
            float damage = 20.0f;
            float damageReduction = 10.0f;

            //Act
            Print.ViewCharacterStats(role, name, health, damage, damageReduction);

            //Assert
            string expectedOutput = "ROLE: Warrior  /  NAME: Monster  /  HEALTH: 100  /  DAMAGE: 20  /  DAMAGE REDUCTION: 10";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void PrintHeroesStats_DisplayCorrectly()
        {
            //Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            string[] roles = ["Archer", "Barbarian"];
            string[] names = ["HeroOne", "HeroTwo"];
            float[] health = [100.0f, 80.0f];
            float[] damage = [20.0f, 30.0f];
            float[] damageReduction = [10.0f, 15.0f];

            //Act
            Print.ViewHeroesStats(roles, names, health, damage, damageReduction);

            //Assert
            var expectedOutput = "ROLE: Archer  /  NAME: HeroOne  /  HEALTH: 100  /  DAMAGE: 20  /  DAMAGE REDUCTION: 10" +
                                 "\nROLE: Barbarian  /  NAME: HeroTwo  /  HEALTH: 80  /  DAMAGE: 30  /  DAMAGE REDUCTION: 15";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

    }
}