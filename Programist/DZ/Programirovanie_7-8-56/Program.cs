// задать прямоугольный двумерный массив. Программа находит строку с наименьшей суммой элементов
/*
12
13
14
Наименьшая сумма элементов в 1 строке.
*/

// задать двумерный массив из целых чисел. Программа удаляет строку и столбец на пересечении которых расположен наименьший эллемент массива.
/*
123
456
789

56
89
*/

// Двумерный мссив. Программа меняет строки на столбцы. Если это невозможно выводит сообщение

// Задайте двумерный массив. Напишите прогу, которая меняет местами первую и последнюю строку массива

int m = InputInt("Введите количество строк: ");
int n = InputInt("Введите количество столюцов: ");
int[,] array = new int[row, column]; // создаем матрицу
int minRow = 0; // номер строки с наименьшей суммой элементов
int sumRow = 0; // min сумма строки
int sum = 0; // сумма строки
PrintMatrix(numbers);
Console.WriteLine();
SortArray(numbers); // отсортированный массив
PrintMatrix(numbers);
Console.WriteLine("{minSum}");



void SortArray(int[,] matrix) // сортировка матрицы 4 циклами (2 цигла одномерный массив + 2 для двумерного массива)
{
     for (int i = 0; i < matrix.GetLength(0); i++) // проходим по всей матрице
     {
          for (int j = 0; j < matrix.GetLength(1); j++) // проходим по всей матрице
          {
               matrix[i, j] =  
                         int minSum = 0;
                         minSum = minRow[i,1];
          }
     }
     return minSum;
}

void FillMatrix(int[,] matrix)
{
     for(int i = 0; i < matrix.GetLength(0); i++) // получаем размер первого измерения (строк)
     {
          for(int j = 0; j < matrix.GetLength(1); j++) // получаем размер второго измерения (столбец)
          {
               numbers[i, j] = new Random().Next(0,10); // вставляем рандомные числа
          }

     }
}

void PrintMatrix(int[,] matrix)
{
     for(int i = 0; i < matrix.GetLength(0); i++) // печатаем каждый симбвол
     {
          for(int j = 0; j < matrix.GetLength(1); j++)
          {
               Console.Write(matrix[i, j] + " ");
          }
          Console.WriteLine(); // переходим на новую строку, чотб была таблица
     }
}


int InputInt(string output)
{
     Console.Write(output);
     return Convert.ToInt32(Console.ReadLine());
}