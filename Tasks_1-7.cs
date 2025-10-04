using System;


// ЗАДАНИЕ 1: Ряды Маклорена

namespace Task1
{
    class Series
    {
        static void Task1Main()
        {
            Console.WriteLine("=== Задание 1: Ряды Маклорена ===");
            Console.WriteLine("Введите значение x:");
            double x = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите точность e:");
            double e = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите номер n-го элемента:");
            int n = int.Parse(Console.ReadLine());
            
            double result = CalculateFunction(x, e);
            double nthTerm = CalculateNthTerm(x, n);
            
            Console.WriteLine($"f({x}) = {result:F6}");
            Console.WriteLine($"{n}-й элемент ряда = {nthTerm:F6}");
            Console.WriteLine($"Точное значение e^{x} = {Math.Exp(x):F6}");
        }
        
        static double CalculateFunction(double x, double precision)
        {
            double sum = 1.0; // Первый элемент ряда (x^0 / 0!)
            double term = 1.0;
            int i = 1;
            
            while (Math.Abs(term) >= precision)
            {
                term = term * x / i; // Вычисляем следующий элемент
                sum += term;
                i++;
            }
            
            return sum;
        }
        
        static double CalculateNthTerm(double x, int n)
        {
            if (n == 1) return 1.0; // Первый элемент
            
            double term = 1.0;
            for (int i = 1; i < n; i++)
            {
                term = term * x / i;
            }
            
            return term;
        }
    }
}

// ЗАДАНИЕ 2: Счастливый билет
namespace Task2
{
    class LuckyTicket
    {
        static void Task2Main()
        {
            Console.WriteLine("=== Задание 2: Счастливый билет ===");
            Console.WriteLine("Введите шестизначный номер билета:");
            int ticketNumber = int.Parse(Console.ReadLine());
            
            if (ticketNumber < 100000 || ticketNumber > 999999)
            {
                Console.WriteLine("Номер билета должен быть шестизначным!");
                return;
            }
            
            bool isLucky = IsLuckyTicket(ticketNumber);
            
            if (isLucky)
            {
                Console.WriteLine("Билет счастливый!");
            }
            else
            {
                Console.WriteLine("Билет не счастливый.");
            }
        }
        
        static bool IsLuckyTicket(int number)
        {
            // Извлекаем цифры без использования массивов
            int digit1 = number / 100000;
            int digit2 = (number / 10000) % 10;
            int digit3 = (number / 1000) % 10;
            int digit4 = (number / 100) % 10;
            int digit5 = (number / 10) % 10;
            int digit6 = number % 10;
            
            int firstHalfSum = digit1 + digit2 + digit3;
            int secondHalfSum = digit4 + digit5 + digit6;
            
            return firstHalfSum == secondHalfSum;
        }
    }
}

// ЗАДАНИЕ 3: Сокращение дроби
namespace Task3
{
    class FractionReduction
    {
        static void Task3Main()
        {
            Console.WriteLine("=== Задание 3: Сокращение дроби ===");
            Console.WriteLine("Введите числитель M:");
            int m = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите знаменатель N:");
            int n = int.Parse(Console.ReadLine());
            
            if (n == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен нулю!");
                return;
            }
            
            ReduceFraction(ref m, ref n);
            
            Console.WriteLine($"Сокращенная дробь: {m}/{n}");
        }
        
        static void ReduceFraction(ref int numerator, ref int denominator)
        {
            if (numerator == 0)
            {
                denominator = 1;
                return;
            }
            
            // Обрабатываем знак
            bool isNegative = (numerator < 0) ^ (denominator < 0);
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
            
            int gcd = FindGCD(numerator, denominator);
            
            numerator /= gcd;
            denominator /= gcd;
            
            if (isNegative)
            {
                numerator = -numerator;
            }
        }
        
        static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}

// ЗАДАНИЕ 4: Угадай число
namespace Task4
{
    class GuessNumber
    {
        static void Task4Main()
        {
            Console.WriteLine("=== Задание 4: Угадай число ===");
            Console.WriteLine("Загадайте число от 0 до 63. Я попробую его угадать за 7 вопросов!");
            Console.WriteLine("Отвечайте 'да' или 'нет' на мои вопросы.");
            Console.WriteLine("Нажмите Enter, когда будете готовы...");
            Console.ReadLine();
            
            int guessedNumber = GuessUserNumber();
            
            Console.WriteLine($"Ваше число: {guessedNumber}");
            Console.WriteLine("Правильно ли я угадал? (да/нет)");
            string answer = Console.ReadLine().ToLower();
            
            if (answer == "да" || answer == "yes")
            {
                Console.WriteLine("Отлично! Я угадал ваше число!");
            }
            else
            {
                Console.WriteLine("Что-то пошло не так. Попробуем еще раз!");
            }
        }
        
