
# BIM472-Web-Project

Bu proje BIM472 dersi için geliştirilmiş kişisel bir blog sitesidir.

- .Net Core MVC ile geliştirilmiştir.
- Authentication ve Authorization ile güvenlik sağlanmıştır.
- Role bazlı endpointler yönetilmiştir.
- CQRS - MediatR uygulanmıştır.
- File içeriği ile isteklere Log'lanmıştır.
- Veritabanı olarak SqlServer kullanılmıştır.

## Dağıtım

Bu projeyi çalıştırmak için şu adımları uygulayabilirsiniz.

Poreyi tanımlayacağınız dosya yoluna girip aşağıdaki kodu terminale yazarak klonlayabilirsiniz
```bash
 https://github.com/kadirdemirkaya/BIM472-Web-Project.git
```

ardından appsettings.json file içeriği değiştirilmeli
```bash
   "SqlServerOptions": {
    "SqlConnection": "Mssql Url"
    }
```
Hazır migration'lar uygulanmalı termainali açıp şu komutlar yazılmalı
```bash
    dotnet ef database update
```
Sonra proje terminale aşağıdaki kod yazılarak ayağa kaldırılabilir.
```bash
    dotnet run
```

  
## Kullanılan Teknolojiler

**İstemci:** Html, CSS 

**Sunucu:** .Net Core, Mssql

  
## Resimler
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/fc9f8f77-212a-46e6-9376-e017aec04d6c)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/1b8a3f86-3d47-4a64-9596-f85e68bc17d9)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/482172d2-6e04-48be-8e4a-f2f58bd941a6)
![Ekran görüntüsü 2024-06-04 220136](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/14b64ef0-675f-4efd-8938-8343996fc4a8)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/936f6d5c-3d25-4002-899f-56d6337d8cd9)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/0abcba57-1eee-494a-8260-7c9d5b7b7332)

