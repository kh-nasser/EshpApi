// See https://aka.ms/new-console-template for more information

using Polymorphism;
using Polymorphism.DataModel;

//string name = Environment.GetCommandLineArgs()[1];
Console.WriteLine($"Hello, World! ");
const int hour = 55, wage = 70;
List <Employee> employees =  new EmployeeBis().GetEmployees();
foreach (var employee in employees)
{
    employee.CalclateWeeklySalary(hour, wage);
}