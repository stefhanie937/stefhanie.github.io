using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RPG_GAME__OOP_FINALS_.Characters;



namespace RPG_GAME__OOP_FINALS_.GamePlay
{
   public class gamePlay
   {
        static string keyPress;
        static string classPress;
        static string AEname;
        static AEs myAE;
        static Enemies enemy;

        public  string GetKeyPress()
        {
            return Console.ReadKey().Key.ToString().ToUpper();
        }

        public  void DisplayIntro()
        {
            IntroDisplay();
            Thread.Sleep(1000);
            Console.WriteLine();
            TypeText(new string[] { "   (P) Play | (S) Skip Story" }, true, true);


            if (GetKeyPress() == "P")
            {
                Console.Clear();
                IntroDisplay();
                Console.WriteLine();
                string[] messages =
                {

                    ">> Welcome, Human, to the entrance of the Virtual World of AETHERIA",
                    "\n",
                    "(GUARDIAN OF AETHERIA)",
                    ">> In VIRTUAL, the realms of the Real World and the Virtual World coexist.",
                    "Humans like you needs to have an AE, as your digital reflection, to help shape your experiences inside KWANGYA.",
                    "Your AE is a reflection of your essence in this Virtual World. Before you embark on your journey,",
                    "You must create a name  for your digital counterpart that resonates with you...",
                };

                TypeText(messages, true, true);
            }
            Thread.Sleep(2000);
            Console.Clear();
        }

        public void ClassSelection()
        {
            IntroDisplay();
            Console.WriteLine();
            TypeText(new string[] { "CHOOSE A CLASS" }, true, false);
             TypeText(new string[] { " (R) for rocket puncher | (A) for armamenter | (X) for xenoglossy | (E) for E.D hacker " }, true, true);
            keyPress = GetKeyPress();

            Console.Clear();
            IntroDisplay();
            Console.WriteLine();
            Console.Write(" Create your AE Name >>  ");
            AEname = Console.ReadLine();
            Console.Clear();

            if (keyPress == "R")
            {
                myAE = new RocketPuncher(550, 90, 50);
            }
            else if (keyPress == "A")
            {
                myAE = new Armamenter(600, 80, 100);
            }
            else if (keyPress == "X")
            {
                myAE = new Xenoglossy(430, 70, 40);
            }
            else if (keyPress == "E")
            {
                myAE = new ED_hacker(340, 75, 40);
            }
            else
            {
                Console.WriteLine("AE not found");
                return;
            }

            classPress = keyPress;
        }


        public void ViewPlayerDetail()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            TypeText(new string[] { $"- AE-{AEname} - " }, true, true);
            TypeText(new string[] { $"Name: {myAE.AEtype}" }, true, false);
            TypeText(new string[] { $"Health: {myAE.Health}" }, true, false);
            TypeText(new string[] { $"Damage: {myAE.Damage}"}, true, false);
            TypeText(new string[] { $"Armor: {myAE.Armor}"}, true, false);
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ViewEnemyDetail()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            TypeText(new string[] {$"- {enemy.EnemyType} -" }, true, true);
            TypeText(new string[] { $"Star Rank: {enemy.VirusRank}"}, true, false);
            TypeText(new string[] { $"Health: {enemy.Health}"}, true, false);
            TypeText(new string[] { $"Damage: {enemy.Damage}"}, true, false);
            TypeText(new string[] { $"Armor: {enemy.Armor}"}, true, false);
            Console.ResetColor();
            Console.WriteLine();
        }

        public Random random = new Random();
        public string RoamAndSearch()
        {
            IntroDisplay();
            Console.WriteLine();
            Console.WriteLine("(W) Walk");
            Console.Write("> ");
            keyPress = Console.ReadLine();
            Console.Clear();

            int chance = random.Next(20);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            TypeText(new string[] {$"AE-{AEname} is walking..."}, true, true);
            Thread.Sleep(3000);
            Console.Clear();

            if (chance < 10)
            {
                return "Enemy";
            }
            else if (chance < 15)
            {
                return "Resource";
                
            }
            else
            {
                return "Nothing";
            }

        }

