# **ServerMonitoring**

## Описание
*ServerMonitor* — это простое консольное приложение, предназначенное для мониторинга доступности серверов по их IP-адресам. Программа периодически отправляет пинг-запросы к серверам, указанных в файле ServersList.txt, и выводит информацию о доступности каждого сервера.

## Функциональность
- Чтение списка серверов из файла ServersList.txt.
- Периодическая проверка доступности серверов с заданным интервалом (по умолчанию 5 минут).
- Подсчет успешных и неуспешных пинг-запросов для каждого сервера.
- Вывод информации о доступности серверов и проценте успешных запросов.

## Установка
1. Убедитесь, что у вас установлен .NET SDK.
2. Скачайте или клонируйте репозиторий с кодом.
3. Пополняйте текстовый файл ServersList.txt в корневом каталоге проекта, содержащий IP-адреса и имена серверов в следующем формате:
```
192.168.1.1, Server1
192.168.1.2, Server2
```
## Использование
1. Откройте проект в вашей IDE (например, Visual Studio).
2. Скомпилируйте проект.
3. Запустите приложение. Оно будет работать до тех пор, пока вы не нажмёте [Enter].
4. После каждого интервала вы увидите вывод о статусе серверов.

> ### **Пример работы кода:**
![image](https://github.com/user-attachments/assets/945a0036-4d77-4424-a79f-4816fd2c44ad)

## Обратная связь
Для вопросов или предложений:

[**Telegram** / *PL9SHY*](https://t.me/pl9shy) 

[**VK** / *Настя Яхнюк*](https://vk.com/nyakhnyuk)
