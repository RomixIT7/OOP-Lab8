using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Building> objects = new List<Building>();

        while (true)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Create Building");
            Console.WriteLine("2. Create Apartment Building");
            Console.WriteLine("3. Create Warehouse");
            Console.WriteLine("4. Show Info");
            Console.WriteLine("5. Compare Objects");
            Console.WriteLine("6. Change Building Information");
            Console.WriteLine("7. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        objects.Add(CreateBuilding());
                        break;
                    case 2:
                        objects.Add(CreateApartmentBuilding());
                        break;
                    case 3:
                        objects.Add(CreateWarehouse());
                        break;
                    case 4:
                        ShowInfo(objects);
                        break;
                    case 5:
                        CompareObjects(objects);
                        break;
                    case 6:
                        ChangeBuildingInformation(objects);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine();
        }
    }

    static Building CreateBuilding()
    {
        Console.WriteLine("Enter address:");
        string address = Console.ReadLine();
        Console.WriteLine("Enter wall material:");
        string wallMaterial = Console.ReadLine();
        Console.WriteLine("Enter number of floors:");
        int floors;
        while (!int.TryParse(Console.ReadLine(), out floors))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for floors.");
        }

        return new Building(address, wallMaterial, floors);
    }

    static ApartmentBuilding CreateApartmentBuilding()
    {
        Console.WriteLine("Enter address:");
        string address = Console.ReadLine();
        Console.WriteLine("Enter wall material:");
        string wallMaterial = Console.ReadLine();
        Console.WriteLine("Enter number of floors:");
        int floors;
        while (!int.TryParse(Console.ReadLine(), out floors))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for floors.");
        }
        Console.WriteLine("Enter number of apartments:");
        int apartments;
        while (!int.TryParse(Console.ReadLine(), out apartments))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for apartments.");
        }

        return new ApartmentBuilding(address, wallMaterial, floors, apartments);
    }

    static Warehouse CreateWarehouse()
    {
        Console.WriteLine("Enter address:");
        string address = Console.ReadLine();
        Console.WriteLine("Enter wall material:");
        string wallMaterial = Console.ReadLine();
        Console.WriteLine("Enter number of floors:");
        int floors;
        while (!int.TryParse(Console.ReadLine(), out floors))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for floors.");
        }
        Console.WriteLine("Enter planning type (Open/Closed/Semi-Closed):");
        string planningType = Console.ReadLine();

        return new Warehouse(address, wallMaterial, floors, planningType);
    }

    static void ShowInfo(List<Building> objects)
    {
        foreach (var obj in objects)
        {
            obj.ShowInfo();
            Console.WriteLine();
        }
    }

    static void CompareObjects(List<Building> objects)
    {
        if (objects.Count < 2)
        {
            Console.WriteLine("Create at least two objects for comparison.");
            return;
        }

        Console.WriteLine("Enter index of the first object to compare:");
        int index1;
        while (!int.TryParse(Console.ReadLine(), out index1) || index1 < 0 || index1 >= objects.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid index.");
        }

        Console.WriteLine("Enter index of the second object to compare:");
        int index2;
        while (!int.TryParse(Console.ReadLine(), out index2) || index2 < 0 || index2 >= objects.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid index.");
        }

        Building obj1 = objects[index1];
        Building obj2 = objects[index2];

        if (obj1 != null && obj2 != null)
        {
            Console.WriteLine($"Comparing objects {index1} and {index2}:");

            if (obj1.Equals(obj2))
            {
                Console.WriteLine("Objects are equal.");
            }
            else
            {
                Console.WriteLine("Objects are not equal.");
            }
        }
        else
        {
            Console.WriteLine("Invalid object indices.");
        }
    }

    static void ChangeBuildingInformation(List<Building> objects)
    {
        Console.WriteLine("Enter the address of the building to change:");
        string address = Console.ReadLine();

        Building buildingToChange = objects.FirstOrDefault(obj => obj != null && obj.Address == address);

        if (buildingToChange != null)
        {
            buildingToChange.ChangeInformation();
            Console.WriteLine("Building information changed.");
        }
        else
        {
            Console.WriteLine("Building not found.");
        }
    }
}
