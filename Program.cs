using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
	class Snake 
	{
		public List<char> snake = new List<char>();
		public void SpawnSnake()
		{
			snake.Add('O');
			snake.Add('O');
			snake.Add('O');
		}
		public void DisplaySnake()
		{

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
		public void SpawnApple()
		{

		}
		public void DisplayApple()
		{

		}
		public void AppleEaten()
		{

		}
	}
    class Program
    {
		static void Collision(int x1, int y1, int x2, int y2)
		{
			if (x1 == x2 && y1 == y2)
			{
				
			}
		}
		static void SetScreen()
		{
			Console.SetWindowSize(30,30);
			Console.SetBufferSize(30,30);
		}
        static void Main(string[] args)
        {
			SetScreen();
            int x = 0;
            int y = 0;
            ConsoleKeyInfo input;
            Apple Apple = new Apple();
		
            while (true)
            {

                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write('$');
				Apple.DisplayApple();
                input = Console.ReadKey();

                if (input.Key == ConsoleKey.UpArrow)
                {
                    y--;
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    y++;
                }
                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    x--;
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    x++;
                }

                if (x < 0)
                {
                    x = 0;
                }
                if (y < 0)
                {
                    y = 0;
                }
                if (x > 119)
                {
                    x = 119;
                }
                if (y > 29)
                {
                    y = 29;
                }
            
            }
        }
    }
}