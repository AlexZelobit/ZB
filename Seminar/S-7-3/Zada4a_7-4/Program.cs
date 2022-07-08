// Программа принимает число X и выдает квадраты числа от 1 до X
// 5 -> 1 4 9 16
// Методы
int InputIn (string output) // метод для ввода числа
{
     Console.Write(output);
     return Convert.ToInt32(Console.ReadLine());
}
int Quadro (string number) // метод для получения квадрата числа
{
              int Quadro = number * number;
              return Quadro;
}
//Решение
     int number = InputIn("Введите число: ");
     int numberQuadro = Quadro(number);
                                 Console.WriteLine($"Число {number} его квадрат {numberQuadro}");