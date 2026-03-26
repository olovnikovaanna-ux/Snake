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
            int Heidth = field.Height;


        }
        
        private void RenderSnake(Snake snake)
        {
            //TO DO: логика отрисовки змейки

            for (int i = 0; i < snake.Body.Count; i++)
            {
                Console.SetCursorPosition(snake.Body[i].X, snake.Body[i].Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ResetColor();
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