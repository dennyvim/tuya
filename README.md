# Prueba técnica Tuya
Por: Denny Edilberto Villalobos Martínez - Practicante
 
## Requisitos

 - .NET Core 3.1
 - Motor SQL Server 
 - Entity Framework CLI 

## Instalación
Para correr este API primero debemos hacer la publicación por lo que ejecutaremos el siguiente comando sobre el proyecto Tuya.Pagos.WebAPi.csproj

    dotnet publish -C release

Con este comando quedará nuestro proyecto publicado en /bin/release/netcoreapp3.1
Seguido de esto entonces dentro de esta carpeta buscaremos el archivo appsetting.json donde reemplazaremos nuestro ConnectionString por el correspondiente local de nuestra maquina.
Ubicados en la carpeta Tuya.Pagos.Data debemos correr un comando de Entity Framework 

    dotnet ef database update
    
De esta forma nuestra base de datos tendrá las tablas necesarias y utilizadas por nuestro API
Ejecutamos el Tuya.Pagos.WebApi y se abrirá nuestro navegador.

## Explicación

Para el desarrollo de la API se planteó desde el principio se planteo como una arquitectura en capas (NLayer Architecture) siguiendo los principios de DDD (Domain Driven Desing).
El API está divido entonces en las siguientes capas con las siguientes responsabilidades:

 - Presentación 
	 Interacciones con el usuario 
 - Aplicación
	 Capa intermedia orquestando elementos comerciales para tareas especificas
 - Dominio
	 Objetos comerciales y reglas 
 - Infraestructura
	 Capacidades técnicas genericas 

**Paso 1 - Poblar**
Poblar nuestros productos desde el endpoint CrearProducto
Poblar nuestros usuarios desde el endpoint CrearUsuario

![endpoints](https://i.ibb.co/cDM2K1L/Captura-de-Pantalla-2021-06-21-a-la-s-12-07-27-a-m.png)

Despues de haber poblado estas podemos prodecer a realizar el pago de los productos en el endpoint /Pagos
que nos solicitara el siguiente cuerpo, una lista de productos y el id del usuario.

```
{
  "productos": [
    {
      "productId": 0,
      "price": 0
    }
  ],
  "userId": 0
```
 y donde recibiremos como respuesta entonces como esta especificando los productos comprados, nuestra transaccion, el estado del envio y el total de la operación.


    {
      "exitoso": true,
      "descripcion": "OK",
      "resultado": {
        "evento": {
          "eventoId": 10,
          "estado": "PEDIDO_ENVIADO"
        },
        "transaccion": {
          "idTransaccion": 11,
          "productos": [
            {
              "productId": 1,
              "price": 500
            }
          ],
          "usuarioId": 1,
          "totalCompra": 500
        }
      }
    }


### Librerias

 - Entity Framework Core
	 ORM utilizado para acceso a datos
 - Swagger
	 Documentación de la API

### Patrones 
- Inyección de dependencias
- Repository
- Unidad de trabajo

## Deuda técnica

 - Logger
	 Para hacer trazabilidad del funcionamiento de la app
- Mapper
	Mapeo de objetos más eficiente y no creación de multiples objetos
- Pruebas unitarias 	
- Mejora en servicios de creacion de productos y usuarios
- Validaciones 
