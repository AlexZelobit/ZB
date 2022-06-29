# Команды для установки Zabbix
## УСТАНОВКА APACHE, PHP, MYSQL
sudo apt update
sudo apt install apache2
sudo apt install mysql-server
sudo apt install php php-cli php-common php-mysql

Дальше необходимо настроить правильный часовой пояс в php.ini. Вам нужна секция Data и строка timezone:\

> sudo vi /etc/php/apache2/php.ini

> [Date]
> date.timezone = 'Europe/Moscow'

## ДОБАВЛЕНИЕ РЕПОЗИТОРИЯ

Скачать установщик репозитория для вашего дистрибутива можно в папкеzabbix/5.2/ubuntu/pool/main/z/zabbix-release/. Там находятся установщики для разных версий Ubuntu:

Например, можно использовать wget для загрузки файла:

> wget http://repo.zabbix.com/zabbix/5.2/ubuntu/pool/main/z/zabbix-release/zabbix-release_5.2-1+ubuntu20.04_all.deb

Если у вас другая операционная система, посмотрите список файлов на сервере через браузер и выберите нужный установщик. Затем установка zabbix 3.2 на Ubuntu:

> sudo dpkg -i zabbix-release_5.2-1+ubuntu20.04_all.deb

После установки пакета репозитория, обновление списка пакетов обязательно:

> sudo apt update

## УСТАНОВКА И НАСТРОЙКА ZABBIX
Когда репозиторий будет добавлен, можно перейти к настройке самого сервера Zabbix. Для установки программ выполните:

> sudo apt install zabbix-server-mysql zabbix-frontend-php

Для получения доступа к базе данных MySQL/MariaDB обычному пользователю без использования sudo привилегий, зайдите в приглашение командной строки MySQL

> sudo mysql

и запустите следующие команды:

> mysql> CREATE DATABASE zabbixdb CHARACTER SET utf8 COLLATE utf8_bin;
* Проверить, что база появилась можно командой:
> show databases;
> CREATE USER 'zabbix'@'localhost' IDENTIFIED BY 'Zel0bitZB';
* Проверяем пользователей
> SELECT User,Host FROM mysql.user;
* Добавляем root права
> GRANT ALL PRIVILEGES ON zabbixdb . * TO 'zabbix'@'localhost';
* После обновления прав пользователя необходимо обновить таблицу прав пользователей MySQL  в памяти. Для этого выполните:
> mysql> FLUSH PRIVILEGES;
* Теперь посмотрим привилегии нашего пользователя:
> SHOW GRANTS FOR 'zabbix'@'localhost';

* Далее, включаем конфигурационный файл zabbix для apache2:

> sudo a2enconf zabbix-frontend-php

* Теперь нужно перезапустить Zabbix и Apache, чтобы применить изменения:

> systemctl reload apache2;

> sudo systemctl restart zabbix-server

Установка и настройка Zabbix Ubuntu почти завершена, осталось настроить веб-интерфейс.
http://адрес_сервера/zabbix/
