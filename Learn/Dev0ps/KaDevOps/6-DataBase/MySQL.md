# MySQL

## Установка

### Источник https://selectel.ru/blog/ubuntu-mysql-install/

<!-- Для установки обновите индекс пакетов на вашем сервере, если еще не сделали этого: -->

sudo apt update

<!-- Затем выполните установку пакета mysql-server: -->

sudo apt install mysql-server

<!-- Заходим в SQL и меняем пароль -->

sudo mysql

ALTER USER 'root'@'localhost' IDENTIFIED WITH caching_sha2_password BY 'Zel0bit04k@\_SQL';

<!-- Сохраним изменения -->

FLUSH PRIVILEGES;

<!-- Проверяем, что для пользователя пароль изменился -->

SELECT user,authentication_string,plugin,host FROM mysql.user;

<!-- Выход -->

exit

<!-- Вход -->

mysql -u root -p

# Создаем пользователя для работы с БД

CREATE USER 'user'@'localhost' IDENTIFIED BY 'Zel0bit04k@\_user';

<!-- Просмотр БД -->

show databases;

<!-- Создаем свою БД -->

CREATE DATABASE my_test;

Даем права на БД
mysql> GRANT ALL PRIVILEGES ON my_test.\* TO 'user'@'localhost';
