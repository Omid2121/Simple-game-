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
        static int itemPosX, itemPosY;
        static int score, highScore;
        static int length = 10, height = 10;
        static char player = '*', space = '-', enemy ='@', item = '$';
        static Random random = new Random();


        static void Main(string[] args)
        {
            bool playing = true;

            while (playing) 
            {
                Play();

                if (score > highScore)
                    highScore = score;

                Console.WriteLine("\n Game Over! \n Final Score: " + highScore);                                             
                                         

                Console.WriteLine("Do you want to play again? (Y/N): ");
                ConsoleKeyInfo keyPressed = Console.ReadKey();                                 

                if (keyPressed.Key == ConsoleKey.N)               
                    playing = false;
                
            }           
               
        }

        static void Play()
        {
            playerPosX = 1;
            playerPosY = 1;
            enemyPosX = length;
            enemyPosY = height;
            score = 0;
            CreatItem();

            while (true)
            {
                Draw();

                if (PlayerCollideWithEnemy())
                {
                    break;
                }
                if (PlayerCollideWithItem())
                {
                    ++score;
                    CreatItem();
                    Draw();
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

        }

        static void MoveEnemy()
        {
            if (random.Next(0,11) < 2) 
                return;
            

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

        static bool PlayerCollideWithItem()
        {
            if (playerPosX == itemPosX && playerPosY == itemPosY) return true;

            return false;
        }

        static void CreatItem()
        {
            int x = random.Next(1, length), y = playerPosY;

            while (y > playerPosY - 2 && y < playerPosY + 2)
            {
                y = random.Next(1, height);
            }

            itemPosX = x;
            itemPosY = y;
        }

        static void Draw ()
        {
            Console.Clear();

            Console.WriteLine("Score: " + score + "\n");
            Console.WriteLine("(" + playerPosX + ", " + playerPosY + ")\n");
            Console.WriteLine("(" + enemyPosX + ", " + enemyPosY + ")\n");

            for (int y = 1; y <= height; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == enemyPosX && y == enemyPosY)
                        Console.WriteLine(enemy);

                    else if (x == playerPosX && y == playerPosY)                   
                        Console.WriteLine(player);
                    

                    else if (x == itemPosX && y == itemPosY)
                        Console.WriteLine(item);

                    else
                        Console.WriteLine(space);
                }

                Console.WriteLine();
            }

        }

    }
}
