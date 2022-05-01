// Задача 41. Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// -1, -7, 567, 89, 223-> 3


Console.WriteLine("Введите несколько чисел через запятую.");
string inputString = Console.ReadLine();
int countPositive = 0;

string tempString = string.Empty;

for (int i = 0; i < inputString.Length; i++)
{
    if ((inputString[i] >= '0' && inputString[i] <= '9') || (inputString[i] == '-' && tempString == string.Empty))
        tempString += inputString[i];
    if ((inputString[i] == ',' || i == inputString.Length - 1) && tempString != string.Empty)
    {
        int inputNumber = Convert.ToInt32(tempString);
        Console.WriteLine(inputNumber);
        if (inputNumber > 0)
            countPositive++;
        tempString = string.Empty;
    }
}

Console.WriteLine($"Количество положительных чисел: {countPositive}");