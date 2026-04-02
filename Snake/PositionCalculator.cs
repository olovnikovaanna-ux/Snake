namespace Snake
{
    public static class PositionCalculator
    {
        public static Point CalculateCenteredHeadPosition(
            int fieldWidth,         // ширина игрового поля
            int fieldHeight,        // высота игрового поля
            int snakeLength,        // длина змейки
            Direction direction     // направление движения
        )

        {
            int availableWidth = fieldWidth - 2;   // от Left+1 до Right-1
            int availableHeight = fieldHeight - 2; // от Top+1 до Bottom-1

            // Проверка: помещается ли змейка в поле по ширине
            if ((direction == Direction.Right || direction == Direction.Left) && snakeLength > fieldWidth)
                throw new ArgumentException($"Змейка длиной {snakeLength} не помещается в поле шириной {fieldWidth}");

            // Проверка: помещается ли змейка в поле по высоте
            if((direction == Direction.Up || direction == Direction.Down) && snakeLength > fieldHeight)
                throw new ArgumentException($"Змейка длиной {snakeLength} не помещается в поле высотой {fieldHeight}");

            // Центр поля
            int centerX = fieldWidth / 2;
            int centerY = fieldHeight / 2;

            Point headPosition; // координаты головы

            // Рассчитываем позицию головы в зависимости от направления
           
            switch (direction)
            {
                case Direction.Right:
                    // При движении вправо: голова в центре, хвост слева                    
                    int headXRight = Math.Max(snakeLength, centerX);                   
                    headXRight = Math.Min(headXRight, fieldWidth - 2);
                    headPosition = new Point(x: headXRight, y: centerY);
                    break;

                case Direction.Left:
                    // При движении влево: голова в центре, хвост справа
                    int headXLeft = Math.Min(fieldWidth - 1 - snakeLength, centerX);
                    headXLeft = Math.Max(headXLeft, 1);
                    headPosition = new Point(x: headXLeft, y: centerY);
                    break;

                case Direction.Down:
                    // При движении вниз: голова в центре, хвост сверху
                    int headYDown = Math.Max(snakeLength, centerY);
                    headYDown = Math.Min(headYDown, fieldHeight - 2);
                    headPosition = new Point(x: centerX, y: headYDown);
                    break;

                case Direction.Up:
                    // При движении вверх: голова в центре, хвост снизу
                    int headYUp = Math.Min(fieldHeight - 1 - snakeLength, centerY);
                    headYUp = Math.Max(headYUp, 1);
                    headPosition = new Point(x: centerX, y: headYUp);
                    break;

                default:
                    throw new ArgumentException($"Неизвестное направление: {direction}");
            }

            return headPosition;
        }

       
        // Проверяет, помещается ли змейка в поле при заданном направлении.
        
        public static bool CanPlaceSnake(
            int fieldWidth,         
            int fieldHeight,       
            int snakeLength,        
            Direction direction     
        )
        {
            try
            {
                CalculateCenteredHeadPosition(
                    fieldWidth,  
                    fieldHeight, 
                    snakeLength, 
                    direction    
                );
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

       
        // Рассчитывает позицию для центрирования сообщения на игровом поле.
        
        public static Point CalculateCenteredMessagePosition(
            int fieldWidth,
            int fieldHeight,
            int messageWidth,
            int messageHeight)
        {
            int startX = (fieldWidth - messageWidth) / 2;
            int startY = (fieldHeight - messageHeight) / 2;

            return new Point(startX, startY);
        }

       
        // Вычисляет максимальную ширину сообщения (длину самой длинной строки).
        
        public static int GetMessageWidth(string[] lines)
        {
            int maxWidth = 0;
            foreach (string line in lines)
            {
                if (line.Length > maxWidth)
                {
                    maxWidth = line.Length;
                }
            }
            return maxWidth;
        }

        
        // Вычисляет высоту сообщения (количество строк).
        
        public static int GetMessageHeight(string[] lines)
        {
            return lines.Length;
        }



            //    // Половина длины змейки (для центрирования)
            //    int halfLength = snakeLength / 2;

            //    Point headPosition; // координаты головы

            //    // Рассчитываем позицию головы в зависимости от направления
            //    switch(direction)
            //    {
            //        case Direction.Right:
            //            // При движении вправо голова должна быть правее центра на половину длины
            //            headPosition = new Point(
            //                x: centerX + halfLength,
            //                y: centerY
            //            );
            //            break;

            //        case Direction.Left:
            //            // При движении влево голова должна быть левее центра на половину длины
            //            headPosition = new Point(
            //                x: centerX - halfLength,
            //                y: centerY
            //            );
            //            break;

            //        case Direction.Down:
            //            // При движении вниз голова должна быть ниже центра на половину длины
            //            headPosition = new Point(
            //                x: centerX,
            //                y: centerY + halfLength
            //            );
            //            break;

            //        case Direction.Up:
            //            // При движении вверх голова должна быть выше центра на половину длины
            //            headPosition = new Point(
            //                x: centerX,
            //                y: centerY - halfLength
            //            );
            //            break;

            //        default:
            //            throw new ArgumentException($"Неизвестное направление: {direction}");
            //    }

            //    return headPosition;
            //}

            //public static bool CanPlaceSnake(
            //    int fieldWidth,         // ширина игрового поля
            //    int fieldHeight,        // высота игрового поля
            //    int snakeLength,        // длина змейки
            //    Direction direction     // направление движения
            //)
            //{
            //    try
            //    {
            //        CalculateCenteredHeadPosition(
            //            fieldWidth,   // ширина игрового поля
            //            fieldHeight,  // высота игрового поля
            //            snakeLength,  // длина змейки
            //            direction     // направление движения
            //        );
            //        return true;
            //    }
            //    catch(ArgumentException)
            //    {
            //        return false;
            //    }
        
    }
}