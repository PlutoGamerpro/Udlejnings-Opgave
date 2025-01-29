using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.MenuDisplayer;
using Udlejnings.Backend.SqlCrud.DeleteOperation;
using Udlejnings.Backend.SqlCrud.GetOperation;


namespace Udlejnings.Backend.EditingLH;

public class DeleteSommerhusLejlhed
{
    public void DeleteSommerhusMenu()
    {
        GetFromDatabase getFromDatabase = new GetFromDatabase();
        DeleteOperation deleteOperation = new DeleteOperation();
        Brugermenu brugermenu = new Brugermenu();

        while (true) // Start a loop to allow repeated attempts until 'Q' is pressed
        {
            getFromDatabase.FetchSommerhuseFromDatabase();

            Console.Write("Enter the ID of the Sommerhus to delete or press 'Q' to return to the main menu: ");
            string userInput = Console.ReadLine();

            // If the user presses 'Q', exit the loop and return to the main menu
            if (userInput.ToUpper() == "Q")
            {
                Console.WriteLine("Returning to the main menu.");
                brugermenu.AdminOperationManager(getFromDatabase);
                break; // Break the loop and return to the main menu
            }

            int sommerhusId;
            if (!int.TryParse(userInput, out sommerhusId))
            {
                Console.WriteLine("Invalid ID. Please try again.");
                continue; // If input is invalid, prompt again
            }

            // Attempt to delete the Sommerhus
            deleteOperation.DeleteSommerhus(sommerhusId);

            Console.Write("Press any key to continue");
            string continueInput = Console.ReadLine();

            // Check if the user wants to quit after the operation
            
                
            }
        }
    

    public void DeleteLejlhedMenu()
    {
        GetFromDatabase getFromDatabase = new GetFromDatabase();
        DeleteOperation deleteOperation = new DeleteOperation();
        Brugermenu brugermenu = new Brugermenu();

        while (true) // Start a loop to allow repeated attempts until 'Q' is pressed
        {
            getFromDatabase.FetchLejlhederFromDatabase();

            Console.Write("Enter the ID of the Lejlhed to delete or press 'Q' to return to the main menu: ");
            string userInput = Console.ReadLine();

            // If the user presses 'Q', exit the loop and return to the main menu
            if (userInput.ToUpper() == "Q")
            {
                Console.WriteLine("Returning to the main menu.");
                brugermenu.AdminOperationManager(getFromDatabase);
                break; // Break the loop and return to the main menu
            }

            int lejlhedId;
            if (!int.TryParse(userInput, out lejlhedId))
            {
                Console.WriteLine("Invalid ID. Please try again.");
                brugermenu.AdminOperationManager(getFromDatabase);
                continue; // If input is invalid, prompt again
            }

            // Attempt to delete the Lejlhed
            deleteOperation.DeleteLejlhed(lejlhedId);

            Console.Write("Press any key to Continue.");
            string continueInput = Console.ReadLine();

            // Check if the user wants to quit after the operation
            
        }
    }
}
