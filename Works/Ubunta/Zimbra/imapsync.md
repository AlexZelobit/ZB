# Перенос почтовых ящиков между серверами при помощи imapsync

<!-- Прежде всего откроем /etc/apt/sources.list и убедимся, что у репозиториев подключен раздел contrib, если это не так, то в каждую строку после -->

main

<!-- необходимо добавить -->

contrib

<!-- После чего не забываем обновить список пакетов: -->

apt update

<!-- После чего обращаемся на сайт разработчика за инструкциями по установке. Для Debian они выглядят следующим образом: -->

apt install \
 libauthen-ntlm-perl \
 libcgi-pm-perl \
 libcrypt-openssl-rsa-perl \
 libdata-uniqid-perl \
 libencode-imaputf7-perl \
 libfile-copy-recursive-perl \
 libfile-tail-perl \
 libio-socket-inet6-perl \
 libio-socket-ssl-perl \
 libio-tee-perl \
 libhtml-parser-perl \
 libjson-webtoken-perl \
 libmail-imapclient-perl \
 libparse-recdescent-perl \
 libproc-processtable-perl \
 libmodule-scandeps-perl \
 libreadonly-perl \
 libregexp-common-perl \
 libsys-meminfo-perl \
 libterm-readkey-perl \
 libtest-mockobject-perl \
 libtest-pod-perl \
 libunicode-string-perl \
 liburi-perl \
 libwww-perl \
 libtest-nowarnings-perl \
 libtest-deep-perl \
 libtest-warn-perl \
 make \
 time \
 cpanminus

 <!-- После того, как мы скачали все необходимые зависимости перейдем в домашнюю директорию и скачаем саму утилиту: -->

cd
wget -N https://raw.githubusercontent.com/imapsync/imapsync/master/imapsync

<!-- И сразу сделаем ее исполняемой: -->

chmod +x imapsync

<!-- В простейшем случае перенос ящика будет выглядеть так: -->

./imapsync \
 --host1 imap.yandex.ru \
 --user1 admin@snabavangard.ru \
 --password1 "sntfjxaitpepcsil" \
 --host2 m.snabavangard.ru \
 --user2 admin@snabavangard.ru \
 --password2 "Zel0bit04k@\_MAIL"

 <!-- Для исключения следует использовать опцию --exclude, которая поддерживает регулярные выражения. Скажем, уберем из синхронизации папку Спам и Корзину: -->

--exclude 'Spam|Trash'

<!-- Если вам нужно явно указать соответствие папок, то добавьте опцию: -->

--f1f2 Outbox=Sent

<!-- В данном случае мы указываем, что содержимое папки Outbox ящика-источника следует поместить в папку Sent ящика-приемника.

Еще одной полезной опцией является указание возраста писем, допустим мы хотим перенести корреспонденцию только за текущий год, не проблема, указываем: -->

--maxage 365

<!-- В итоге будут синхронизированы только письма не старше 365 дней.

А что делать с остальными? А можно перенести их в другой, архивный ящик, в этом нам поможет другая опция: -->

--minage 365

<!-- Теперь мы перенесем только письма с возрастом старше одного года.

Также эти опции можно комбинировать, они сочетаются по принципу И: -->

--maxage 730 --minage 365

<!-- Такая конструкция перенесет письма только за прошлый год (не старше двух лет и не моложе года).

А если указать наоборот? -->

--maxage 365 --minage 730

<!-- То мы перенесем все письма за текущий год, и те, которые старше двух лет (не старше 1 года и не моложе 2 лет). -->

<!-- С синтаксисом немного разобрались, но как быть, если ящиков много? Конечно же автоматизировать, для этого в официальной документации приведен пример скрипта: -->

#!/bin/sh
{ while IFS=';' read h1 u1 p1 h2 u2 p2 fake
do
./imapsync --host1 "$h1" --user1 "$u1" --password1 "$p1" \
   --host2 "$h2" --user2 "$u2" --password2 "$p2" \
 --automap --exclude 'Spam|Trash' --delete2 --delete2duplicates --delete2folders --syncinternaldates
done ;} < list.txt

<!-- Данный скрипт не блещет изысканными решениями и прост как табуретка. На его вход подается файл list.txt, который следует создать в одной директории со скриптом и из которого берутся адреса и учетные данные для узлов источника и приемника. Из опций указываем, что копируем с сохранением директорий, не копируем спам и корзину, удаляем письма, которых нет на сервере-источнике, удаляем дубли на сервере-приемнике - удаляем дубли папок и синхронизируем время писем с сервером-приемником. Сам файл file.txt должен содержать строки: -->

host1;user1_1;password11_1;host2;user2_1;password2_1;
host1;user1_2;password11_2;host2;user2_2;password2_2;
host1;user1_3;password11_3;host2;user2_3;password2_3;
host1;user1_4;password11_4;host2;user2_4;password2_4;

<!-- Дополнительные опции вы можете указать после "$@" или передать интерактивно при запуске скрипта, тогда они войдут в переменную $@. -->
