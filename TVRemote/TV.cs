using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVRemote.Utils;

namespace TVRemote
{
    internal class TV
    {
        public void instantiate()
        {

            Remote decoder = new Remote();
            String decodedCommand = "TV is powered off.";

            // This is the method that gets input and decodes and shows TV commands.
            void showTV()
            {
                Console.Write(Constants.TVPart1);

                for (int i = 0; i < 40; ++i)
                {
                    Console.Write("_");
                }

                Console.Write(Constants.TVPart1);

                Console.WriteLine();

                //Write text
                Console.Write(Constants.TVPart1 + " ");
                int spaceToAddAfter = 40 - decodedCommand.Length;
                Console.Write(decodedCommand);
                if (spaceToAddAfter > 2)
                    for (int i = 0; i < spaceToAddAfter - 2; ++i)
                    {
                        Console.Write(" ");
                    }

                Console.Write(" " + Constants.TVPart1);

                Console.WriteLine();

                Console.Write(Constants.TVPart1);

                for (int i = 0; i < 40; ++i)
                {
                    Console.Write("_");
                }

                Console.Write(Constants.TVPart1);

                Console.WriteLine();


                Console.WriteLine();

                Console.Write("\r{0} ", "Please input command (q to quit): ");

                String str = Console.ReadLine();

                if (str != null && str != "q")
                {
                    decodedCommand = decoder.decodeInputs(str);

                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine(" ");

                    ClearCurrentConsoleLine();

                    showTV();
                }

            }


            //main method call for first time in main loop:
            showTV();

            //This method is to clear screen.
            static void ClearCurrentConsoleLine()
            {
                ScreenClear.ClearCurrentConsoleLine();
            }
        }
    }
}
