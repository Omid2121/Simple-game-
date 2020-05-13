using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Game
{
    class Program
    {
        static int playerPosX = 1, playerPosY = 1;
        static int enemyPosX, enemyPosY;
        static int length = 10, height = 10;
        static char player = '*', space = '-', enemy ='@';
        static Random random = new Random();



        static void Main(string[] args)
        {
            enemyPosX = length;
            enemyPosY = height;


            while (true)
            {             
                Draw();

                if (PlayerCollideWithEnemy())
                {
                    break;
                }

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if ((keyPressed.Key == ConsoleKey.W && playerPosY != 1) || (keyPressed.Key == ConsoleKey.S && playerPosY != height))
                {
                    playerPosY += (keyPressed.Key == ConsoleKey.S) ? 1 : -1;
                }
                else if ((keyPressed.Key == ConsoleKey.A && playerPosX != 1) || (keyPressed.Key == ConsoleKey.D && playerPosX != length))
                {
                    playerPosX += (keyPressed.Key == ConsoleKey.D) ? 1 : -1;
                }

                MoveEnemy();
               
            }

            Console.WriteLine("Game Over!");
            Console.Read();


        }

        static void MoveEnemy()
        {
            if ((random.Next(0, 11) >= 5 && playerPosX != enemyPosX) || playerPosY == enemyPosY)
            {
                if (playerPosX > enemyPosX) --enemyPosX;

                else if (playerPosX > enemyPosX) ++enemyPosX;
            }
            else 
            {
                if (playerPosY < enemyPosY) --enemyPosY;
                else if (playerPosY > enemyPosY) ++enemyPosY;                    
            }
        }

        static bool PlayerCollideWithEnemy()
        {
            if (playerPosX == enemyPosX && playerPosY == enemyPosY) return true;

            return false;
            
        }

        static void Draw ()
        {
            Console.Clear();

            Console.WriteLine("(" + playerPosX + ", " + playerPosY + ")\n");
            Console.WriteLine("(" + enemyPosX + ", " + enemyPosY + ")\n");


            for (int y = 1; y <= length; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == playerPosX && y == playerPosY)
                    {
                        Console.WriteLine(player);
                    }
                    else if (x == enemyPosX && y == enemyPosY)

                        Console.WriteLine(enemy);

                    else
                        Console.WriteLine(space);
                }
                Console.WriteLine();
            }

        }



    }
}
