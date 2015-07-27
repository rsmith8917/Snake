using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SnakeGame;

namespace SnakeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> snakePoints = new List<Point>();

            int width = 50;
            int height = 25;

            Snake snake = new Snake(width, height);

            ConsoleRender render = new ConsoleRender(width, height);

            ConsoleKey key = new ConsoleKey();

            while (key != ConsoleKey.Q && !snake.Dead)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    key = keyInfo.Key;
                    switch (key)
                    {
                        case ConsoleKey.RightArrow:
                            snake.Right();
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Left();
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Up();
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Down();
                            break;
                        default:
                            break;
                    }
                }

                render.displaySnake(snake.Move());
                render.displayItem(snake.item);
            }

            if (snake.Dead)
                render.displayGameOver();

        }

    }
}
