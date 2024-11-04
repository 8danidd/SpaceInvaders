public class HelloWorld
{
    public static void Main(string[] args)
    {
        int shipPosX = 0;
        int lives = 3;
        int score = 0;
        int wallDamage = 5;
        bool shipAlive = true;

        start();

        void start()
        {
            Console.WriteLine("\r\n                                       \r\n,--.   ,--.  ,---.  ,--.,--.  ,--.     \r\n|   `.'   | /  O  \\ |  ||  ,'.|  |     \r\n|  |'.'|  ||  .-.  ||  ||  |' '  |     \r\n|  |   |  ||  | |  ||  ||  | `   |     \r\n`--'   `--'`--' `--'`--'`--'  `--'     \r\n,--.   ,--.,------.,--.  ,--.,--. ,--. \r\n|   `.'   ||  .---'|  ,'.|  ||  | |  | \r\n|  |'.'|  ||  `--, |  |' '  ||  | |  | \r\n|  |   |  ||  `---.|  | `   |'  '-'  ' \r\n`--'   `--'`------'`--'  `--' `-----'  \r\n                                       \r\n");
            while (true)
            {
                Console.WriteLine("Press 1 to damage the wall");
                Console.WriteLine("Press 2 to deal damage to the alien");
                Console.WriteLine("Press 3 to damage the ship");
                Console.WriteLine("Press 4 to show stats");
                Console.WriteLine("Press L/R arrow to move the ship");
                ConsoleKeyInfo KeyInfo = Console.ReadKey(true);

                switch (KeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        bulletHitWall();
                        break;
                    case ConsoleKey.D2:
                        bulletHitAlien();
                        break;
                    case ConsoleKey.D3:
                        bulletHitShip();
                        break;
                    case ConsoleKey.D4:
                        stats();
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        shipMove();
                        break;
                }
            }
        }


        void bulletHitWall()
        {
            if (shipAlive)
            {
                if (wallDamage > 0)
                {
                    Console.Clear();
                    wallDamage = wallDamage - 1;
                    Console.WriteLine("DAMAGE");
                    Console.WriteLine("Wall life: " + wallDamage);

                    if (wallDamage <= 0)
                    {
                        Console.WriteLine("The wall has been destroyed");
                    }
                }
                else
                {
                    start();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your ship is destroyed");
            }
        }

        void bulletHitAlien()
        {
            if (shipAlive)
            {
                Console.Clear();
                Console.WriteLine("Alien destroyed");
                score = score + 10;
                Console.WriteLine("Score:" + score);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your ship is destroyed");
            }
        }

        void bulletHitShip()
        {
            Console.Clear();
            if (lives <= 0)
            {
                gameOver();
                shipAlive = false;
            }
            else
            {
                lives = lives - 1;
                Console.WriteLine("Received damage");
                Console.WriteLine("Current lives: " + lives);
            }
        }

        void shipMove()
        {
            if (shipAlive)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (shipPosX > -100)
                        {
                            shipPosX = shipPosX - 10;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (shipPosX < 100)
                        {
                            shipPosX = shipPosX + 10;
                        }
                        break;
                }
                Console.Clear();
                Console.WriteLine("Current ship position: " + shipPosX + "\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your ship is destroyed");
            }
        }

        void gameOver()
        {
            Console.Clear();
            Console.WriteLine("\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀\r\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼\r\n██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀\r\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼\r\n███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼\r\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼\r\n██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼\r\n███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼\r\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\r\n");
        }

        void stats()
        {
            Console.Clear();
            Console.WriteLine("Wall HP: " + wallDamage);
            Console.WriteLine("Score: " + score);
            Console.WriteLine("Lives: " + lives);
            Thread.Sleep(1250);
            Console.Clear();
            start();
        }
    }
}