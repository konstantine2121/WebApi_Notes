Создаем скрипты для инициализации базы

```
dotnet ef migrations add "Init" --startup-project .\WebApi_Notes\WebApi_Notes.csproj --project .\DataAccess\DataAccess.csproj
```
Если хапнули ошибку вида

> Не удалось выполнить, поскольку указанная команда или файл не найдены.


```

dotnet tool install --global dotnet-ef --version 9.*
```

Накатываем скрипты на СУБД

```
dotnet ef database update --startup-project .\WebApi_Notes\WebApi_Notes.csproj --project .\DataAccess\DataAccess.csproj
```
