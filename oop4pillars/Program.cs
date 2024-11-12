using System;
using System.Threading;
using RPG_GAME__OOP_FINALS_.Characters;
using RPG_GAME__OOP_FINALS_.GamePlay;


namespace RPG_GAME__OOP_FINALS_
{
    class Program
    {
        static int enemiesEnc = 0;
        static void Main()
        {
            gamePlay gameplay = new gamePlay();

            Console.ForegroundColor = ConsoleColor.Gray;
            gameplay.DisplayIntro();
            gameplay.ClassSelection();
            Console.ResetColor();

            while (true)
            {
                string foundWhat = gameplay.RoamAndSearch();

                if (enemiesEnc == 2)
                {
                    gameplay.finalBoss();
                }
                else
                {
                    if (foundWhat == "Enemy")
                    {
                        gameplay.BeginBattle();
                        enemiesEnc++;
                    }
                    else if (foundWhat == "Resource")
                    {
                        Console.WriteLine("Found some coins!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Nothing interesting here");
                        Console.Clear();
                    }
                }
            }


        }
    }
}
