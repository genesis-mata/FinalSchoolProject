using System.Data;

namespace CapaControlador
{
    public class Negocios
    {
        private CapaModelo.Transacciones Modelo;

        public Negocios()
        {
            this.Modelo = new CapaModelo.Transacciones();
        }

        public bool Configurar_BD(string Servidor = "127.0.0.1", string Puerto = "1433", string Usuario = "sa", string Password = "g3n3s1sm@t@", string DB = "TPV")
        {
            bool Resultado = false;
            if (this.Modelo.Configurar_Base_Datos(Servidor, Puerto, Usuario, Password, DB))
            {
                Resultado = true;
            }
            return Resultado;
        }

        public bool Estado_BD()
        {
            bool Resultado = false;

            if (this.Modelo.Estado_BaseDatos().Equals(true))
            {
                Resultado = true;
            }

            return Resultado;
        }

        public bool Prueba_Conexion()
        {
            return this.Modelo.Probar_Conexion();
        }

        public bool Insertar_Categoría(string Nombre)
        {
            return this.Modelo.Trasaccion_Categorias(1, 0, Nombre);
        }

        public DataTable Todos_Productos()
        {
            return this.Modelo.Todos_Productos();
        }

        public bool IngresarApp(string Usuario, string Password)
        {
            bool Resultado = false;

            if (this.Modelo.Transaccion_Usuarios(5, 0, Usuario, Password).Equals(true))
            {
                Resultado = true;
            }

            return Resultado;
        }

        public string[] Datos_Usuario()
        {
            string[] Datos = this.Modelo.Usuario_Actual();
            return Datos;
        }

        public void Insertar_Producto(string p1, string p2, string p3, string p4, string p5, string p6, double p7, int p8)
        {
            this.Modelo.Insertar_Producto(p1, p2, p3, p4, p5, p6, p7, p8);
        }

        public void Eliminar_Producto(string p)
        {
            this.Modelo.Eliminar_Producto(p);
        }

        public void Insertar_Usuario(string Usuario, string Password, int NivelAcceso, string Nombre1, string Nombre2, string Apellido1, string Apellido2, string Direccion1, string Direccion2, string Municipio, string Ciudad, string Estado, int CP)
        {
            this.Modelo.Insertar_Usuario(Usuario, Password, NivelAcceso, Nombre1, Nombre2, Apellido1, Apellido2, Direccion1, Direccion2, Municipio, Ciudad, Estado, CP);
        }

        public void Eliminar_Usuario(string p)
        {
            this.Modelo.Eliminar_Usuario(p);
        }

        public void Insertar_Venta(DataTable Carrito, string Usuario, double Precio)
        {
            this.Modelo.Insertar_Venta(Carrito, Usuario, Precio);
        }
    }
}
