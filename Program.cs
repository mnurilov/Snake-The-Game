using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
        
namespace _Snake
{
    class SnakePart
    {
        public int x;
        public int y;
        public char display = 'O';
    }
    class Snake
    {
        public int direction = 0; //0 down, 1 left, 2 up, 3 right
        public List<SnakePart> snake = new List<SnakePart>();
        public void SpawnSnake(Random rand)
        {
            SnakePart head = new SnakePart();
            head.x = rand.Next(8, 16);
            head.y = rand.Next(8, 16);
            snake.Add(head);
        }
        public void UpdateSnake() 
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (direction)
                    { 
                        case 0://Down
                            snake[i].y++;
                            break;
                        case 1://Left
                            snake[i].x--;
                            break;
                        case 2://Up
                            snake[i].y--;
                            break;
                        case 3://Right
                            snake[i].x++;
                            break;
                    }
                }
                else
                {
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;
                }
            }
        }
        public void DisplaySnake()
        {
            for (int i = 0; i < snake.Count; i++)
            {
                Console.SetCursorPosition(snake[i].x, snake[i].y);
                Console.Write(snake[i].display);
            }
        }
        public static void IncreaseSize()
        {

        }
        public void DeadSnake()
        {

        }
    }
    class Apple
    {
        int x;
        int y;
        char display = '$';
        public void SpawnApple()
        {

        }
        public void DisplayApple()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(display);
        }
        public void AppleEaten()
        {

        }
    }

	class MainClass
	{
        static void Collision(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 && y1 == y2)
            {

            }
        }
        static void SetScreen()
        {
            Console.SetWindowSize(40, 35);
            Console.SetBufferSize(40, 35);
        }

        public static void Main(string[] args)
		{
            SetScreen();
			Console.CursorVisible = false;
			int x = 10;
			int y = 10;
			ConsoleKey input;
			input = ConsoleKey.RightArrow;
            Snake Snake = new Snake();
            Random rand = new Random();
            Snake.SpawnSnake(rand);

			while (true)
			{
				while (!Console.KeyAvailable)
				{
					Thread.Sleep(250);
                    Snake.UpdateSnake();
                    Snake.DisplaySnake();
					if (input == ConsoleKey.UpArrow)
					{
					    Snake.direction = 2;
					}
					if (input == ConsoleKey.DownArrow)
					{
                        Snake.direction = 0;
                    }
					if (input == ConsoleKey.LeftArrow)
					{
                        Snake.direction = 1;
                    }
					if (input == ConsoleKey.RightArrow)
					{
                        Snake.direction = 3;
                    }
					if (x < 0)
					{
						x = 0;
						Environment.Exit(0);
					}
					if (y < 0)
					{
						y = 0;
						Environment.Exit(0);
					}
					if (x > 119)
					{
						x = 119;
						Environment.Exit(0);
					}
					if (y > 29)
					{
						y = 29;
						Environment.Exit(0);
					}
				}
				input = Console.ReadKey().Key;
			}
		}
	}
}