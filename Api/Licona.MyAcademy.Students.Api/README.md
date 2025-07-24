# 🧠 StudentApp — Microservicio de Alumnos con Kafka, MongoDB y SQL Server

Este proyecto es una aplicación de ejemplo construida con .NET siguiendo el patrón de **Clean Architecture** y utilizando **Event Sourcing**. Su objetivo es aprender y practicar:

- Producción y consumo de eventos en **Kafka**
- Almacenamiento de eventos en **MongoDB**
- Persistencia final en **SQL Server**
- Separación de capas con principios DDD

---

## 🚀 Tecnologías

- [.NET 8](https://dotnet.microsoft.com/)
- [Apache Kafka](https://kafka.apache.org/)
- [MongoDB](https://www.mongodb.com/)
- [SQL Server 2022](https://www.microsoft.com/en-us/sql-server/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 🛠 Requisitos

- Docker Desktop o Docker CLI
- .NET SDK 8.0 o superior
- Git

---

# ⚙️ Paso a paso para levantar el proyecto

## 1️⃣ Clonar el repositorio

git clone https://github.com/tu-usuario/StudentApp.git
cd StudentApp

## 2️⃣ Levantar servicios de infraestructura

docker compose up -d

Esto iniciará:

- Kafka (con Zookeeper)

- MongoDB

- SQL Server

⏳ La primera vez puede tardar un poco, especialmente SQL Server.

## 3️⃣ Verificar que los contenedores esten corriendo

docker ps

## 4️⃣ Compila el proyecto para verificar que no hay errores

cd Api
dotnet build

## 🧪  Finalmente ejecuta las pruebas unitarias

## 📄 Scripts útiles 

### Levantar servicios
docker compose up -d

### Detener servicios
docker compose down

### Ver logs del consumer
docker logs <nombre_del_contenedor> -f

## ✨ Créditos y licencia

Este proyecto fue creado con fines educativos para practicar arquitecturas modernas con eventos.

Creado por [Jose Ignacio Licona. ](https://dotnet.microsoft.com/)

