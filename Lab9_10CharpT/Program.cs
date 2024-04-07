//Exercise 1
using System; 

using System.Collections.Generic; 

  

class PrefixToPostfixConverter 

{ 

    private static int GetPriority(char op) 

    { 

        switch (op) 

        { 

            case '+': 

            case '-': 

                return 1; 

            case '*': 

            case '/': 

                return 2; 

            default: 

                return 0; // для операндів 

        } 

    } 

  

    public static string Convert(string prefixExpression) 

    { 

        Stack<char> operators = new Stack<char>(); 

        string postfixExpression = ""; 

  

        for (int i = 0; i < prefixExpression.Length; i++) 

        { 

            char currentChar = prefixExpression[i]; 

  

            if (char.IsLetterOrDigit(currentChar)) 

            { 

                postfixExpression += currentChar; 

            } 

            else if (currentChar == '(') 

            { 

                operators.Push(currentChar); 

            } 

            else if (currentChar == ')') 

            { 

                while (operators.Count > 0 && operators.Peek() != '(') 

                { 

                    postfixExpression += operators.Pop(); 

                } 

                operators.Pop(); // видаляємо '(' зі стека 

            } 

            else if (GetPriority(currentChar) > 0) 

            { 

                while (operators.Count > 0 && GetPriority(operators.Peek()) >= GetPriority(currentChar)) 

                { 

                    postfixExpression += operators.Pop(); 

                } 

                operators.Push(currentChar); 

            } 

            else if (currentChar == ' ') 

            { 

                // Ігноруємо пробіли 

            } 

            else 

            { 

                throw new ArgumentException("Недопустимий символ у виразі."); 

            } 

        } 

  

        while (operators.Count > 0) 

        { 

            postfixExpression += operators.Pop(); 

        } 

  

        return postfixExpression; 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        Console.WriteLine("Введіть вираз у префіксній формі:"); 

        string prefixExpression = Console.ReadLine(); 

  

        string postfixExpression = PrefixToPostfixConverter.Convert(prefixExpression); 

  

        Console.WriteLine("Вираз у постфіксній формі:"); 

        Console.WriteLine(postfixExpression); 

    } 

} 

 

//Exercise 2


using System; 

using System.Collections.Generic; 

using System.IO; 

  

class Employee 

{ 

    public string LastName { get; set; } 

    public string FirstName { get; set; } 

    public string Patronymic { get; set; } 

    public string Gender { get; set; } 

    public int Age { get; set; } 

    public decimal Salary { get; set; } 

  

    public Employee(string lastName, string firstName, string patronymic, string gender, int age, decimal salary) 

    { 

        LastName = lastName; 

        FirstName = firstName; 

        Patronymic = patronymic; 

        Gender = gender; 

        Age = age; 

        Salary = salary; 

    } 

  

    public override string ToString() 

    { 

        return $"{LastName} {FirstName} {Patronymic}, {Gender}, {Age} years old, Salary: {Salary}"; 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        Queue<Employee> maleEmployees = new Queue<Employee>(); 

        Queue<Employee> femaleEmployees = new Queue<Employee>(); 

  

        // Читаємо дані з файлу та додаємо їх до відповідних черг 

        string filePath = "employees.txt"; // шлях до файлу 

        string[] lines = File.ReadAllLines(filePath); 

        foreach (string line in lines) 

        { 

            string[] data = line.Split(','); 

            string lastName = data[0]; 

            string firstName = data[1]; 

            string patronymic = data[2]; 

            string gender = data[3]; 

            int age = int.Parse(data[4]); 

            decimal salary = decimal.Parse(data[5]); 

  

            Employee employee = new Employee(lastName, firstName, patronymic, gender, age, salary); 

            if (gender.ToLower() == "male") 

            { 

                maleEmployees.Enqueue(employee); 

            } 

            else if (gender.ToLower() == "female") 

            { 

                femaleEmployees.Enqueue(employee); 

            } 

            else 

            { 

                Console.WriteLine($"Invalid gender detected: {gender}. Skipping employee."); 

            } 

        } 

  

        // Виводимо всі дані про чоловіків 

        Console.WriteLine("Male Employees:"); 

        while (maleEmployees.Count > 0) 

        { 

            Console.WriteLine(maleEmployees.Dequeue()); 

        } 

  

        // Виводимо всі дані про жінок 

        Console.WriteLine("\nFemale Employees:"); 

        while (femaleEmployees.Count > 0) 

        { 

            Console.WriteLine(femaleEmployees.Dequeue()); 

        } 

    } 

} 




