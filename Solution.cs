public static void CreateNewObject()
{

}

public static void RandomizeChance()
{
    _chance = Random.Range(0, 100);
}

public static int CalculateSalary(int hoursWorked)
{
    return _hourlyRate * hoursWorked;
}