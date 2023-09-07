# Защита от СПАМа

<!-- Обновление правил в SpamAssassin -->

su - zimbra -c "zmlocalconfig -e antispam_enable_rule_updates=true"

su - zimbra -c "zmlocalconfig -e antispam_enable_restarts=true"

<!-- После перезапустим соответствующие службы: -->

su - zimbra -c "zmamavisdctl restart"

su - zimbra -c "zmmtactl restart"

<!-- Черные списки -->
<!-- Чтобы усилить защиту, разрешим проверку отправителя в черных списках: -->

su - zimbra -c 'zmprov mcf zimbraMtaRestriction "reject_rbl_client psbl.surriel.com"'

<!-- Настройка mynetworks -->

После установки Zimbra в опции postfix mynetworks может оказаться подсеть, в которой находится наш сервер. На практике, это приводит к возможности отправки сообщений без пароля, что в свою очередь, позволяет любому вирусу в нашей сети делать нелегальную рассылку.

Задаем для mynetworks только адрес локальной петли и адрес сервера:

su - zimbra -c 'zmprov ms m.snabavangard.ru zimbraMtaMyNetworks "127.0.0.0/8 10.200.202.147/32"'

- где 192.168.1.15 — IP-адрес нашего почтового сервера.

<!-- Перезапускаем postfix: -->

su - zimbra -c 'postfix reload'

<!-- Проверить текущую настройку можно командой: -->

su - zimbra -c 'postconf mynetworks'

<!-- Дополнительные настройки -->
<!-- Добавление отправителей в белый список
Может возникнуть ситуация, при которой нам нужно изменить назначение СПАМ-балов для некоторых отправителей. Для этого открываем файл: -->

vi /opt/zimbra/conf/amavisd.conf.in

<!-- Находим строку: -->

{ # a hash-type lookup table (associative array)
...
}

<!-- ... и внутри фигурных скобок {} добавим нужный нам домен или конкретного отправителя: -->

...
'snabavangard.ru' => -10.0,
'sender@dmosk2.ru' => -10.0,
}

<!-- После настройки перезапускаем amavis: -->

su - zimbra -c "zmamavisdctl stop && zmamavisdctl start"

<!-- Размер отправляемого сообщения
Задать максимальный размер сообщений можно командой: -->

su - zimbra -c 'zmprov modifyConfig zimbraMtaMaxMessageSize 31457280'

<!-- * в данном примере мы задаем максимальный размер сообщения 30 мб. -->

<!-- После перезапускаем postfix: -->

su - zimbra -c "postfix reload"
