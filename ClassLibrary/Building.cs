using System;

public class Building
{
    public string Address { get; set; }
    public string WallMaterial { get; set; }
    public int Floors { get; set; }

    public Building()
    {
        // Конструктор за замовчуванням
    }

    public Building(string address, string wallMaterial, int floors)
    {
        Address = address;
        WallMaterial = wallMaterial;
        Floors = floors;
    }

    // Конструктор копіювання
    public Building(Building other)
    {
        Address = other.Address;
        WallMaterial = other.WallMaterial;
        Floors = other.Floors;
    }

    // Методи зміни типу матеріалу стін та кількості поверхів
    public virtual void ChangeWallMaterial(string newMaterial)
    {
        WallMaterial = newMaterial;
    }

    public virtual void ChangeFloors(int newFloors)
    {
        Floors = newFloors;
    }

    // Віртуальний метод для виведення інформації
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Address: {Address}, Wall Material: {WallMaterial}, Floors: {Floors}");
    }

    // Метод порівняння об'єктів
    public bool Equals(Building other)
    {
        if (other == null)
            return false;

        return Address == other.Address &&
               WallMaterial == other.WallMaterial &&
               Floors == other.Floors;
    }
    public virtual void ChangeInformation()
    {
        Console.WriteLine("Enter new address:");
        Address = Console.ReadLine();
        Console.WriteLine("Enter new wall material:");
        WallMaterial = Console.ReadLine();
        Console.WriteLine("Enter new number of floors:");
        int newFloors;
        while (!int.TryParse(Console.ReadLine(), out newFloors))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for floors.");
        }
        Floors = newFloors;
        Console.WriteLine("Building information updated.");
    }

}