
# BIM472-Web-Project

Bu proje BIM472 dersi için geliştirilmiş kişisel bir blog sitesidir.

- .Net Core MVC ile geliştirilmiştir.
- Authentication ve Authorizaiton ile güvenlik sağlanmıştır.
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
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/8588d4ea-cf7f-4aa1-907d-5c775d140772)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/6ecb5ac6-34ce-4243-b57f-4366b5ce56e6)
![image](https://github.com/kadirdemirkaya/BIM472-Web-Project/assets/126807887/06aad008-1c5e-48fb-90a3-545d78391350)
