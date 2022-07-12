// Массив вещественных чисел. Найти разницу между минимальным и максимальным значением массива




int size = Input("Введите размер массива: ");
int[] numbers = new int[size];

int minNumber = 0;
int maxNumber = 0;
int result = 0;

FillArray(numbers); // вызываем метод заполняющий массив
PrintArray(numbers); // выводим на экран массив


for (int i = 0; i < numbers.Length; i++) // ищем минимальное и максимальные элементы массива
{
     if(numbers[i] > maxNumber)
     {
          maxNumber = numbers[i];
     }
     else if(numbers[i] < minNumber)
     {
          minNumber = numbers[i];
     }
}

result = maxNumber - minNumber;

Console.Write($"Разница между максимальным ({maxNumber}) и минимальным ({minNumber}) значением равна {result}");


int Input (string output)
{
     Console.Write(output);
     return Convert.ToInt32(Console.ReadLine());
}

void FillArray(int[] array) // метод заполняющий наш массив
{
     for(int i = 0; i < array.Length; i++) // проходимся по всему массиву
     {
          array[i] = new Random().Next(-10, 10); // заполняем каждый элемент случайной цифрой
     }
}

// метод, который будет выводить массив

void PrintArray(int[] array) // метод заполняющий наш массив
{
     for(int i = 0; i < array.Length; i++) // проходимся по всему массиву
     {
          Console.Write(array[i] + " "); // вывод на терминал
     }
     Console.WriteLine();
}