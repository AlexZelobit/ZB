## Установка

<!-- Источник: https://selectel.ru/blog/tutorials/how-to-install-and-use-postgresql-on-ubuntu-20-04/ -->

sudo apt install postgresql postgresql-contrib

<!-- Запускаем сервис: -->

sudo systemctl start postgresql.service

<!-- Проверка статуса сервиса: -->

sudo systemctl status postgresql.service

# Создаем пользователя для работы с БД

По умолчанию Postgres использует концепцию «ролей» для выполнения аутентификации и авторизации. В некоторых аспектах они аналогичны обычным пользователям и группам в Unix.
sudo -i -u postgres
psql

createuser --interactive
createdb sammy
sudo adduser sammy
\q

# Создаем свою БД

# Копирование БД (стратегии резервного копирования)

<!-- источник: https://postgrespro.ru/docs/postgresql/9.6/backup -->

<!-- Существует три фундаментально разных подхода к резервному копированию данных в PostgreSQL:

* Выгрузка в SQL -->

<!-- pg_dump. Простейшее применение этой программы выглядит так: -->

<!-- pg_dump имя_базы > файл_дампа -->

<!-- * Копирование на уровне файлов

* Непрерывное архивирование -->

<!-- Программа pg_dump выгружает только одну базу данных в один момент времени и не включает в дамп информацию о ролях и табличных пространствах (так как это информация уровня кластера, а не самой базы данных). Для удобства создания дампа всего содержимого кластера баз данных предоставляется программа pg_dumpall, которая делает резервную копию всех баз данных кластера, а также сохраняет данные уровня кластера, такие как роли и определения табличных пространств. Простое использование этой команды:

pg_dumpall > файл_дампа
Полученную копию можно восстановить с помощью psql:

psql -f файл_дампа postgres -->

# Репликация БД

Источник: https://selectel.ru/blog/tutorials/how-to-set-up-replication-in-postgresql/

# Восстановление БД

Текстовые файлы, созданные pg_dump, предназначаются для последующего чтения программой psql. Общий вид команды для восстановления дампа:

psql имя*базы < файл*дампа

# Мониторинг БД