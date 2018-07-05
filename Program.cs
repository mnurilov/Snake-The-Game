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
            Console.Clear();
            for (int i = 0; i < snake.Count; i++)
            {
                Console.SetCursorPosition(snake[i].x, snake[i].y);
                Console.Write(snake[i].display);
            }
        }
        public void IncreaseSize()
        {
            SnakePart body = new SnakePart();
            snake.Add(body);
        }
        public void DeadSnake()
        {

        }
    }
    class Apple
    {
        public int x;
        public int y;
        public char display = '$';
        public void SpawnApple(Random rand)
        {
            x = rand.Next(1, 30);
            y = rand.Next(1, 30);
        }
        public void DisplayApple()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(display);
        }
        public void AppleEaten(Random rand)
        {
            SpawnApple(rand);
        }
    }

	class MainClass
	{
        static void Collision(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                Environment.Exit(0);
            }
        }
        static void AppleCollision(int x1, int y1, int x2, int y2, Snake snake, Apple apple, Random
            rand)
        {
            if (x1 == x2 && y1 == y2)
            {
                snake.IncreaseSize();
                apple.SpawnApple(rand);
            }
        }
        static void SetScreen()
        {
            Console.SetWindowSize(30, 30);
            Console.SetBufferSize(30, 30);
        }
        static void Music() 
        {
            while (true) 
            {
                int number = 0;
                for (int i = 0; i < 2; i++)
                {
                    Console.Beep(700, 300);
                    Console.Beep(1200, 300);
                    Console.Beep(1450, 300);
                }
                Console.Beep(700, 300); //F
                Console.Beep(1200, 300);//A
                Console.Beep(1450, 300);//B
                Console.Beep(2200, 300);//E
                Console.Beep(1950, 300);//D
                Console.Beep(1450, 300);//B
                                        // Console.Beep(1700, 300);//C
                                        // Console.Beep(1450, 300);//B
                                        // Console.Beep(950, 300);//G
                                        // Console.Beep(450, 300);//E
                                        // Console.Beep(200, 300);//D
                                        // Console.Beep(450, 300);//E
                                        // Console.Beep(950, 300);//G
                                        //Console.Beep(450, 300);//E

                for (int i = 0; i < 3; i++)
                {
                    Console.Beep(100, 200);
                    Console.Beep(300, 300);
                    Console.Beep(700, 100);
                    Console.Beep(1500, 300);
                    Console.Beep(1300, 100);
                    Console.Beep(700, 200);

                }
                if (number % 3 == 0) 
                {
                    Console.Beep(200, 300);
                    Console.Beep(700, 300);
                }
                number++;
            }
        }
        public static void Main(string[] args)
		{
            var thread = new Thread(Music);
            thread.Start();
            SetScreen();
			Console.CursorVisible = false;
			int x = 10;
			int y = 10;
            ConsoleKey newinput;
			ConsoleKey input;
            ConsoleKey previousinput;
            previousinput = ConsoleKey.UpArrow;
			input = ConsoleKey.RightArrow;
            Snake Snake = new Snake();
            Apple Apple = new Apple();
            Random rand = new Random();
            Snake.SpawnSnake(rand);
            Apple.SpawnApple(rand);
            Snake.IncreaseSize();
            Snake.IncreaseSize();
            Snake.UpdateSnake();

			while (true)
			{
				while (!Console.KeyAvailable)
				{
					if (input == ConsoleKey.UpArrow && previousinput != ConsoleKey.DownArrow)
					{
					    Snake.direction = 2;
					}
					if (input == ConsoleKey.DownArrow && previousinput != ConsoleKey.UpArrow)
					{
                        Snake.direction = 0;
                    }
					if (input == ConsoleKey.LeftArrow && previousinput != ConsoleKey.RightArrow)
					{
                        Snake.direction = 1;
                    }
					if (input == ConsoleKey.RightArrow && previousinput != ConsoleKey.LeftArrow)
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
                    Thread.Sleep(150);
                    Snake.UpdateSnake();
                    Snake.DisplaySnake();
                    Apple.DisplayApple();
                    for (int i = 1; i < Snake.snake.Count; i++)
                    {
                        Collision(Snake.snake[0].x, Snake.snake[0].y, Snake.snake[i].x,
                            Snake.snake[i].y);
                    }
                    AppleCollision(Snake.snake[0].x, Snake.snake[0].y, Apple.x, Apple.y, Snake,
                        Apple, rand);
                }
                newinput = Console.ReadKey().Key;
                if (newinput == input)
                {
                
                }
                else 
                {
                    previousinput = input;
                    input = newinput;
                }
			}
		}
	}
}