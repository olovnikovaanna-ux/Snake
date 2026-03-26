using System.Drawing;

namespace Snake
{
   
    public class ConsoleRenderer : IGameRenderer
    {
        public void Clear()
        {
            Console.Clear();
        }


        
        public void Render(GameState state)
        {
            // Логика отрисовки кадра в консоли:

            // Нарисовать игровое поле
            RenderField(state.Field);
            // Нарисовать змейку
            RenderSnake(state.Snake);
            // Нарисовать еду
            RenderFood(state.Food);

        }

        private void RenderField(PlayingField field)
        {
            //TO DO:логика отрисовки поля

            int width = field.Width;
            int heidth = field.Height;
            int offset = 2;

            for (int y = offset; y < heidth + offset; y++)
            {
                Console.SetCursorPosition(offset, y);
                Console.Write("X");
            }

            for (int x = offset; x < width + offset; x++)
            {
                Console.SetCursorPosition(x, offset);
                Console.Write("X");
            }

            for (int x = offset; x <= width + offset; x++)
            {
                Console.SetCursorPosition(x, heidth + offset);
                Console.Write("X");
            }

            for (int y = offset; y < heidth + offset; y++)
            {

                Console.SetCursorPosition(width + offset, y);
                Console.Write("X");
            }

        }
        
        private void RenderSnake(Snake snake)
        {
            //TO DO: логика отрисовки змейки

            for (int i = snake.Body.Count - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(snake.Body[i].X, snake.Body[i].Y);

                if (snake.Body[i].X == 
                    snake.Head.X && snake.Body[i].Y == snake.Head.Y)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("@");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("O");
                    Console.ResetColor();
                }
                
                
                
            }           
            
        }

        public void RenderFood(Food food)
        {
            //TO DO: логика отрисовки еды
            Console.SetCursorPosition(food.Position.X, food.Position.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ResetColor();
        }

    }
}