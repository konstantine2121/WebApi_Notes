

```
dotnet ef migrations add "Init" --startup-project .\WebApi_Notes\WebApi_Notes.csproj --project .\DataAccess\DataAccess.csproj
```
Если хапнули ошибку вида

> Не удалось выполнить, поскольку указанная команда или файл не найдены.


```

dotnet tool install --global dotnet-ef --version 9.*
```