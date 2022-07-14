// Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

Console.Write("Введите числа через пробел: ");
int[] array = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int result = 0;
 
for (int i = 0; i < array.Length; i++)
{
    if (array[i] > 0)
    {
        result++;
    }
}
 
Console.WriteLine($"Кол-во положительных чисел: {result}");

