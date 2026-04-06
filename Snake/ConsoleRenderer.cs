using System.Drawing;

namespace Snake
{
   
    public class ConsoleRenderer : IGameRenderer
    {
        public void Clear()
        {
            Console.Clear();
        }

        // Символы отрисовки
        
        // Символ рамки игрового поля
        private const char BorderChar = '#';
        
        // Символ головы змейки        
        private const char SnakeHead = '@';
       
        // Символ тела змейки       
        private const char SnakeBody = 'O';
       
        // Символ еды        
        private const char FoodSymbol = '*';

        // Цвета сообщений
        
        // Цвет сообщения о проигрыше        
        private const ConsoleColor GameOverColor = ConsoleColor.Red;

        
        // Цвет сообщения о победе        
        private const ConsoleColor GameWinColor = ConsoleColor.Green;

        
        // Цвет сообщения о паузе        
        private const ConsoleColor PauseColor = ConsoleColor.Yellow;

        
        // Цвет сообщения по умолчанию       
        private const ConsoleColor DefaultMessageColor = ConsoleColor.White;



        public void Render(GameState state)
        {
            int headerHeight = state.Header.Height;

            // Отрисовать служебную информацию
            DrawHeader(state.Header);

            // Нарисовать игровое поле
            DrawField(state.Field, headerHeight);

            // Нарисовать змейку
            DrawSnake(state.Snake, state.Field, headerHeight);

            // Нарисовать еду
            DrawFood(state.Food, state.Field, headerHeight);

            // Если игра проиграна - показать сообщение о проигрыше
            if (state.IsGameOver)
            {
                DrawGameOver(state.Field, headerHeight);
            }

            // Если игра выиграна - показать сообщение о победе
            if (state.IsWin)
            {
                DrawGameWin(state.Field, headerHeight);
            }

            // Если пауза - показать сообщение о паузе
            if (state.IsPaused)
            {
                DrawPause(state.Field, headerHeight);
            }
        }

        private static void DrawHeader(Header header)
        {
            string[] lines = header.GetLines();

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(lines[i]);
            }
        }

        private static void DrawField(PlayingField field, int headerHeight)
        {
            int lastRow = field.Height - 1;   // последний индекс строки (ширина - 1)
            int lastCol = field.Width - 1;    // последний индекс столбца (высота - 1)

            for (int y = 0; y <= lastRow; y++)
            {
                Console.SetCursorPosition(0, y + headerHeight);
                for (int x = 0; x <= lastCol; x++)
                {
                    bool isBorder = (y == 0) || (y == lastRow) || (x == 0) || (x == lastCol);

                    Console.Write(isBorder ? BorderChar : ' ');
                }
            }
        }

        private static void DrawSnake(Snake snake, PlayingField field, int headerHeight)
        {
            int lastSegmentIndex = snake.Body.Count - 1;  // индекс последнего сегмента (голова)

            for (int i = 0; i <= lastSegmentIndex; i++)
            {
                Point segment = snake.Body[i];

                // Пропускаем сегменты за границами поля (рисуем только между рамками)
                if (!field.IsInside(segment))
                    continue;

                char symbol = (i == lastSegmentIndex) ? SnakeHead : SnakeBody;

                Console.SetCursorPosition(segment.X, segment.Y + headerHeight);
                Console.Write(symbol);
            }
        }

        private static void DrawFood(Food food, PlayingField field, int headerHeight)
        {
            if (!food.IsSuccess || food.Position == null)
                return;

            Point pos = food.Position;

            // Пропускаем еду за границами поля (рисуем только между рамками)
            if (!field.IsInside(pos))
                return;

            Console.SetCursorPosition(pos.X, pos.Y + headerHeight);
            Console.Write(FoodSymbol);
        }

        private static void DrawGameOver(PlayingField field, int headerHeight)
        {
            string[] message = ServiseMessange.GetGameOverMessange();

            DrawCenteredMessage(field, message, headerHeight, GameOverColor);
        }

        private static void DrawGameWin(PlayingField field, int headerHeight)
        {
            string[] message = ServiseMessange.GetGameWinMessange();

            DrawCenteredMessage(field, message, headerHeight, GameWinColor);
        }

        private static void DrawPause(PlayingField field, int headerHeight)
        {
            string[] message = ServiseMessange.GetPause();

            DrawCenteredMessage(field, message, headerHeight, PauseColor);
        }

        private static void DrawCenteredMessage(PlayingField field, string[] lines, int headerHeight, ConsoleColor color = DefaultMessageColor)
        {
            int messageWidth = PositionCalculator.GetMessageWidth(lines);
            int messageHeight = PositionCalculator.GetMessageHeight(lines);

            // Передаём высоту поля с учётом заголовка для правильного центрирования
            Point startPosition = PositionCalculator.CalculateCenteredMessagePosition(
                field.Width,
                field.Height + headerHeight,
                messageWidth,
                messageHeight);

            // Проверяем, что позиция в пределах поля
            if (startPosition.X < 0 || startPosition.Y < headerHeight)
                return;

            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            for (int i = 0; i < lines.Length; i++)
            {
                int y = startPosition.Y + i;
                // Проверяем, что строка не выходит за границы поля
                if (y >= headerHeight && y < headerHeight + field.Height)
                {
                    Console.SetCursorPosition(startPosition.X, y);
                    Console.Write(lines[i]);
                }
            }

            Console.ForegroundColor = originalColor;

        }

    }
}