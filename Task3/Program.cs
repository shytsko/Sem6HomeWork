// Написать 2 функции для работы с массивом: AddToArray И RemoveFromArray – первая добавляет к числовому массиву значение,
// тем самым увеличивая массив, а вторая удаляет элемент под нужным индексом и уменьшает массив на 1.

int[] array = { 1, 2, 3, 4, 5, 6 };
PrintArray(array);
array = AddToArray(array, 7);
PrintArray(array);
array = RemoveFromArray(array, 3);
PrintArray(array);

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