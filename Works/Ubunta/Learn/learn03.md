## Отобразить файлы и каталоги в папке и посчитать их количество без . и ..

ls -A|grep '^\.'|wc -l

## ПРАВА и ПОЛЬЗОВАТЕЛИ

vim /etc/passwd
UID - первая цифра, она уникальна, идентификатор пользователя. Работа с проессами
GID - идентификатор группы, доступ к файлам

vim /etc/group
vim /etc/shadow

- и ! означает, что пользователь не сможет залогиниться

## Создание пользователя

sudo useradd user1
sudo passwd user1

в Ubuntu пользователь создается без домашнего каталога и с оболочкой SH, а не home. Он не сможет войти в систему.
поэтому правильно создавать командой

## Правильно создаем пользователя

- прописываем обоочку, каталог, -m если хотим, чтоб пользователь мог войти в систему -M если системный проесс
  useradd -s /bin/bash -d /home/user1 -m user1

## Простое создание пользователя через утилиту

sudo adduser user2

## Простое создание группы

sudo addgroup test

## Простое создание пользователя с присвоением ему группы

- чтобы просмотреть gid группы vim /etc/group
  sudo addgroup user3 --gid 1003

## Смена пароля

passwd user3

## Политики системы

man chage

## Добавление пользователя в группы (без изменения собственной)

- Параметр -a добавляет в группу -G имя группы
  sudo usermod -aG test ser3

## Зайти с правами root

sudo -i

## Файловая структура

- обычные файлы
  d каталоги
  /dev/ тут все устройства
  b это накопители и жесткие диски
  с это консольные устройства
  "пайп" пример: ls | grep когда один канал передает информацию другом
  "сокеты"
  l это ссылки

## Смена владельца файла и группы у файлов

chown user1 err
chown user1:test err

chown 640 err
_ 1 выполнение
_ 2 Запись
_ 4 Чтение
_ 0 Запрет

## Смена владельца файла и группы у каталогов

- -R рекурсивно
  chown -R user1:test err

## узнать рабочий каталог

pwd

## Разрешения файлов

- Владелец u
  r - чтение
  w - запись
  x - выполнение

- Группа g
  r - чтение
  w - запись
  x - выполнение

- Остальные o
  r - чтение
  w - запись
  x - выполнение

Выполнение для каталога это войти в него

## Добавим владельцу право на выполнения файла

chmod u+x err

## Уберем владельца право на выполнения файла

chmod u-x err

## Для каталога делать рекурсивно владельца право на выполнения файла

chmod -R u=rwx err

## Используеся sGID для выполнения действий от лица владельца каталога

chmod -R g+s err

## Используеся sGID для удаления файлов только тех. которые создал определенны действий от лица владельца каталога

chmod -R +t err

## Ссылки

### Символические

Могут ссылаться на файлы и каталоги;
После удаления, перемещения или переименования файла становятся недействительными;
Права доступа и номер inode отличаются от исходного файла;
При изменении прав доступа для исходного файла, права на ссылку останутся неизменными;
Можно ссылаться на другие разделы диска;
Содержат только имя файла, а не его содержимое.

### Жесткие

Работают только в пределах одной файловой системы;
Нельзя ссылаться на каталоги;
Имеют ту же информацию inode и набор разрешений что и у исходного файла;
Разрешения на ссылку изменяться при изменении разрешений файла;
Можно перемещать и переименовывать и даже удалять файл без вреда ссылке.

## Правила создания

$ ln опции файл*источник файл*ссылки

Рассмотрим опции утилиты:

-d - разрешить создавать жесткие ссылки для директорий суперпользователю;
-f - удалять существующие ссылки;
-i - спрашивать нужно ли удалять существующие ссылки;
-P - создать жесткую ссылку;
-r - создать символическую ссылку с относительным путем к файлу;
-s - создать символическую ссылку.

## Создаем символические ссылки

ln -s file3 file1

## Смотрим inode

ls -il