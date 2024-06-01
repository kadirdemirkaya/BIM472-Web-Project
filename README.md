
# BIM472-Web-Project

Bu proje BIM472 dersi için geliştirilmiş kişisel bir blog sitesidir.

- .Net Core MVC ile geliştirilmiştir.
- Authentication ve Authorization ile güvenlik sağlanmıştır.
- CQRS - MediatR uygulanmıştır.
- File içeriği ile isteklere Log'lanmıştır.

## Dağıtım

Bu projeyi çalıştırmak için şu adımları uygulayabilirsiniz.

appsettings.json file içeriği değiştirilmeli
```bash
   "SqlServerOptions": {
    "SqlConnection": "Mssql Url"
    }
```
Hazır migration'lar uygulanmalı termainali açıp şu komutlar yazılabilir
```bash
    dotnet ef database update
```
Sonra proje terminale bu kod yazılarak ayağa kaldırılabilir.
```bash
    dotnet run
```

  
## Kullanılan Teknolojiler

**İstemci:** Html, CSS, Typescript 

**Sunucu:** .Net Core, Mssql

  
## Resimler
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/fc9f8f77-212a-46e6-9376-e017aec04d6c)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/1b8a3f86-3d47-4a64-9596-f85e68bc17d9)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/482172d2-6e04-48be-8e4a-f2f58bd941a6)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/0abcba57-1eee-494a-8260-7c9d5b7b7332)

