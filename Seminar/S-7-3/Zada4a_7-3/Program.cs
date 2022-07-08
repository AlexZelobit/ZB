// Программа принимает координаты двух точек и показывает расстояние между ними
// применить теорему пифагора = гипотенуза = корень из суммы квадратов катетов
/* А (5,3) и В(4,2) Длинна будет = V(5-4)^2+(3-2)^2*/
int quarter = InputIn("Введите число: ");
double sqrt = Math.Sqrt(quarter);
int InputIn (string output) // метод для ввода числа
{
     Console.Write(output);
     return Convert.ToInt32(Console.ReadLine());
}
Console.Write(sqrt);
/*
while(true) // повторяем пока программа не выполнится
{
              Console.Clear(); // очищаем значения после цикла
              int number = InputIn("Введите номер четверти: ");
              int InputIn (string output) // метод для ввода числа
                            {
                                 Console.Write(output);
                                 return Convert.ToInt32(Console.ReadLine());
                            }
              if (number > 4)
                            {
                                 Console.WriteLine("Четверть должны быть < 4");
                                 return; // выходим из функции
                            }
           if (number > 0)         
           {        
              if (number == 1)
                            {
                                 Console.WriteLine("x и у должны быть > 0");
                            }
              else if (number == 2)
                            {
                                 Console.WriteLine("x < 0 && y > 0");
                            }
              else if (number == 3)
                            {
                                 Console.WriteLine("x < 0 && y < 0");
                            }
              else if (number == 4)
                            {
                                 Console.WriteLine("x > 0 && y < 0");
                            }     
           }
           else
                            {
                                 Console.WriteLine("Четверть не должна быть отрицательной");
                            }   

              break; // прервать функцию
}
*/