# 📌 API Sistema-Ventas (demo)
FrontEnd Repo: [Sistema-Ventas](https://github.com/NicoPasino/sistema-ventas)

## 🛠️ Tecnologías utilizadas:
- Herramientas: `.NET`.
- Lenguajes: `C#`.
- Frameworks: `Entity Framework`, `ASP.NET`.
- Base de datos: `MySql`.
- Estructura: `The Clean Architecture`.


## 📦 Estructura principal del proyecto
```bash
├───NicoPasino #(Controladores)
│   ├─── Controllers
│   │     ├─ VentasController.cs
│   │     ├─ Ventas.Clientes.cs
│   │     ├─ Ventas.Productos.cs
│   │     └─ Ventas.Ventas.cs
│   └─── Program.cs
|
├───NicoPasino.Core #(Modelos e Interfaces)
│   ├─── DTO
│   ├─── Interfaces
│   ├─── Mapper
│   ├─── Modelos
|   |     ├─ Categoria.cs
|   |     ├─ Cliente.cs
|   |     ├─ Producto.cs
|   |     ├─ Venta.cs
|   |     └─ Ventaporproducto.cs
│   └─── Utils
|
├───NicoPasino.Infra #(Conexiones con DB)
│   ├─── Data
|   |     └─ ventasdbContext.cs
│   └─── Repositorio
|
└───NicoPasino.Servicios #(Lógica de Negocio)
    └─── Servicios
          ├─ CategoriaServicio.cs
          ├─ ClienteServicio.cs
          ├─ ProductoServicio.cs
          └─ VentaServicio.cs
```

## 📦 Endpoints
```bash
├───/api/ventas/productos/...
│   ├─── (GET)            Trae todos los productos
│   ├─── (GET /[id])      Trae un producto por ID
│   ├─── (GET /search/[campo]/[valor?]) Trae un producto por campo y valor(opcional)
│   ├─── (POST)           Agrega un producto
│   ├─── (PUT)            Modifica un producto
│   └─── (DELETE /[id])   Elimina un producto
|
├───/api/ventas/clientes/...
│   ├─── (GET)            Trae todos los clientes
|   ├─── (GET /[id])      Trae un cliente por ID
|   ├─── (GET /search/[campo]/[valor?]) Trae un cliente por campo y valor(opcional)
|   ├─── (POST)           Agrega un cliente
|   ├─── (PUT)            Modifica un cliente
|   └─── (DELETE /[id])   Elimina un cliente
|
└───/api/ventas/ventas/...
    ├─── (GET)            Trae todas las ventas
    ├─── (GET /[id])      Trae una venta por ID
    ├─── (GET /search/[campo]/[valor?]) Trae una venta por campo y valor(opcional)
    ├─── (POST)           Agrega una venta
    ├─── (PUT)            Modifica una venta
    └─── (DELETE /[id])   Elimina una venta
```

## 🧑‍💻 Autor:
Nicolás Pasino - nico_pasino@hotmail.com

[LinkedIn](https://www.linkedin.com/in/nicolas-pasino/) | [Portfolio](https://nicopasino.space)
