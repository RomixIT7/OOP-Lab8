public class Warehouse : Building
{
    public string PlanningType { get; set; }

    public Warehouse()
    {
        // Конструктор за замовчуванням
    }

    public Warehouse(string address, string wallMaterial, int floors, string planningType)
        : base(address, wallMaterial, floors)
    {
        PlanningType = planningType;
    }

    // Конструктор копіювання
    public Warehouse(Warehouse other)
        : base(other)
    {
        PlanningType = other.PlanningType;
    }

    // Метод для зміни типу планування
    public void ChangePlanningType(string newPlanningType)
    {
        PlanningType = newPlanningType;
    }

    // Перевизначений метод для виведення інформації
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Planning Type: {PlanningType}");
    }

    // Перевизначений метод порівняння об'єктів
    public new bool Equals(Warehouse other)
    {
        if (other == null)
            return false;

        return base.Equals(other) &&
               PlanningType == other.PlanningType;
    }
    public override void ChangeInformation()
    {
        base.ChangeInformation(); // Викликайте метод базового класу
        Console.WriteLine("Enter new planning type (Open/Closed/Semi-Closed):");
        PlanningType = Console.ReadLine();
        Console.WriteLine("Warehouse information updated.");
    }
}