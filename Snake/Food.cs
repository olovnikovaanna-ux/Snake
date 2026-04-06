namespace Snake
{
    
    public class Food
    {


        private static readonly Random _random = new Random();

        public Point? Position { get; set; }
        public int PointsValue { get; set; } = 10;
        public bool IsSuccess { get; set; }
        public Food(Point? position, bool isSuccess = true)
        {
            Position = position;
            IsSuccess = isSuccess;
        }

        public static Food CreateInitialFood(PlayingField field, Snake snake)
        {
            Point? position = GenerateRandomFoodPosition(field, snake);

            return new Food(
                position: position,
                isSuccess: position != null
            );
        }

        private static Point? GenerateRandomFoodPosition(PlayingField field, Snake snake)
        {
            int maxAttempts = 1000; // ограничиваем максимальное количество попыток

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                // Еда должна появляться между рамками                
                int x = _random.Next(field.Left + 1, field.Right);   // координата X (между рамками)
                int y = _random.Next(field.Top + 1, field.Bottom);   // координата Y (между рамками)
                Point candidateFood = new Point(x, y);  

                // Проверяем, не занята ли эта клетка змейкой
                if (!snake.Contains(candidateFood))
                {
                    return candidateFood; // нашли свободное место!
                }
            }

            // Если не нашли свободное место после всех попыток
            return null;
        }        
    }
}