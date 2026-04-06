namespace Snake
{
    public class Header
    {

        public int Score { get; set; } = 0;

        //public int Level { get; set; } = 1;

        //public int Lives { get; set; } = 1;

        public int Height => GetLines().Length;

        public string[] GetLines()
        {
            var lines = new List<string>();

            // Счёт всегда отображается
            lines.Add($"Счёт: {Score}");

            //// Уровень отображается, если > 1
            //if (Level > 1)
            //    lines.Add($"Уровень: {Level}");

            //// Жизни отображаются, если > 1
            //if (Lives > 1)
            //    lines.Add($"Жизни: {Lives}");

            return lines.ToArray();
        }
    }
}