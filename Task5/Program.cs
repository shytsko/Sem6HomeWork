// Написать программу со следующими командами:
// - SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив
// - AddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву
// - RemoveNumbers - пользователь вводит числа, которые если найдутся в массиве, то будут удалены 
// - Numbers – ввывод текущего массива 
// - Sum – найдется сумма всех элементов чисел
int[] workArray = { };

Console.WriteLine("Введите команду. Для вывода списка команд введите Help. Для выхода введите Exit");
while (true)
{
    Console.Write("Введите команду > ");
    string inputString = Console.ReadLine();
    string command = GetCommand(inputString);
    if (command == "Exit")
        break;
    else if (command == "SetNumbers")
        RunCommandSetNumbers(inputString, command.Length + 1);
    else if (command == "AddNumbers")
        RunCommandAddNumbers(inputString, command.Length + 1);
    else if (command == "Numbers")
        RunCommandNumbers();
    else if (command == "RemoveNumbers")
        RunCommandRemoveNumbers(inputString, command.Length + 1);
    else if (command == "Sum")
        RunCommandSum();
    else if (command == "Help")
        RunCommandHelp();
    else
        Console.WriteLine("Команда не распознана.");
}

string GetCommand(string inputString)
{
    string command = string.Empty;

    for (int i = 0; i < inputString.Length; i++)
    {
        if (inputString[i] == ' ')
            break;
        command += inputString[i];
    }

    return command;
}

void RunCommandSetNumbers(string inputString, int argsStartPosition)
{
    workArray = StringToIntArray(inputString, argsStartPosition);
    PrintArray(workArray);
}

void RunCommandAddNumbers(string inputString, int argsStartPosition)
{
    int[] addNumbers = StringToIntArray(inputString, argsStartPosition);

    for (int i = 0; i < addNumbers.Length; i++)
        workArray = AddToArray(workArray, addNumbers[i]);
    PrintArray(workArray);
}

void RunCommandRemoveNumbers(string inputString, int argsStartPosition)
{
    int[] removeNumbers = StringToIntArray(inputString, argsStartPosition);

    int i = 0;
    while (i < removeNumbers.Length)
    {
        int position = FindValue(workArray, removeNumbers[i]);
        if (position < 0)
            i++;
        else
            workArray = RemoveFromArray(workArray, position);
    }
    PrintArray(workArray);
}

void RunCommandNumbers()
{
    PrintArray(workArray);
}

void RunCommandSum()
{
    int sum = 0;
    for (int i = 0; i < workArray.Length; i++)
        sum += workArray[i];

    Console.WriteLine($"Sum = {sum}");
}

void RunCommandHelp()
{
    Console.WriteLine("Exit - выход из программы");
    Console.WriteLine("Help - выход списка команд");
    Console.WriteLine("SetNumbers <список_чисел_через_пробел> - ввести новый массив");
    Console.WriteLine("AddNumbers <список_чисел_через_пробел> - добавить числа в массив");
    Console.WriteLine("RemoveNumbers <список_чисел_через_пробел> - удалить числа из массива");
    Console.WriteLine("Numbers - вывод массива");
    Console.WriteLine("Sun - вывод суммы элементов массива");
}

int[] StringToIntArray(string inputString, int startPisition)
{
    int[] array = { };
    string tempString = string.Empty;

    for (int i = startPisition; i < inputString.Length; i++)
    {
        if ((inputString[i] >= '0' && inputString[i] <= '9') || (inputString[i] == '-' && tempString == string.Empty))
            tempString += inputString[i];
        if ((inputString[i] == ' ' || i == inputString.Length - 1) && tempString != string.Empty)
        {
            int number = Convert.ToInt32(tempString);
            array = AddToArray(array, number);
            tempString = string.Empty;
        }
    }

    return array;
}

int[] AddToArray(int[] sourceArray, int value)
{
    int[] newArray = new int[sourceArray.Length + 1];
    for (int i = 0; i < sourceArray.Length; i++)
    {
        newArray[i] = sourceArray[i];
    }
    newArray[newArray.Length - 1] = value;
    return newArray;
}

int[] RemoveFromArray(int[] sourceArray, int position)
{
    int[] newArray = new int[sourceArray.Length - 1];
    for (int i = 0; i < position; i++)
    {
        newArray[i] = sourceArray[i];
    }
    for (int i = position + 1; i < sourceArray.Length; i++)
    {
        newArray[i - 1] = sourceArray[i];
    }
    return newArray;
}

int FindValue(int[] sourceArray, int value)
{
    for (int i = 0; i < sourceArray.Length; i++)
        if (sourceArray[i] == value)
            return i;

    return -1;
}


void PrintArray(int[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]}");
        if (i != array.Length - 1)
            Console.Write(", ");
    }
    Console.Write("]");
    Console.WriteLine();
}