/// ------------------------------------------------------------------------------
Employee employee = new Employee();
employee.Name = "Alice";
employee.Department = "HR";
employee.DisplayInfo(); // Output: Name: Alice, Department: HR

/// CLASS INHERITANCE

public class Person
{
    public string Name { get; set; }
}

public class Employee : Person // Employee inherits from Person (jadi Name ikut masuk ke Employee)
{
    public string Department { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Department: {Department}");
    }
}
