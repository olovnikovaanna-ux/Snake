namespace Snake
{
    public class PlayingField
    {
        public int Width { get; }
        public int Height { get; }

        public PlayingField(int width = 40, int height = 20)
        {
            Width = width;
            Height = height;
        }
    }
}