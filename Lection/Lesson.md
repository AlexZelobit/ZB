## Методы
Функции бывают 2ух видо:
* ничего не принимают и ничего не возвращают
* те который принимаютт и ничего не возвращают
* ничего не принимают и что=то возвращают
* что то принимают и что-то возвращают

//Пример 1 вида
void Method1 ()
{
     Console.Write("Автор ****");
}

Вызываются такие методы таким образом
Method1();

//Пример 2 вида
void method2 (string msg)
{
     Console.Write(msg;)
}
Method2(msg:"Text methoda2");

//Пример 2 вида
void method21 (string msg, int count)
{
     int i = 0;
     while(i < count)
     {
          Console.Write(msg;)
          i++;
     }
}
Method2("Text", 4);
