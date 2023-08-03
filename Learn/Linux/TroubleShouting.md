# Анализ, оптимизация и аварийные работы в Linux

1. Описание проблемы
2. Сбор информации
3. Формирование теории
4. Тестирование теории
5. Фиксация проблемы
      <!-- Проверяем службу ssh -->
   systemctl status sshd -l
      <!-- Проверяем службу secure -->
   less /var/log/secure

ВНИМАНИЕ!

1. Одно время на всех устройствах
2. Смотрим логи

# Загрузка Linux

1. POST **Проверка конфигурации и железа, аппаратная проблема**
2. BIOS | UEFI **Современные ОС**
3. Boot Device **Загрузочное устройство**
4. MBR (Если BIOS) | UEFI Boot sector (UEFI) **Разметка диска**
5. GRUB2 (Ubuntu CentOS Debian)**Загрузчик ОС Linux выбираем стрелочками**
<!-- Rescue Disk -->
6. Ядро ОС Kernel + INITRAMFS
   <!-- RD.Break
   init=/bin/bash -->
   Kernel Space - его задача контролировать все аппаратные ресурсы
   User space - задача пользовательского ядра это запросить ресурсы у Kernel Space
   INITRAMFS - виртуальный раздел при загрузке ОС откуда берутся все нужные драйвера для инициализации апаратной части ядром
   7.systemd - процесс, который стартуется при запуске ОС и запускает другие процессы
   <!-- system.unit=emergency.target
   system.init=rescue.target -->
   8.Services

# Перенос ОС

<!--
1. Загружаемся с диска
2. Troubleshoting
3. Rescan
Меняем корневой каталог на смонтированны диск. Важно находится в той директории в которой хотим сделать корень
4. chroot /mnt/sysimage
5. теперь при выполнении команд изменения будут происходить на рабочем диске, а не на live-CD -->

# system.unit=emergency.target

<!--
1. При загрузке заходим в Editor
2. Пишем команду
system.unit=emergency.target
3. вводим пароль root-->

# Удаление раздела

fdisk /dev/sda

<!-- смотрим какие есть разделы командой  -->

p

<!-- удаляем раздел -->

d
2
w

<!-- Заходим в редактор Live CD. Видим, что нет раздела с ОС -->

lsblk

<!-- Пробуем создать раздел -->

fdisk /dev/sda
n > p > 2

<!-- Создали раздел. Смотрим ег командой "P" и у нег такойже ID Нужно его сменить -->

t > 2 > L > 8e > p