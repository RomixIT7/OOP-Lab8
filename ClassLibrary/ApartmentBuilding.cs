public class ApartmentBuilding : Building
{
    public int NumberOfApartments { get; set; }

    public ApartmentBuilding()
    {
        // Конструктор за замовчуванням
    }

    public ApartmentBuilding(string address, string wallMaterial, int floors, int numberOfApartments)
        : base(address, wallMaterial, floors)
    {
        NumberOfApartments = numberOfApartments;
    }

    // Конструктор копіювання
    public ApartmentBuilding(ApartmentBuilding other)
        : base(other)
    {
        NumberOfApartments = other.NumberOfApartments;
    }

    // Метод для зміни кількості квартир
    public void ChangeNumberOfApartments(int newNumberOfApartments)
    {
        NumberOfApartments = newNumberOfApartments;
    }

    // Перевизначений метод для виведення інформації
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Number of Apartments: {NumberOfApartments}");
    }

    // Перевизначений метод порівняння об'єктів
    public new bool Equals(ApartmentBuilding other)
    {
        if (other == null)
            return false;

        return base.Equals(other) &&
               NumberOfApartments == other.NumberOfApartments;
    }
    public override void ChangeInformation()
    {
        base.ChangeInformation(); // Викликайте метод базового класу
        Console.WriteLine("Enter new number of apartments:");
        int newApartments;
        while (!int.TryParse(Console.ReadLine(), out newApartments))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for apartments.");
        }
        NumberOfApartments = newApartments;
        Console.WriteLine("Apartment building information updated.");
    }
}