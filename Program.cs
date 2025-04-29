using EmployeeManager.Data;
using EmployeeManager.Models;

var db = new ApplicationDbContext();

while (true)
{
    Console.WriteLine("\n1. Добавить сотрудника");
    Console.WriteLine("2. Показать всех сотрудников");
    Console.WriteLine("3. Найти сотрудника по отделу");
    Console.WriteLine("4. Удалить сотрудника");
    Console.WriteLine("5. Выход");
    Console.Write("Выберите действие: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Имя: ");
            var name = Console.ReadLine();
            Console.Write("Возраст: ");
            var age = int.Parse(Console.ReadLine());
            Console.Write("Отдел: ");
            var department = Console.ReadLine();

            db.Employees.Add(new Employee { Name = name, Age = age, Department = department });
            db.SaveChanges();
            Console.WriteLine("Сотрудник добавлен!");
            break;

        case "2":
            var employees = db.Employees.ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Id}: {emp.Name} ({emp.Age} лет) - {emp.Department}");
            }
            break;

        case "3":
            Console.Write("Введите название отдела: ");
            var dept = Console.ReadLine();
            var found = db.Employees.Where(e => e.Department == dept).ToList();
            foreach (var emp in found)
            {
                Console.WriteLine($"{emp.Id}: {emp.Name} ({emp.Age} лет)");
            }
            break;

        case "4":
            Console.Write("Введите ID сотрудника для удаления: ");
            var id = int.Parse(Console.ReadLine());
            var employee = db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                Console.WriteLine("Сотрудник удалён.");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Неверный ввод. Попробуйте снова.");
            break;
    }
}