@echo off
setlocal enabledelayedexpansion

:: Запуск Docker Compose
docker-compose up -d --build
if errorlevel 1 (
    echo Возникла ошибка при запуске Docker Compose.
    exit /b 1
)

:: Удаление базы данных
docker exec -it api-service dotnet ef database drop -f
if errorlevel 1 (
    echo Возникла ошибка при удалении базы данных.
    exit /b 1
)

:: Удаление миграций
docker exec -it api-service dotnet ef migrations remove
if errorlevel 1 (
    echo Возникла ошибка при удалении миграций.
    exit /b 1
)

:: Добавление новой миграции
docker exec -it api-service dotnet ef migrations add 0001_initial
if errorlevel 1 (
    echo Возникла ошибка при добавлении миграции.
    exit /b 1
)

:: Применение миграций к базе данных
docker exec -it api-service dotnet ef database update
if errorlevel 1 (
    echo Возникла ошибка при обновлении базы данных.
    exit /b 1
)

:: Успешное завершение
echo Миграции успешно выполнены.
exit /b 0