        static int GuessUserNumber()
        {
            int result = 0;
            
            for (int bit = 5; bit >= 0; bit--) // 6 бит для чисел 0-63
            {
                int testValue = 1 << bit; // 2^bit
                
                Console.WriteLine($"Ваше число больше или равно {testValue}? (да/нет)");
                string answer = Console.ReadLine().ToLower();
                
                if (answer == "да" || answer == "yes")
                {
                    result |= testValue; // Устанавливаем бит
                }
            }
            
            return result;
        }
    }
}

// ЗАДАНИЕ 5: Кофейный аппарат
namespace Task5
{
    class CoffeeMachine
    {
        static int water = 1000; // мл
        static int milk = 500;   // мл
        static int earnings = 0; // рубли
        static int americanoCount = 0;
        static int latteCount = 0;
        
        static void Task5Main()
        {
            Console.WriteLine("=== Задание 5: Кофейный аппарат ===");
            Console.WriteLine("Добро пожаловать в кофейный аппарат!");
            
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        MakeAmericano();
                        break;
                    case "2":
                        MakeLatte();
                        break;
                    case "3":
                        ShowStatus();
                        break;
                    case "4":
                        RefillIngredients();
                        break;
                    case "5":
                        ShowReport();
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
        
        static void ShowMenu()
        {
            Console.WriteLine("\n--- МЕНЮ ---");
            Console.WriteLine("1. Американо (150 мл воды, 50 руб)");
            Console.WriteLine("2. Латте (100 мл воды, 100 мл молока, 80 руб)");
            Console.WriteLine("3. Проверить состояние");
            Console.WriteLine("4. Пополнить ингредиенты");
            Console.WriteLine("5. Отчет и выход");
            Console.Write("Выберите опцию: ");
        }
        
        static void MakeAmericano()
        {
            if (water >= 150)
            {
                water -= 150;
                earnings += 50;
                americanoCount++;
                Console.WriteLine("Американо готов! Приятного кофепития!");
            }
            else
            {
                Console.WriteLine("Недостаточно воды для приготовления американо.");
            }
        }
        
        static void MakeLatte()
        {
            if (water >= 100 && milk >= 100)
            {
                water -= 100;
                milk -= 100;
                earnings += 80;
                latteCount++;
                Console.WriteLine("Латте готов! Приятного кофепития!");
            }
            else
            {
                if (water < 100)
                    Console.WriteLine("Недостаточно воды для приготовления латте.");
                if (milk < 100)
                    Console.WriteLine("Недостаточно молока для приготовления латте.");
            }
        }
        
        static void ShowStatus()
        {
            Console.WriteLine($"\n--- СОСТОЯНИЕ АППАРАТА ---");
            Console.WriteLine($"Вода: {water} мл");
            Console.WriteLine($"Молоко: {milk} мл");
            Console.WriteLine($"Выручка: {earnings} руб");
        }
        
        static void RefillIngredients()
        {
            Console.WriteLine("Ингредиенты пополнены!");
            water = 1000;
            milk = 500;
        }
        
        static void ShowReport()
        {
            Console.WriteLine("\n=== ИТОГОВЫЙ ОТЧЕТ ===");
            Console.WriteLine($"Продано американо: {americanoCount}");
            Console.WriteLine($"Продано латте: {latteCount}");
            Console.WriteLine($"Общая выручка: {earnings} руб");
            Console.WriteLine($"Остаток воды: {water} мл");
            Console.WriteLine($"Остаток молока: {milk} мл");
            Console.WriteLine("Спасибо за использование кофейного аппарата!");
        }
    }
}

// ЗАДАНИЕ 6: Лабораторный опыт
namespace Task6
{
    class LabExperiment
    {
        static void Task6Main()
        {
            Console.WriteLine("=== Задание 6: Лабораторный опыт ===");
            Console.WriteLine("Введите начальное количество бактерий:");
            int bacteria = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите количество капель антибиотика:");
            int antibiotic = int.Parse(Console.ReadLine());
            
            if (bacteria <= 0 || antibiotic <= 0)
            {
                Console.WriteLine("Количество бактерий и антибиотика должно быть положительным!");
                return;
            }
            
            SimulateExperiment(bacteria, antibiotic);
        }
        
