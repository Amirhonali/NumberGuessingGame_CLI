using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("===================================");
        Console.WriteLine(" Добро пожаловать в игру 'Угадай число'!");
        Console.WriteLine("===================================");
        Console.WriteLine("Правила игры:");
        Console.WriteLine("- Компьютер загадал число от 1 до 100.");
        Console.WriteLine("- Ваша задача — угадать это число.");
        Console.WriteLine("- Выберите уровень сложности:");
        Console.WriteLine("  1. Лёгкий (10 попыток)");
        Console.WriteLine("  2. Средний (7 попыток)");
        Console.WriteLine("  3. Сложный (5 попыток)");
        Console.WriteLine();

        int attempts = 0;
        while (true)
        {
            Console.Write("Введите номер уровня: ");
            string level = Console.ReadLine();

            if (level == "1") { attempts = 10; break; }
            else if (level == "2") { attempts = 7; break; }
            else if (level == "3") { attempts = 5; break; }
            else Console.WriteLine("Неверный ввод. Пожалуйста, выберите 1, 2 или 3.");
        }

        Console.WriteLine($"\nХорошо! У вас {attempts} попыток. Начнём!\n");

        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int guessCount = 0;
        bool isGuessed = false;

        while (attempts > 0)
        {
            Console.Write("Введите ваше предположение: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int userGuess) || userGuess < 1 || userGuess > 100)
            {
                Console.WriteLine("Введите корректное число от 1 до 100.");
                continue;
            }

            guessCount++;
            attempts--;

            if (userGuess == secretNumber)
            {
                Console.WriteLine($"\n🎉 Поздравляем! Вы угадали число {secretNumber} за {guessCount} попыток.");
                isGuessed = true;
                break;
            }
            else if (userGuess < secretNumber)
            {
                Console.WriteLine("Загаданное число больше!");
            }
            else
            {
                Console.WriteLine("Загаданное число меньше!");
            }

            Console.WriteLine($"Осталось попыток: {attempts}\n");
        }

        if (!isGuessed)
        {
            Console.WriteLine($"\n😞 Попытки закончились. Вы не угадали число. Это было: {secretNumber}");
        }

        Console.WriteLine("\nСпасибо за игру!");
    }
}