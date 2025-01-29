using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udlejnings.Backend.SqlCrud.DeleteOperation;


namespace Udlejnings.Backend.EditingLH;

public class DeleteSommerhusLejlhed
{
    public void DeleteSommerhusMenu()
    {
        DeleteOperation deleteOperation = new DeleteOperation();

        Console.WriteLine("Enter the ID of the Sommerhus to delete: ");
        int sommerhusId = int.Parse(Console.ReadLine());

        deleteOperation.DeleteSommerhus(sommerhusId);
    }

    public void DeleteLejlhedMenu()
    {

        DeleteOperation deleteOperation = new DeleteOperation();

        Console.Write("Enter the ID of the Lejlhed to delete: ");
        int lejlhedId = int.Parse(Console.ReadLine());

       deleteOperation.DeleteLejlhed(lejlhedId);
    }
}
