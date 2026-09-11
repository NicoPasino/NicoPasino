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
├───NicoPasino #(Vistas y Controladores)
│   └───Controllers
|           VentasController.cs #(Controller principal)
|           Ventas.Clientes.cs
|           Ventas.Productos.cs
|           Ventas.Ventas.cs
├───NicoPasino.Core #(Modelos e Interfaces)
│   ├───DTO
│   ├───Interfaces
│   ├───Mapper
│   ├───Modelos
|   |       Categoria.cs
|   |       Cliente.cs
|   |       Producto.cs
|   |       Venta.cs
|   |       Ventaporproducto.cs
│   └───Utils
├───NicoPasino.Infra #(Conexiones con DB)
│   ├───Data
|   |       ventasdbContext.cs
│   └───Repositorio
└───NicoPasino.Servicios #(Lógica de Negocio)
    └───Servicios
            CategoriaServicio.cs
            ClienteServicio.cs
            ProductoServicio.cs
            VentaServicio.cs
```

## 🧑‍💻 Autor:
Nicolás Pasino - nico_pasino@hotmail.com

[LinkedIn](https://www.linkedin.com/in/nicolas-pasino/) | [Portfolio](https://nicopasino.space)
