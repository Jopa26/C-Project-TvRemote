// See https://aka.ms/new-console-template for more information
//This is the main program where it starts.

//First we get input for the TV model.
using TVRemote.Utils;

void getTVModelInput()
{

    Console.WriteLine("TV models are: ");
    foreach (string name in Enum.GetNames(typeof(TVModelsProviderEnum.TVModels)))
    {
        Console.Write(" [ " + name + " ]");
    }

    Console.WriteLine();

    Console.WriteLine("Commands:");

    foreach (string name in Enum.GetNames(typeof(TVModelsProviderEnum.TVModelsShort)))
    {
        Console.Write(" [ " + name + " ]");
    }

    Console.WriteLine();
    Console.Write("Please enter TV model: ");

}

void TVLogicStarter() {
    try
    {
        String tvModel = Console.ReadLine();

        if (tvModel != null || !String.IsNullOrEmpty(tvModel))
        {

            ScreenClear.ClearCurrentConsoleLine();

            bool exists = Enum.IsDefined(typeof(TVModelsProviderEnum.TVModelsShort), tvModel);
            if (exists)
            {

                Console.WriteLine("You selected model: " + tvModel);
                Console.WriteLine();


                //..Now that we have a TV model, we start its class.

                //We create the TV class and start
                TVRemote.TV tV = new TVRemote.TV();
                tV.instantiate();

            }
            else
            {
                Console.WriteLine("You selected invalid model. Try again? (Y\\N)");
                ConsoleKeyInfo c = Console.ReadKey();
                string s = c.KeyChar.ToString();
                Console.WriteLine();

                if (s.ToLower() == "y")
                {
                    getTVModelInput();
                    TVLogicStarter();
                }

            }

        }



    }
    catch
    {

    }

}



//on main loop, we start model input logic. It will start other logics as requeird.
getTVModelInput();
TVLogicStarter();