//Exercise 4

using System; 

using System.Collections; 

  

class Пісня 

{ 

    public string Назва { get; set; } 

    public string Виконавець { get; set; } 

  

    public Пісня(string назва, string виконавець) 

    { 

        Назва = назва; 

        Виконавець = виконавець; 

    } 

  

    public override string ToString() 

    { 

        return $"{Назва} - {Виконавець}"; 

    } 

} 

  

class МузичнийДиск 

{ 

    public string Назва { get; set; } 

    public Hashtable Пісні { get; set; } 

  

    public МузичнийДиск(string назва) 

    { 

        Назва = назва; 

        Пісні = new Hashtable(); 

    } 

  

    public void ДодатиПісню(Пісня пісня) 

    { 

        Пісні.Add(пісня.Назва, пісня); 

    } 

  

    public void ВидалитиПісню(string назва) 

    { 

        Пісні.Remove(назва); 

    } 

  

    public void ВивестиПісні() 

    { 

        Console.WriteLine($"Пісні на диску '{Назва}':"); 

        foreach (DictionaryEntry entry in Пісні) 

        { 

            Console.WriteLine(entry.Value); 

        } 

    } 

} 

  

class КаталогМузичнихДисків 

{ 

    public Hashtable Диски { get; set; } 

  

    public КаталогМузичнихДисків() 

    { 

        Диски = new Hashtable(); 

    } 

  

    public void ДодатиДиск(МузичнийДиск диск) 

    { 

        Диски.Add(диск.Назва, диск); 

    } 

  

    public void ВидалитиДиск(string назва) 

    { 

        Диски.Remove(назва); 

    } 

  

    public void ПошукПісеньВиконавця(string виконавець) 

    { 

        Console.WriteLine($"Пошук пісень виконавця '{виконавець}':"); 

        foreach (DictionaryEntry entry in Диски) 

        { 

            МузичнийДиск диск = (МузичнийДиск)entry.Value; 

            foreach (DictionaryEntry пісняEntry in диск.Пісні) 

            { 

                Пісня пісня = (Пісня)пісняEntry.Value; 

                if (пісня.Виконавець == виконавець) 

                { 

                    Console.WriteLine($"{пісня.Назва} - {пісня.Виконавець} (Диск: {диск.Назва})"); 

                } 

            } 

        } 

    } 

  

    public void ВивестиКаталог() 

    { 

        Console.WriteLine("Каталог музичних дисків:"); 

        foreach (DictionaryEntry entry in Диски) 

        { 

            МузичнийДиск диск = (МузичнийДиск)entry.Value; 

            Console.WriteLine($"Диск: {диск.Назва}"); 

            диск.ВивестиПісні(); 

        } 

    } 

} 

  

class Program 

{ 

    static void Main(string[] args) 

    { 

        КаталогМузичнихДисків каталог = new КаталогМузичнихДисків(); 

  

        // Додати диск 

        МузичнийДиск диск1 = new МузичнийДиск("Диск1"); 

        диск1.ДодатиПісню(new Пісня("Пісня 1", "Виконавець 1")); 

        диск1.ДодатиПісню(new Пісня("Пісня 2", "Виконавець 2")); 

        каталог.ДодатиДиск(диск1); 

  

        // Вивести каталог 

        каталог.ВивестиКаталог(); 

  

        // Пошук пісень виконавця 

        каталог.ПошукПісеньВиконавця("Виконавець 1"); 

    } 

} 