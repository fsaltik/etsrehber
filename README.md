# etsrehber

Docker uzerinde calisacak sekilde Postgre veritabani ve rabbitmq mesaj kuyrugu calistirildi.

docker komutlari : 

sudo docker run --name db-postgres -e POSTGRES_PASSWORD=password -d postgres:14-alpine

sudo docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3-alpine





