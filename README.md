# etsrehber

Docker uzerinde calisacak sekilde Postgre veritabani ve rabbitmq mesaj kuyrugu calistirildi.

docker komutlari : 

sudo docker run --name db-postgres -e POSTGRES_PASSWORD=password -d postgres:14-alpine

sudo docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3-alpine

microservis mantiginda calisacak Rehber.Api ve Report.APi adinda iki proje olusturuldu.

microservislerin ortak olarak kullanabilecegi, entitylerin tanimlandigi Rehber.Data projesi olusturuldu.

Rehber.Data projesine 
EntityFramewrokCore ve Npgsql.EntityFrameworkCore.PostgreSQL kutuphaneleri eklendi.

Microsoft.EntityFrameworkCore.Design

 dotnet ef migrations add InitialCreate --project ../Rehber.Data/Rehber.Data.csproj komutuyla baslangic migrationi olusturuldu
 
dotnet ef database update komutu ile veri tabaninda tablolar olsuturuldu.


