namespace Snake
{
    public class PlayingField
    {        


            public const int MinWidth = 28;
            public const int MinHeight = 12;

            public int Width { get; }
            public int Height { get; }
            public int Left => 0;
            public int Right => Width - 1;
            public int Top => 0;
            public int Bottom => Height - 1;

            public bool IsBorder(Point point)
            {
                return point.X == Left || point.X == Right ||
                       point.Y == Top || point.Y == Bottom;
            }

            public bool IsInside(Point point)
            {
                return point.X > Left && point.X < Right &&
                       point.Y > Top && point.Y < Bottom;
            }

            public bool IsWithinBounds(Point point)
            {
                return point.X >= Left && point.X <= Right &&
                       point.Y >= Top && point.Y <= Bottom;
            }

            public PlayingField(int width = 30, int height = 15)
            {
                if (width < MinWidth)
                    throw new ArgumentOutOfRangeException(nameof(width), $"Минимальная ширина поля: {MinWidth}");

                if (height < MinHeight)
                    throw new ArgumentOutOfRangeException(nameof(height), $"Минимальная высота поля: {MinHeight}");

                Width = width;
                Height = height;
            }







            //public int Width { get; }
            //public int Height { get; }

            //public PlayingField(int width = 40, int height = 20)
            //{
            //    Width = width;
            //    Height = height;
            //}
        }
}