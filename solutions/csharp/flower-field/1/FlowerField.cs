public static class FlowerField
{
    public static string[] Annotate(string[] input)
    {
        int rows = input.Length;
        if (rows == 0) return input;

        int cols = input[0].Length;
        char[][] result = new char[rows][];

        for (int r = 0; r < rows; r++)
        {
            result[r] = input[r].ToCharArray();

            for (int c = 0; c < cols; c++)
            {
                if (input[r][c] == '*')
                {
                    continue; // не чіпаємо квітку
                }

                int count = CountAdjacentFlowers(input, r, c);

                if (count > 0)
                {
                    result[r][c] = (char)('0' + count);
                }
                else
                {
                    result[r][c] = ' ';
                }
            }
        }

        // Перетворюємо назад у string[]
        string[] output = new string[rows];
        for (int i = 0; i < rows; i++)
        {
            output[i] = new string(result[i]);
        }

        return output;
    }

    private static int CountAdjacentFlowers(string[] board, int r, int c)
    {
        int rows = board.Length;
        int cols = board[0].Length;
        int count = 0;

        // 8 напрямків
        int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int i = 0; i < 8; i++)
        {
            int nr = r + dr[i];
            int nc = c + dc[i];

            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
            {
                if (board[nr][nc] == '*')
                {
                    count++;
                }
            }
        }

        return count;
    }
}