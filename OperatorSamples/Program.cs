
using OperatorSamples.Classes;
using OperatorSamples.Models;

namespace OperatorSamples;
internal partial class Program
{
    static void Main(string[] args)
    {

        FilePathExample();
        Console.ReadLine();
    }

    private static void FilePathExample()
    {

        PathOperations pathOps = new();
        pathOps.PathExists(DirectoryOperations.GetSolutionInfo().FullName);
        pathOps.PathExists(new FilePath(DirectoryOperations.GetSolutionInfo().FullName));
        pathOps.PrintFolderContents(DirectoryOperations.GetSolutionInfo().FullName);
        pathOps.PrintFolderContents(new FilePath(DirectoryOperations.GetSolutionInfo().FullName));
        
    }



    private static void TemperatureExample()
    {
        Celsius celsius1 = new(10);
        Fahrenheit fahrenheit = celsius1;
        Celsius celsius2 = fahrenheit;
    }

    private static void EmployeeExample()
    {
        Contractor contractor = new(id: 1, firstName: "Mary", lastName: "Jones", gender: Gender.Female, hourlyRate: 50);
        Employee employee = contractor;
    }

    private static void ProductsExample()
    {
        List<M1.Product> products1 =
        [
            new M1.Product { ProductId = 1, ProductName = "Apples", UnitPrice = 12.99m, UnitsInStock = 123 },
            new M1.Product { ProductId = 2, ProductName = "Pears", UnitPrice = 3.99m, UnitsInStock = 3 }
        ];

        List<M2.Product> products2 =
        [
            new M2.Product { ProductId = 1, ProductName = "Apples", UnitPrice = 12.99m, UnitsInStock = 123 },
            new M2.Product { ProductId = 2, ProductName = "Pears", UnitPrice = 3.99m, UnitsInStock = 3 }
        ];


        List<M3.Product> products3 =
        [
            new M3.Product { ProductId = 1, ProductName = "Apples", UnitPrice = 12.99m, UnitsInStock = 123 },
            new M3.Product { ProductId = 2, ProductName = "Pears", UnitPrice = 3.99m, UnitsInStock = 3 }
        ];

        // explicit
        List<M1.ProductItem> list1 = products1.Select(pc => (M1.ProductItem)pc).ToList();
        // implicit
        List<M2.ProductItem> list2 = products2.Select<M2.Product, M2.ProductItem>(p => p).ToList();
        // conventional 
        List<M3.ProductItem> list3 = products3.Select(p => new M3.ProductItem()
            { ProductId = p.ProductId, ProductName = p.ProductName }).ToList();


        list1.ForEach(x => Console.WriteLine($"{x.ProductId,-3}{x.ProductName,-10}{x.UnitPrice:C}"));
        Console.WriteLine();
        list2.ForEach(x => Console.WriteLine($"{x.ProductId,-3}{x.ProductName,-10}"));
        Console.WriteLine();
        list3.ForEach(x => Console.WriteLine($"{x.ProductId,-3}{x.ProductName,-10}"));
    }
}