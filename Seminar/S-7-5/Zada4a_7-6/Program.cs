// Найти произведение пар чисел в массиве. Парой считается первый и последний эллемент. второй и предпоследний и т.д..Результат записать в новом массиве.

int size = Input("Введите размер массива");
int[] numbers = new int[size];
int[] result; // говорим, что есть массив, но мы не знаем размера

FillArray(numbers); // вызываем метод заполняющий массив
PrintArray(numbers); // выводим на экран массив

if(numbers.Length % 2 == 0)
{
     result = new int[numbers.Length / 2]; // если заданный массив четный то новый массив равен половине заданного
}
else
{
result = new int[numbers.Length / 2 + 1]; // если заданный массив не четный то новый массив равен половине заданного + 1
result[result.Length - 1] = numbers[numbers.Length / 2]; // получаем последний элемент нового массива равен элементу, который расположен в середине заданного массива
}
for (int i = 0; i < numbers.Length / 2; i++) // проходим весь заданный массив до середины
{
     result[i] = numbers[i] * numbers[numbers.Length -1 - i]; // в каждый элемент нового массива помещаем произведения от первого на последний элемент массива
}
PrintArray(result);


int Input (string output)
{
     Console.Write(output);
     return Convert.ToInt32(Console.ReadLine());
}

void FillArray(int[] array) // метод заполняющий наш массив
{
     for(int i = 0; i < array.Length; i++) // проходимся по всему массиву
     {
          array[i] = new Random().Next(1, 10); // заполняем каждый элемент случайной цифрой от -9 до 9
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