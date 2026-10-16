using System.Globalization;

while (true)
{
    Console.WriteLine("Калькулятор: + сложение, - вычитание, * умножение, / деление.");
    Console.Write("Выберите операцию или введите q для выхода: ");
    var operation = Console.ReadLine();

    if (operation is null || operation.Equals("q", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    if (operation is not ("+" or "-" or "*" or "/"))
    {
        Console.WriteLine("Неизвестная операция.");
        continue;
    }

    if (!TryReadNumber("Введите первое число: ", out var firstNumber) ||
        !TryReadNumber("Введите второе число: ", out var secondNumber))
    {
        Console.WriteLine("Введите корректное число.");
        continue;
    }

    if (operation == "/" && secondNumber == 0)
    {
        Console.WriteLine("На ноль делить нельзя.");
        continue;
    }

    try
    {
        var result = operation switch
        {
            "+" => firstNumber + secondNumber,
            "-" => firstNumber - secondNumber,
            "*" => firstNumber * secondNumber,
            "/" => firstNumber / secondNumber,
            _ => throw new InvalidOperationException()
        };

        Console.WriteLine($"Результат: {result}");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Результат выходит за допустимый диапазон.");
    }
}

static bool TryReadNumber(string prompt, out decimal number)
{
    Console.Write(prompt);
    var input = Console.ReadLine();
    return decimal.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out number);
}
