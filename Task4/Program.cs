// Написать функцию Shuffle, которая перемешивает элементы массива в случайном порядке.

int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
PrintArray(array);
array = Shuffle(array);
PrintArray(array);


int[] Shuffle(int[] sourceArray)
{
    int[] newArray = { };

    while (sourceArray.Length > 0)
    {
        int randomIndex = new Random().Next(0, sourceArray.Length);
        newArray = AddToArray(newArray, sourceArray[randomIndex]);
        sourceArray = RemoveFromArray(sourceArray, randomIndex);
    }

    return newArray;
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


void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}