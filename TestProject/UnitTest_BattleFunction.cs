using BattleFunctions;

namespace TestProject
{
    [TestClass]
    public class UnitTest_BattleFunction
    {
        [TestMethod]
        public void IntroduceFourNames_ReturnAnArrayWithRandomOrder()
        {
            //Arrange
            string[] nameArray = ["one", "two", "three", "four"];

            //Act
            string[] result = Battle.RandomOrderBattle(nameArray);

            //Assert
            CollectionAssert.AreNotEqual(nameArray, result);
        }

        [TestMethod]
        public void SortDescendingTheFloatVariables_ReturnFloatArraySortedDescending()
        {
            //Arrange
            float[] array = [30.5f, 10.25f, 20.0f, 5.0f];

            //Act
            float[] result = Battle.SortCharacterDescendant(array);

            //Assert
            for (int i = 0; i < result.Length - 1; i++)
            {
                Assert.IsTrue(result[i] >= result[i + 1]);
            }
        }

        [TestMethod]
        public void SortDescendingTheStringVariables_ReturnStringArraySortedDescending()
        {
            //Arrange
            float[] floatArray = [30.5f, 10.0f, 20.0f, 5.0f];
            string[] stringArray = ["one", "two", "three", "four"];

            //Act
            string[] result = Battle.SortCharacterDescendant(floatArray, stringArray);

            //Assert
            string[] expected = ["one", "three", "two", "four"];

            for (int i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void CheckDead_HealthIsZero_ReturnTrue()
        {
            //Arrange
            float zero = 0.0f;

            //Act
            bool result = Battle.CheckIsDead(zero);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDead_HealthIsNegative_ReturnTrue()
        {
            //Arrange
            float negative = -5.0f;

            //Act
            bool result = Battle.CheckIsDead(negative);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDead_HealthIsPositive_ReturnFalse()
        {
            //Arrange
            float positive = 10.0f;

            //Act
            bool result = Battle.CheckIsDead(positive);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckDefeat_AllHeroesAreDead_ReturnTrue()
        {
            //Arrange
            float[] allDie = [0.0f, -5.0f, -10.0f];

            //Act
            bool result = Battle.CheckDefeat(allDie);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckDefeat_OneHeroIsAlive_ReturnFalse()
        {
            //Arrange
            float[] oneAlive = [0.0f, -5.0f, 10.0f];

            //Act
            bool result = Battle.CheckDefeat(oneAlive);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Attacked_ReturnCorrectRemainingHealth()
        {
            //Arrange
            float attackerDamage = 20.0f, defensorHealth = 100.0f, defensorDamageReduction = 20.0f;

            //Act
            float result = Battle.Attacked(attackerDamage, defensorHealth, defensorDamageReduction);

            //Assert
            Assert.AreEqual(84.0f, result);
        }

        [TestMethod]
        public void Protection_ReturnDoubledDamageReduction()
        {
            //Arrange
            float userDamageReduction = 10.0f;

            //Act
            float result = Battle.Protection(userDamageReduction);

            //Assert
            Assert.AreEqual(20.0f, result);
        }

        [TestMethod]
        public void CriticalAttack_ReturnDoubleDamage() //No valoraremos el mensaje, ya que solo es para orientar al usuario.
        {
            //Arrange
            float heroDamage = 10.0f;

            //Act
            float result = Battle.CriticalAttack(heroDamage);

            //Assert
            Assert.AreEqual(20.0f, result);
        }

        [TestMethod]
        public void FailedAttack_ReturnZeroDamage()
        {
            //Arrange
            float heroDamage = 10.0f;

            //Act
            float result = Battle.FailedAttack(heroDamage);

            //Assert
            Assert.AreEqual(0.0f, result);
        }

        [TestMethod]
        public void HeroDamageProbabilities_ReturnCorrectDamageBasedOnProbabilities()
        {
            //Arrange
            float heroDamage = 20.0f;

            //Act
            float result = Battle.HeroDamageProbabilities(heroDamage);

            //Assert
            Assert.IsTrue(result == 0.0f || result == heroDamage || result == heroDamage * 2);
        }

        [TestMethod]
        public void CheckCooldown_InCooldown_ReturnTrue()
        {
            //Arrange
            int initial = 5, final = 5;

            //Act
            bool result = Battle.CheckCooldown(initial, final);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCooldown_NotInCooldown_ReturnFalse()
        {
            //Arrange
            int initial = 4, final = 5;

            //Act
            bool result = Battle.CheckCooldown(initial, final);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MonsterAttack_ReduceHealthCorrectly_ReturnHealthArrayCorrectly()
        {
            // Arrange
            float monsterDmg = 15.0f;
            string[] nameArray = ["one", "two", "three"];
            float[] healthArray = [50.0f, 75.0f, 100.0f], dmgRedArray = [10f, 10f, 10f];

            // Act
            float[] result = Battle.MonsterAttack(monsterDmg, nameArray, healthArray, dmgRedArray);

            // Assert
            Assert.AreEqual(36.5f, result[0]);
            Assert.AreEqual(61.5f, result[1]);
            Assert.AreEqual(86.5f, result[2]);
        }

        [TestMethod]
        public void MonsterAttack__NotReduceHealthOfDeadHeroes_ReturnHealthArrayCorrectly()
        {
            // Arrange
            float monsterDmg = 15.0f;
            string[] nameArray = ["one", "two", "three"];
            float[] healthArray = [0.0f, 0.0f, 75.0f], dmgRedArray = [10f, 10f, 10f];

            // Act
            float[] result = Battle.MonsterAttack(monsterDmg, nameArray, healthArray, dmgRedArray);

            // Assert
            Assert.AreEqual(0.0f, result[0]);
            Assert.AreEqual(0.0f, result[1]);
            Assert.AreEqual(61.5f, result[2]);
        }
    }
}