        static void SimulateExperiment(int initialBacteria, int initialAntibiotic)
        {
            int bacteria = initialBacteria;
            int antibiotic = initialAntibiotic;
            int hour = 0;
            int antibioticEffectiveness = 10; // Начальная эффективность
            
            Console.WriteLine($"Час {hour}: Бактерии = {bacteria}, Антибиотик = {antibiotic}");
            
            while (bacteria > 0 && antibiotic > 0)
            {
                hour++;
                
                // Бактерии удваиваются
                bacteria *= 2;
                
                // Антибиотик убивает бактерии
                int killedBacteria = Math.Min(bacteria, antibiotic * antibioticEffectiveness);
                bacteria -= killedBacteria;
                
                // Расходуем антибиотик
                antibiotic--;
                
                Console.WriteLine($"Час {hour}: Бактерии = {bacteria}, Антибиотик = {antibiotic}, Убито бактерий = {killedBacteria}");
                
                // Эффективность антибиотика снижается, но не ниже 1
                if (antibioticEffectiveness > 1)
                {
                    antibioticEffectiveness--;
                }
            }
            
            if (bacteria == 0)
            {
                Console.WriteLine("Все бактерии уничтожены!");
            }
            else
            {
                Console.WriteLine("Антибиотик закончился, бактерии выжили.");
            }
        }
    }
}

// ЗАДАНИЕ 7: Колонизация Марса
namespace Task7
{
    class MarsColonization
    {
        static void Task7Main()
        {
            Console.WriteLine("=== Задание 7: Колонизация Марса ===");
            Console.WriteLine("Введите размеры поля (w h):");
            string[] fieldInput = Console.ReadLine().Split();
            int w = int.Parse(fieldInput[0]);
            int h = int.Parse(fieldInput[1]);
            
            Console.WriteLine("Введите размеры модуля (a b):");
            string[] moduleInput = Console.ReadLine().Split();
            int a = int.Parse(moduleInput[0]);
            int b = int.Parse(moduleInput[1]);
            
            Console.WriteLine("Введите количество модулей (n):");
            int n = int.Parse(Console.ReadLine());
            
            if (w <= 0 || h <= 0 || a <= 0 || b <= 0 || n <= 0)
            {
                Console.WriteLine("Все значения должны быть положительными!");
                return;
            }
            
            int maxThickness = FindMaxThickness(w, h, a, b, n);
            
            Console.WriteLine($"Максимальная толщина дополнительного слоя: {maxThickness}");
        }
        
        static int FindMaxThickness(int fieldWidth, int fieldHeight, int moduleA, int moduleB, int moduleCount)
        {
            int left = 0;
            int right = Math.Min(fieldWidth, fieldHeight) / 2;
            int result = 0;
            
            while (left <= right)
            {
                int mid = (left + right) / 2;
                
                if (CanPlaceModules(fieldWidth, fieldHeight, moduleA, moduleB, moduleCount, mid))
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            
            return result;
        }
        
        static bool CanPlaceModules(int fieldWidth, int fieldHeight, int moduleA, int moduleB, int moduleCount, int thickness)
        {
            int effectiveWidth = fieldWidth - 2 * thickness;
            int effectiveHeight = fieldHeight - 2 * thickness;
            
            if (effectiveWidth <= 0 || effectiveHeight <= 0)
            {
                return false;
            }
            
            int variant1 = CalculateModulesCount(effectiveWidth, effectiveHeight, moduleA, moduleB);
            int variant2 = CalculateModulesCount(effectiveWidth, effectiveHeight, moduleB, moduleA);
            
            int maxModules = Math.Max(variant1, variant2);
            
            return maxModules >= moduleCount;
        }
        
        static int CalculateModulesCount(int fieldWidth, int fieldHeight, int moduleWidth, int moduleHeight)
        {
            if (moduleWidth > fieldWidth || moduleHeight > fieldHeight)
            {
                return 0;
            }
            
            int modulesPerRow = fieldWidth / moduleWidth;
            int modulesPerColumn = fieldHeight / moduleHeight;
            
            return modulesPerRow * modulesPerColumn;
        }
    }
}

// Выборка задания
class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задание для выполнения:");
        Console.WriteLine("1. Ряды Маклорена");
        Console.WriteLine("2. Счастливый билет");
        Console.WriteLine("3. Сокращение дроби");
        Console.WriteLine("4. Угадай число");
        Console.WriteLine("5. Кофейный аппарат");
        Console.WriteLine("6. Лабораторный опыт");
        Console.WriteLine("7. Колонизация Марса");
        Console.Write("Введите номер задания (1-7): ");
        
        string choice = Console.ReadLine();
        Console.WriteLine();
        
        switch (choice)
        {
            case "1":
                Task1.Series.Task1Main();
                break;
            case "2":
                Task2.LuckyTicket.Task2Main();
                break;
            case "3":
                Task3.FractionReduction.Task3Main();
                break;
            case "4":
                Task4.GuessNumber.Task4Main();
                break;
            case "5":
                Task5.CoffeeMachine.Task5Main();
                break;
            case "6":
                Task6.LabExperiment.Task6Main();
                break;
            case "7":
                Task7.MarsColonization.Task7Main();
                break;
            default:
                Console.WriteLine("Неверный номер задания!");
                break;
        }
        
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}