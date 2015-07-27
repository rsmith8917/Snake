using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SnakeGame;

namespace SnakeConsole
{
    public class ConsoleRender
    {
        public int windowHeight { get; }
        public int windowWidth { get; }
        private List<Point> currentFrame = new List<Point>();

        public ConsoleRender(int width = 100, int height = 55)
        {
            Console.Clear();
            Console.CursorVisible = false;
            windowHeight = height;
            windowWidth = width;
            try
            {
                Console.SetWindowSize(windowWidth + 1, windowHeight + 1);
            }
            catch (Exception)
            {
                Console.SetWindowSize(100, 55);
            }
            displayBorder();
        }

        public void displayItem(Point item)
        {
            Console.SetCursorPosition(item.x, item.y);
            Console.Write("#");
        }

        private void displayBorder()
        {

            for (int i = 0; i < windowHeight; i++)
            {
                for (int j = 0; j < windowWidth; j++)
                {
                    if (i == 0 || i == (windowHeight - 1) || j == 0 || j == (windowWidth - 1))
                        Console.Write("/");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("");
            }

        }

        public void displayGameOver()
        {
            int hOffset = 12;
            int vOffset = 3;

            Console.SetCursorPosition(windowWidth / 2 - hOffset, windowHeight / 2 - vOffset);
            Console.Write("///////////////////////");
            Console.SetCursorPosition(windowWidth / 2 - hOffset, windowHeight / 2 - (vOffset - 1));
            Console.Write("/                     /");
            Console.SetCursorPosition(windowWidth / 2 - hOffset, windowHeight / 2 - (vOffset - 2));
            Console.Write("/      GAME OVER      /");
            Console.SetCursorPosition(windowWidth / 2 - hOffset, windowHeight / 2 - (vOffset - 3));
            Console.Write("/ Press Enter to Exit /");
            Console.SetCursorPosition(windowWidth / 2 - hOffset, (windowHeight / 2) - (vOffset - 4));
            Console.Write("/                     /");
            Console.SetCursorPosition(windowWidth / 2 - hOffset, (windowHeight / 2) - (vOffset - 5));
            Console.Write("///////////////////////");

            Console.ReadLine();
        }

        public void displaySnake(List<Point> snakePoints)
        {
            List<Point> diffPoints = snakePoints.Union(currentFrame).ToList();

            foreach (Point diffPoint in diffPoints)
            {
                Console.SetCursorPosition(diffPoint.x, diffPoint.y);
                if (snakePoints.Contains(diffPoint))
                    Console.Write("*");
                else
                    Console.Write(" ");
            }

            currentFrame = ClonableList.CloneList(snakePoints);
        }

        ~ConsoleRender()
        {
            Console.Clear();
            Console.CursorVisible = true;
        }


    }
}
