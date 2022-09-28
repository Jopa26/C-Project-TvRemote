
namespace TVRemote.Utils
{
    internal class ScreenClear
    {
        //This method is to clear screen.
        public static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, 0);

            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);

            for (int i = 0; i < 8; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
