using System.Reflection.PortableExecutable;

namespace Snake
{
    public class GameState
    {
        // Управляющие флаги
        public bool IsExit { get; set; } = false;       // флаг выхода из игры
        public bool IsGameOver { get; set; } = false;   // флаг проигрыша
        public bool IsPaused { get; set; } = false;   // флаг паузы
        public bool IsWin { get; set; } = false;     // флаг победы
        public bool IsRestartRequested { get; set; } = false; // флаг перезапуска
        // Настройки
        public int Fps { get; set; } = 100;     // задержка между кадрами (мс)

        // Игровые данные
        public Header Header { get; } = new Header();
        public int Score { get; set; } = 0;     // игровой счет
        public Direction CurrentDirection { get; set; } = Direction.Right; // текущее направление

        // Компоненты игры
        public PlayingField Field { get; }  // объект игрового поля
        public Snake Snake { get; }         // объект змейки
        public Food Food { get; }           // объект еды


        public GameState()
        {
            // Создаём поле
            Field = new PlayingField();

            
            Point headPosition = PositionCalculator.CalculateCenteredHeadPosition(
                fieldWidth: Field.Width,    
                fieldHeight: Field.Height,  
                snakeLength: 3,            
                direction: Direction.Right  
            );

            // Создаём змейку с центрированным телом на игровом поле
            Snake = new Snake(
                headPosition: headPosition,
                direction: Direction.Right,
                snakeLength: 3
            );

            // Создание еды с проверкой свободного места
            Food = Food.CreateInitialFood(Field, Snake);

            // Проверяем, удалось ли создать еду
            if (!Food.IsSuccess)
            {
                // Если нет свободного места - игру нельзя начать
                throw new InvalidOperationException(
                    "Нет свободного места для еды! Невозможно начать игру."
                );
            }
        }        
    }
}