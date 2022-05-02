// **Задача 43**. Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями
// y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; 5,5)
double k1 = InputDouble("k1 = ");
double b1 = InputDouble("b1 = ");
double k2 = InputDouble("k2 = ");
double b2 = InputDouble("b2 = ");

if (k1 != k2)
{
    double x = (b2 - b1) / (k1 - k2);
    double y = k1 * x + b1;
    Console.WriteLine($"Точка пересечения ({x}; {y})");
}
else
{
    if (b1 == b2)
        Console.WriteLine("Прямые совпадают");
    else
        Console.WriteLine("Прямые параллельны");
}

double InputDouble(string message)
{
    Console.Write(message);
    return Convert.ToDouble(Console.ReadLine());
}