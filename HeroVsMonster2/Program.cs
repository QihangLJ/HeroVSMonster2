using CreationFunctions;
using BattleFunctions;
using UsefullFunction;
using MessagePrints;

namespace M03UF2PR1
{
    public class HeroVSMonster2
    {
        public static void Main()
        {
            const int StartGame = 1, ExitGame = 0, MaxError = 3, Error = -1, OFFSET = 1, SpecialAbilityCooldown = 5, AbilityEffectCooldown = 2,
                      FullDamageReduction = 100, TripleDamage = 3, Healing = 500;

            const int EasyMode = 1, DifficultMode = 2, PersonalizedMode = 3, RandomMode = 4, ArcherPosition = 0, BarbarianPosition = 1, WizardPosition = 2, DruidPosition = 3,
                      Attack = 1, Defense = 2, Ability = 3;

            const int ArcherMinHealth = 1500, ArcherMaxHealth = 2000, ArcherMinDamage = 200, ArcherMaxDamage = 300, ArcherMinDamageReduction = 25, ArcherMaxDamageReduction = 35,
                      BarbarianMinHealth = 3000, BarbarianMaxHealth = 3750, BarbarianMinDamage = 150, BarbarianMaxDamage = 250, BarbarianMinDamageReduction = 35, BarbarianMaxDamageReduction = 45,
                      WizardMinHealth = 1100, WizardMaxHealth = 1500, WizardMinDamage = 300, WizardMaxDamage = 400, WizardMinDamageReduction = 20, WizardMaxDamageReduction = 35,
                      DruidMinHealth = 2000, DruidMaxHealth = 2500, DruidMinDamage = 70, DruidMaxDamage = 120, DruidMinDamageReduction = 25, DruidMaxDamageReduction = 40,
                      MonsterMinHealth = 7000, MonsterMaxHealth = 10000, MonsterMinDamage = 300, MonsterMaxDamage = 400, MonsterMinDamageReduction = 20, MonsterMaxDamageReduction = 30;

            const string MonsterName = "Monster";
            const string MsgCreationTurn = "{0} ({1}) CREATION...";
            const string MsgCooldown = "It's on cooldown, wait {0} rounds more.";
            const string MsgErrorInput = "You have run out of attempts!";
            const string MsgExit = "Leaving the game...";
            const string MsgProtect = "{0} use protection, his Damage Reduction increases double.";
            const string MsgNextTurn = "The character didn't do anything!";
            const string MsgIsDead = "{0} is dead!";

            const string MsgHeroesVictory = "CONGRATULATIONS THE MONSTER HAS BEEN DEFEATED BY THE HEROES!";
            const string MsgMonsterVictory = "OH! ALL THE HEROES HAS BEEN DEFEATED BY THE MONSTER!";

            const string MsgArcherAbility = "The monster was KNOCKED OUT by {0}!";
            const string MsgBarbarianAbility = "{0} have full damage reduction for 2 rounds!";
            const string MsgWizardAbility = "{0} attacks with fire ball!";
            const string MsgDruidAbility = "{0} heals everyone for 500 more life points!";

            const string DrawGameTitle = "██████████████████████████████████████████████████████\r\n██╔╗█╔╗████████╔╗██╔╦═══╗╔═╗╔═╗████████╔╗██████╔═══╗██\r\n██║║█║║████████║╚╗╔╝║╔═╗║║║╚╝║║███████╔╝╚╗█████║╔═╗║██\r\n██║╚═╝╠══╦═╦══╗╚╗║║╔╣╚══╗║╔╗╔╗╠══╦═╗╔═╩╗╔╬══╦═╗╚╝╔╝║██\r\n██║╔═╗║║═╣╔╣╔╗║█║╚╝║╚══╗║║║║║║║╔╗║╔╗╣══╣║║║═╣╔╝╔═╝╔╝██\r\n██║║█║║║═╣║║╚╝║█╚╗╔╝║╚═╝║║║║║║║╚╝║║║╠══║╚╣║═╣║█║║╚═╗██\r\n██╚╝█╚╩══╩╝╚══╝██╚╝█╚═══╝╚╝╚╝╚╩══╩╝╚╩══╩═╩══╩╝█╚═══╝██\r\n██████████████████████████████████████████████████████\r\n";
            const string DrawArcher = "████╔╗███████\r\n████║╚╗██████\r\n║███║█╚═╗█═╗█\r\n╠═══╬═══╬══╬═\r\n║███║█╔═╝█═╝█\r\n████║╔╝██████\r\n████╚╝███████\r\n";
            const string DrawBarbarian = "█████╔═════╗█\r\n█████║███╔═╩╗\r\n█████║█╔═╝██║\r\n████╔╩═╬╗███║\r\n█╔══╝╔═╝╚═══╝\r\n╔╝╔══╝███████\r\n╚═╝██████████\r\n";
            const string DrawWizard = "██████║██████\r\n█████╔╩╗█████\r\n████╔╝█╚╗████\r\n█╔═╦╝███╚╦═╗█\r\n╔╝█╚═════╝█╚╗\r\n╚╗█████████╔╝\r\n█╚═════════╝█\r\n";
            const string DrawDruid = "████╔═════╗██\r\n██╔═╝█████╚╗█\r\n█╔╝██╔══╗██║█\r\n█║█╔═╝█═╝██║█\r\n█║█╚╗█████╔╝█\r\n█╚╗█╚═════╝██\r\n██║██████████\r\n";
            const string DrawMonster = "╔╗█████████╔╗\r\n╚╬═╗█████╔═╬╝\r\n█╚╦╩══╦══╩╦╝█\r\n██║███║███║██\r\n██║╔══╩══╗║██\r\n██║╚═════╝║██\r\n██╚═══════╝██\r\n";
            const string DrawLine = "--------------------------------------------------------";

            float archerHealth = 0, archerDamage = 0, archerDamageReduction = 0, barbarianHealth = 0, barbarianDamage = 0, barbarianDamageReduction = 0,
                  wizardHealth = 0, wizardDamage = 0, wizardDamageReduction = 0, druidHealth = 0, druidDamage = 0, druidDamageReduction = 0,
                  monsterHealth = 0, monsterDamage = 0, monsterDamageReduction = 0,
                  heroAttackDamage;
            int userSelection, roundCount, archerCooldownCount = 0, barbarianCooldownCount = 0, action;
            bool inGame, ExitHeroTurn;
            string nameInput, archerName = "", barbarianName = "", wizardName = "", druidName = "";
            
            string[] heroesNameArray, battleTurnOrder, heroesRoles = ["Archer", "Barbarian", "Wizard", "Druid"],
                     arrayDraw = [DrawArcher, DrawBarbarian, DrawWizard, DrawDruid];
            float[] heroesHealthArray, heroesDamageArray, heroesDmgRedArray;
            int[] finalPointArray; //Esta array nos servira para validar el enfriamiento de las abilidades de los heroes.

            Print.CleanAndPrintTitle(DrawGameTitle); //Titulo del juego.

            //El menu del juego para que el usuario escoga lo que quiere hacer.
            Print.MenuGame();
            userSelection = Utility.AssignValueInRange(MaxError, ExitGame, StartGame);

            while (userSelection > ExitGame)
            {
                Print.CleanAndPrintTitle(DrawGameTitle);

                //Iniciamos todas las variables que necessiten reiniciarse antes de una partida.
                roundCount = 0;
                inGame = true;
                ExitHeroTurn = false;
                finalPointArray = [1, 1, 1, 1];

                //Ponmemos los nombres a los personajes.
                nameInput = Utility.EnterCharacterNames();
                Utility.AssignNameWithString(nameInput, ref archerName, ref barbarianName, ref wizardName, ref druidName);

                Print.CleanAndPrintTitle(DrawGameTitle);

                //Selecionamos el modo de juego o la dificultad que queremos jugar.
                Print.MenuGameDifficulty();
                userSelection = Utility.AssignValueInRange(MaxError, EasyMode, RandomMode);

                Console.Clear();

                if (userSelection != Error)
                {
                    //Dependiendo del nivel de juego que hayamos selecionado, el "creación" de personaje sera de una manera o otra.
                    switch (userSelection)
                    {
                        case EasyMode:
                            Creation.AssignAttributeValue(ref archerHealth, ArcherMaxHealth, ref archerDamage, ArcherMaxDamage, ref archerDamageReduction, ArcherMaxDamageReduction);
                            Creation.AssignAttributeValue(ref barbarianHealth, BarbarianMaxHealth, ref barbarianDamage, BarbarianMaxDamage, ref barbarianDamageReduction, BarbarianMaxDamageReduction);
                            Creation.AssignAttributeValue(ref wizardHealth, WizardMaxHealth, ref wizardDamage, WizardMaxDamage, ref wizardDamageReduction, WizardMaxDamageReduction);
                            Creation.AssignAttributeValue(ref druidHealth, DruidMaxHealth, ref druidDamage, DruidMaxDamage, ref druidDamageReduction, DruidMaxDamageReduction);

                            Creation.AssignAttributeValue(ref monsterHealth, MonsterMinHealth, ref monsterDamage, MonsterMinDamage, ref monsterDamageReduction, MonsterMinDamageReduction);
                            break;

                        case DifficultMode:
                            Creation.AssignAttributeValue(ref archerHealth, ArcherMinHealth, ref archerDamage, ArcherMinDamage, ref archerDamageReduction, ArcherMinDamageReduction);
                            Creation.AssignAttributeValue(ref barbarianHealth, BarbarianMinHealth, ref barbarianDamage, BarbarianMinDamage, ref barbarianDamageReduction, BarbarianMinDamageReduction);
                            Creation.AssignAttributeValue(ref wizardHealth, WizardMinHealth, ref wizardDamage, WizardMinDamage, ref wizardDamageReduction, WizardMinDamageReduction);
                            Creation.AssignAttributeValue(ref druidHealth, DruidMinHealth, ref druidDamage, DruidMinDamage, ref druidDamageReduction, DruidMinDamageReduction);

                            Creation.AssignAttributeValue(ref monsterHealth, MonsterMaxHealth, ref monsterDamage, MonsterMaxDamage, ref monsterDamageReduction, MonsterMaxDamageReduction);
                            break;
                        case PersonalizedMode:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(DrawArcher);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(MsgCreationTurn, archerName.ToUpper(), heroesRoles[ArcherPosition]);
                            Creation.AssignAttributeValue(ref archerHealth, ArcherMinHealth, ArcherMaxHealth, ref archerDamage, ArcherMinDamage, ArcherMaxDamage, ref archerDamageReduction, ArcherMinDamageReduction, ArcherMaxDamageReduction, MaxError);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(DrawBarbarian);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(MsgCreationTurn, barbarianName.ToUpper(), heroesRoles[BarbarianPosition]);
                            Creation.AssignAttributeValue(ref barbarianHealth, BarbarianMinHealth, BarbarianMaxHealth, ref barbarianDamage, BarbarianMinDamage, BarbarianMaxDamage, ref barbarianDamageReduction, BarbarianMinDamageReduction, BarbarianMaxDamageReduction, MaxError);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(DrawWizard);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(MsgCreationTurn, wizardName.ToUpper(), heroesRoles[WizardPosition]);
                            Creation.AssignAttributeValue(ref wizardHealth, WizardMinHealth, WizardMaxHealth, ref wizardDamage, WizardMinDamage, WizardMaxDamage, ref wizardDamageReduction, WizardMinDamageReduction, WizardMaxDamageReduction, MaxError);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(DrawDruid);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(MsgCreationTurn, druidName.ToUpper(), heroesRoles[DruidPosition]);
                            Creation.AssignAttributeValue(ref druidHealth, DruidMinHealth, DruidMaxHealth, ref druidDamage, DruidMinDamage, DruidMaxDamage, ref druidDamageReduction, DruidMinDamageReduction, DruidMaxDamageReduction, MaxError);

                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(DrawMonster);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(MsgCreationTurn, MonsterName.ToUpper(), MonsterName);
                            Creation.AssignAttributeValue(ref monsterHealth, MonsterMinHealth, MonsterMaxHealth, ref monsterDamage, MonsterMinDamage, MonsterMaxDamage, ref monsterDamageReduction, MonsterMinDamageReduction, MonsterMaxDamageReduction, MaxError);

                            Console.Clear();
                            break;
                        case RandomMode:
                            Creation.AssignAttributeValue(ref archerHealth, ArcherMinHealth, ArcherMaxHealth, ref archerDamage, ArcherMinDamage, ArcherMaxDamage, ref archerDamageReduction, ArcherMinDamageReduction, ArcherMaxDamageReduction);
                            Creation.AssignAttributeValue(ref barbarianHealth, BarbarianMinHealth, BarbarianMaxHealth, ref barbarianDamage, BarbarianMinDamage, BarbarianMaxDamage, ref barbarianDamageReduction, BarbarianMinDamageReduction, BarbarianMaxDamageReduction);
                            Creation.AssignAttributeValue(ref wizardHealth, WizardMinHealth, WizardMaxHealth, ref wizardDamage, WizardMinDamage, WizardMaxDamage, ref wizardDamageReduction, WizardMinDamageReduction, WizardMaxDamageReduction);
                            Creation.AssignAttributeValue(ref druidHealth, DruidMinHealth, DruidMaxHealth, ref druidDamage, DruidMinDamage, DruidMaxDamage, ref druidDamageReduction, DruidMinDamageReduction, DruidMaxDamageReduction);

                            Creation.AssignAttributeValue(ref monsterHealth, MonsterMinHealth, MonsterMaxHealth, ref monsterDamage, MonsterMinDamage, MonsterMaxDamage, ref monsterDamageReduction, MonsterMinDamageReduction, MonsterMaxDamageReduction);
                            break;
                    }

                    //Assignamos todos los atributos en arrays para trabajar con ellos de manera mas facil.
                    heroesNameArray = Creation.CreateStringArray(archerName, barbarianName, wizardName, druidName);
                    heroesHealthArray = Creation.CreateFloatArray(archerHealth, barbarianHealth, wizardHealth, druidHealth);
                    heroesDamageArray = Creation.CreateFloatArray(archerDamage, barbarianDamage, wizardDamage, druidDamage);
                    heroesDmgRedArray = Creation.CreateFloatArray(archerDamageReduction, barbarianDamageReduction, wizardDamageReduction, druidDamageReduction);

                    while (inGame)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Print.ViewHeroesStats(heroesRoles, heroesNameArray, heroesHealthArray, heroesDamageArray, heroesDmgRedArray);
                        Print.ViewCharacterStats(MonsterName, MonsterName, monsterHealth, monsterDamage, monsterDamageReduction);
                        Console.WriteLine();

                        //Muestra un contador de rondas al inicio de cada ronda.
                        Print.ShowRoundCounter(ref roundCount);

                        //La maquina decide de forma aleatoria el orden de los turnos de cada heroe.
                        battleTurnOrder = Battle.RandomOrderBattle(heroesNameArray);

                        //Empieza el turno de los heroes.
                        int i = 0;
                        while (i < battleTurnOrder.Length && !ExitHeroTurn)
                        {
                            for (int j = 0; j < heroesNameArray.Length; j++)
                            {
                                //"heroesNameArray" siempre esta ordenado para poder encajar con los datos de los atributos, buscamos la direccion de los datos a traves del nombre.
                                if (battleTurnOrder[i] == heroesNameArray[j])
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine(arrayDraw[j]); //Mostrar el icono del personaje.
                                    if (Battle.CheckIsDead(heroesHealthArray[j]))
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine(MsgIsDead, heroesNameArray[j].ToUpper());
                                        Console.WriteLine();

                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine(DrawLine);
                                    }
                                    else
                                    {
                                        //Pedimos al usuario una accion para nuestro personaje.
                                        action = Print.BattleAction(heroesNameArray[j]);

                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkGray;

                                        switch (action)
                                        {
                                            case Attack:
                                                heroAttackDamage = Battle.HeroDamageProbabilities(heroesDamageArray[j]);
                                                monsterHealth = Battle.Attacked(heroAttackDamage, monsterHealth, monsterDamageReduction);
                                                Print.ShowAttackInformation(heroesNameArray[j], heroAttackDamage, MonsterName, monsterHealth, monsterDamageReduction);
                                                break;

                                            case Defense:
                                                heroesDmgRedArray[j] = Battle.Protection(heroesDmgRedArray[j]);
                                                Console.WriteLine(MsgProtect, heroesNameArray[j]);
                                                break;

                                            case Ability:
                                                //Si han pasado los 5 turnos despues de utilizar la habiulidad, podra volver a usarla.
                                                if (Battle.CheckCooldown(roundCount, finalPointArray[j]))
                                                {
                                                    switch (j)
                                                    {
                                                        case ArcherPosition: //Archer ability
                                                            archerCooldownCount = roundCount + AbilityEffectCooldown;
                                                            Console.WriteLine(MsgArcherAbility, heroesNameArray[j].ToUpper());
                                                            break;

                                                        case BarbarianPosition: //barbarian ability
                                                            barbarianCooldownCount = roundCount + AbilityEffectCooldown;
                                                            Console.WriteLine(MsgBarbarianAbility, heroesNameArray[j].ToUpper());
                                                            break;

                                                        case WizardPosition: //Wizard ability 
                                                            heroesDamageArray[j] *= TripleDamage;
                                                            Console.WriteLine(MsgWizardAbility, heroesNameArray[j].ToUpper());
                                                            monsterHealth = Battle.Attacked(heroesDamageArray[j], monsterHealth, monsterDamageReduction);
                                                            Print.ShowAttackInformation(heroesNameArray[j], heroesDamageArray[j], MonsterName, monsterHealth, monsterDamageReduction);
                                                            heroesDamageArray[j] = wizardDamage;
                                                            break;

                                                        case DruidPosition: //Druid ability
                                                            for (int k = 0; k < heroesHealthArray.Length; k++)
                                                            {
                                                                if (heroesHealthArray[k] > 0)
                                                                {
                                                                    heroesHealthArray[k] += Healing;
                                                                }
                                                            }
                                                            Console.WriteLine(MsgDruidAbility, heroesNameArray[j].ToUpper());
                                                            break;
                                                    }
                                                    //Assignamos hasta que ronda tiene que esperar para poder volver a usar la habiliad.
                                                    finalPointArray[j] = roundCount + SpecialAbilityCooldown + OFFSET;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(MsgCooldown, finalPointArray[j] - roundCount);
                                                }
                                                break;

                                            default:
                                                Console.WriteLine(MsgNextTurn);
                                                break;
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine(DrawLine);
                                    }
                                    //Comprueba si el monstruo ha sido eliminado o no.
                                    if (Battle.CheckIsDead(monsterHealth))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(MsgHeroesVictory);
                                        Console.WriteLine();
                                        ExitHeroTurn = true;
                                    }
                                }
                            }
                            i++;
                        }

                        //Vuelve a comprobar si el monstruo esta vivo para ejecutar el turno del mosntruo si siguiera vivo..
                        if (Battle.CheckIsDead(monsterHealth))
                        {
                            inGame = false;
                        }
                        else
                        {
                            //Al utilizar la habilidad del barbaro, se activara si estamos dentro de las 2 rondas que dura la habilidad y antes de que ataque el mosntruo.
                            if (roundCount < barbarianCooldownCount)
                            {
                                heroesDmgRedArray[BarbarianPosition] = FullDamageReduction;
                            }

                            //Si la arquera usa su habilidad, deja sin atacar al monstruo durante 2 rondas.
                            if (roundCount >= archerCooldownCount)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine(DrawMonster);

                                //El monstruo ataca a los heroes y muestra el daño que les han causado (por el orden de arquera, barbaro, mago, druida).
                                heroesHealthArray = Battle.MonsterAttack(monsterDamage, heroesNameArray, heroesHealthArray, heroesDmgRedArray);

                                //Muestra la salud de los heroes de forma descendiente.
                                Print.ShowSortedHealth(heroesHealthArray, heroesNameArray);

                                if (Battle.CheckDefeat(heroesHealthArray))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine(DrawLine);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(MsgMonsterVictory);
                                    Console.WriteLine();
                                    inGame = false;
                                }
                            }

                            //Para reiniciar otra vez el atributo de reduccion de daño de los heroes, para los que se han protegido.
                            heroesDmgRedArray = Creation.CreateFloatArray(archerDamageReduction, barbarianDamageReduction, wizardDamageReduction, druidDamageReduction);
                        }
                        //Pide al usuario pulsar una tecla para limpiar la consola, por si el usuario quiere revisar alguna informacion antes de que se borre todo.
                        Utility.CleanTheScreen();
                    }
                    Print.CleanAndPrintTitle(DrawGameTitle);

                    //Volvemos a preguntar al usuario si quiere volver a jugar.
                    Print.MenuGame();
                    userSelection = Utility.AssignValueInRange(MaxError, ExitGame, StartGame);
                }
            }

            if (userSelection == Error)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(MsgErrorInput);
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MsgExit);
        }
    }
}