        public void BeginBattle()
        {
            ChooseEnemy();
            IntroDisplay();
            Console.WriteLine();
            Console.WriteLine();
            TypeText(new string[] { "An enemy has appeared!" }, true, true);
            Console.WriteLine();
            TypeText(new string[] { $"- {enemy.EnemyType} -" }, true, false);
            TypeText(new string[] { $"{enemy.SkillInfo()}" }, true, true);
            Thread.Sleep(1000);
            Console.Clear();

            while (true)
            {
                IntroDisplay();
                ViewPlayerDetail();
                ViewEnemyDetail();
                TypeText(new string[] { "Choose an option  " }, true, false);
                TypeText(new string[] { "(A) to Attack | (H) to Heal | (S) for Special Attack" }, true, true);
                Console.Write("> ");
                keyPress = Console.ReadLine();
                Console.Clear();

                if (myAE.AEtype == "RocketPuncher" || myAE.AEtype == "Armamenter" || myAE.AEtype == "Xenoglossy" || myAE.AEtype == "E.D Hacker")
                {
                    int finalDamage;
                    if (keyPress.ToUpper() == "A")
                    {
                        finalDamage = enemy.TakeDamage(myAE.Damage);
                        Console.WriteLine("\n");
                        TypeText(new string[] { $"{enemy.EnemyType} took {finalDamage} damage!" }, true, false);

                        if (enemy.Health <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n");
                            TypeText(new string[] { "You won the battle!" }, true, true);

                            Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }


                        finalDamage = myAE.TakeDamage(enemy.Damage);
                        Console.WriteLine();
                        TypeText(new string[] { $"AE-{myAE.AEtype} took {finalDamage} damage!"}, true, true);

                    Console.WriteLine();
                        if (myAE.Health <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n");
                            TypeText(new string[] { "You lost the battle!" }, true, true);

                            Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }
                    }

                    else if (keyPress.ToUpper() == "H")
                    {
                        myAE.gainHP(100);
                        Console.WriteLine("\n");
                        TypeText(new string[] { "You have gained 100 HP!" }, true, true);
                    }

                    else if (keyPress.ToUpper() == "S")
                    {
                       finalDamage = myAE.Skill(enemy);
                        Console.WriteLine("\n");
                        TypeText(new string[] { $"{enemy.EnemyType} took {finalDamage} damage!"},true, true);
                    }

                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }

        public void IntroDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            TypeText (new string[] { " Realm of Aetheria " },true, false);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            TypeText(new string[] {"- Virtual World -" }, true, false);
            Console.ResetColor();

        }
        
        public void ChooseEnemy()
        {
            if (myAE.AEtype == "RocketPuncher")
            {
                enemy = new Binary_Specter(900, 60, 30);
            }
            else if (myAE.AEtype == "Armamenter")
            {
                enemy = new Elemental_Warden(900, 70, 80);

            }
            else if (myAE.AEtype == "Xenoglossy")
            {
                enemy = new Cipher_Illusionist(800, 50, 40);

            }
            else if (myAE.AEtype == "E.D Hacker")
            {
                enemy = new Stealth_Dynamo(700, 75, 60);

            }
        }

        public void finalBoss()
        {
            enemy = new Black_Mamba(1500, 100, 100); 

            IntroDisplay();
            Console.WriteLine("\n");
            TypeText(new string[] { "You have reached the final boss...." }, true, true);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            TypeText(new string[] { "Black Mamba has appeared!" }, true, true);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            TypeText(new string[] { $"{enemy.SkillInfo()}" }, true, true);
            Console.WriteLine();
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();

            while (true)
            {
                IntroDisplay();
                ViewEnemyDetail();
                ViewPlayerDetail();
                TypeText(new string[] { "Choose an option  " }, true, false);
                TypeText(new string[] { "(A) to Attack | (H) to Heal | (S) for Special Attack" }, true, true);
                Console.Write("> ");
                keyPress = Console.ReadLine();
                Console.Clear();

                int finalDamage;
                if (keyPress.ToUpper() == "A")
                {
                    finalDamage = enemy.TakeDamage(myAE.Damage);
                    Console.WriteLine();
                    Console.WriteLine();
                    TypeText(new string[] { $"{enemy.EnemyType} took {finalDamage} damage!" }, true, false);

                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        TypeText(new string[] { "You won the battle!" }, true, true);

                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    }


                    finalDamage = myAE.TakeDamage(enemy.Damage);
                    Console.WriteLine();
                    Console.WriteLine();
                    TypeText(new string[] { $"AE-{myAE.AEtype} took {finalDamage} damage!" }, true, true);

                    Console.WriteLine();
                    if (myAE.Health <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        TypeText(new string[] { "You lost the battle!" }, true, true);

                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    }
                }

                else if (keyPress.ToUpper() == "H")
                {
                    myAE.gainHP(100);
                    Console.WriteLine("\n");
                    TypeText(new string[] { "You have gained 100 HP!" }, true, true);
                }

                else if (keyPress.ToUpper() == "S")
                {
                    finalDamage = myAE.Skill(enemy);
                    Console.WriteLine("\n");
                    TypeText(new string[] { $"Binary Specter took {finalDamage} damage!" }, true, true);
                }
            }
        }

        public static void TypeText(string[] messages, bool shouldCenter, bool shouldAnimate)
        {
            foreach (string message in messages)
            {
                int startLeft = 0;
                if (shouldCenter)
                {
                    startLeft = ((Console.WindowWidth - message.Length) / 2);
                }
                Console.SetCursorPosition(startLeft, Console.CursorTop);

                if (shouldAnimate)
                {
                    foreach (char c in message)
                    {
                        Console.Write(c);
                        Thread.Sleep(15); // Adjust the delay between characters if needed
                    }
                    Thread.Sleep(800); // Adjust the delay between lines if needed
                }
                else
                {
                    Console.Write(message);
                }
                Console.WriteLine();
            }

        }
    }
}
