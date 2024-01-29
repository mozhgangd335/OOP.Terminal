
using NewTerminal;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Run();
            }
            catch (Exception exception)
            {
               Utility.ShowError(exception.Message);
            }
        }


        static void Run()
        {
            int menu = Utility.GetInt("1: Bus\n" +
                              "2: Travel\n" +
                              "3: Show Travel Lists\n" +
                              "4: Reserve Ticket\n" +
                              "5: Buy Ticket\n" +
                              "6: Cancel Ticket\n" +
                              "7: Travel Report\n" +
                              "8: Exit\n" 
                  
                              );

            switch (menu)
            {
                case 1:
                    {
                        OopTraveling.AddBus();
                        break;
                    }
                    case 2:
                    {
                        OopTraveling.Travel();
                        break;
                    }
                case 3:
                    {
                        OopTraveling.ShowTravels();
                        break;
                    }
                case 4:
                    {
                        OopTraveling.ReserveTickrt();
                        break;
                    }
                case 5:
                    {
                        OopTraveling.BuyTicket();
                        break;
                    }
                case 6:
                    {
                        OopTraveling.CancelTicket();
                        break;
                    }
                case 7:
                    {
                        OopTraveling.Logging();
                        break;
                    }
                case 8:
                    {
                        Environment.Exit(0);
                        break;  
                    }
            }


        }
    }

}