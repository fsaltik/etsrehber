# etsrehber

Docker uzerinde calisacak sekilde Postgre veritabani ve rabbitmq mesaj kuyrugu calistirildi.

docker komutlari : 

sudo docker run --name db-postgres -e POSTGRES_PASSWORD=password -d postgres:14-alpine

sudo docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3-alpine

microservis mantiginda calisacak Rehber.Api ve Report.APi adinda iki proje olusturuldu.

microservislerin ortak olarak kullanabilecegi, entitylerin tanimlandigi Rehber.Data projesi olusturuldu.

Rehber.Data ve Rehber.Api projelerine
EntityFramewrokCore ve Npgsql.EntityFrameworkCore.PostgreSQL kutuphaneleri eklendi.

Microsoft.EntityFrameworkCore.Design

 dotnet ef migrations add InitialCreate --project ../Rehber.Data/Rehber.Data.csproj komutuyla baslangic migrationi olusturuldu
 
dotnet ef database update komutu ile veri tabaninda tablolar olsuturuldu.

Rehber.Api projesine 
AutoMapper kutuphanesi eklendi.

tablolarda bulunan eksik kolonlar eklendi.
dotnet ef migrations add AddColumntoTables --project ../Rehber.Data/Rehber.Data.csproj
dotnet ef database update

rabbitMq port ayarlama islemi icin duzenlemeler : 
sudo docker commit some-rabbit rabbitmq-test
sudo docker run -p 15672:15672 -td rabbitmq-test
rabbitmqctl add_user 'rehber' '2a55f70a841f18b97c3a7db939b7adc9e34a0f1b'
for v in $(rabbitmqctl list_vhosts --silent); do rabbitmqctl set_permissions -p $v "rehber" ".*" ".*" ".*"; done
rabbitmq-plugins enable rabbitmq_management

rehber.api projesine 
RabbitMQ.Client kutuphanesi eklendi.

rabbitmq baglanti sirasinda hatalar olustugu icin kullanilan image degistirildi.
sudo docker run -it --rm --name rabbitmq-test -p 5672:5672 -p 15672:15672 rabbitmq:3-management

