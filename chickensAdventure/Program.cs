using System;
using System.Runtime.InteropServices;

namespace chickensAdventure
{
    class versionOne
    {


        static void Main(string[] args)
        {
            int lives = 0, stamina = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your chicken? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref stamina, ref health, r);
            while (lives > 0 && stamina > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref stamina, ref health);
                else
                    actions(r.Next(10), ref lives, ref stamina, ref health);
                checkResults(ref round, ref lives, ref stamina, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully making it across the road!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not make it across the road.");
            else if (stamina <= 0)
                Console.WriteLine("You don't have any stamina left and cannot complete your journey across the road.");
            else
                Console.WriteLine("You are in poor health and had to stop your trek across the road early.");

        }

        private static void checkResults(ref int round, ref int lives, ref int stamina, ref int health, ref bool win)
        {
            round += 1;
            Console.WriteLine($"Round {round}");
            Console.WriteLine($"Lives: {lives}, Stamina: {stamina}, Health: {health}");
            if (round >= 15)
            {
                win = true;
                Console.WriteLine("You have won!");
            }
        }

        private static void actions(int v, ref int lives, ref int stamina, ref int health)
        {
            switch (v)

            {
                case 0:
                    Console.WriteLine("A tire flew off a car and hit you.");
                    Console.WriteLine("You lose 1 unit of health and 5 stamina.");
                    health -= 1;
                    stamina -= 5;
                    lives -= 0;
                    break;
                case 1:
                    Console.WriteLine("Some rubble flew into you while crossing the road.");
                    Console.WriteLine("You lost 1 units of health and 1 stamina.");
                    health -= 1;
                    stamina -= 1;
                    lives -= 0;
                    break;
                case 2:
                    Console.WriteLine("You got ran over by a car but luckily only your leg was damaged.");
                    Console.WriteLine("You lost 2 units of health and 1 life");
                    health -= 2;
                    stamina -= 0;
                    lives -= 1;
                    break;

                case 3:
                    Console.WriteLine("The wind picked up and started to carry you away.");
                    Console.WriteLine("You lost 2 units of health and 3 stamina.");
                    health -= 2;
                    stamina -= 3;
                    lives -= 0;
                    break;

                case 4:
                    Console.WriteLine("A car almost ran into you but luckily you got out of the way");
                    Console.WriteLine("You lost 5 stamina.");
                    health -= 0;
                    stamina -= 5;
                    lives -= 0;
                    break;

                case 5:
                    Console.WriteLine("You saved a fellow chicken on the road.");
                    Console.WriteLine("The traveler granted you 2 units of health, 2 stamina, and 2 lives.");
                    health += 2;
                    stamina += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You found bandages on the road and patched yourself up.");
                    Console.WriteLine("You gain 3 units of health and 5 stamina");
                    health += 3;
                    stamina += 5;
                    break;
                case 7:
                    Console.WriteLine("You found boots that made you very fast!");
                    Console.WriteLine("You gained 5 stamina");
                    health += 0;
                    stamina += 5;
                    lives += 0;
                    break;

                case 8:
                    Console.WriteLine("You found the elixir of life");
                    Console.WriteLine("You gain 2 lives and 2 stamina");
                    stamina += 2;
                    lives += 3;
                    break;

                case 9:
                    Console.WriteLine("You saved the pretty chicken across the road");
                    Console.WriteLine("You gain 2 lives!");
                    health += 0;
                    stamina -= 0;
                    lives += 2;
                    break;

                default:
                    Console.WriteLine("You ran into a flock of birds trying to eat you!");
                    Console.WriteLine("You gain 2 lives and 3 stamina");
                    health -= 0;
                    stamina -= 3;
                    lives -= 2;
                    break;
            }
        }

        private static int chooseDirection()
        {

            Console.WriteLine("You have come to a crossroad, enter 1 to travel left and a 2 to travel right");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }
        private static void initValues(ref int lives, ref int stamina, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            stamina = r.Next(30) + 5;
            health = r.Next(14) + 5;
            return;
        }

    }
}
