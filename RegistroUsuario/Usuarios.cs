using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistroUsuario
{
    public class Usuarios
    {
        public Int32 Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Pais { get; set; }
        public string FechaNacimiento { get; set; }

        //constructor por defecto
        public Usuarios() { }

        //constructor con 8 argumentos
        public Usuarios(Int32 pId, string pNombre, string pApellido, string pUsuario, string pCorreo, string pContraseña, string pPais, string pFechaNacimiento)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Usuario = pUsuario;
            this.Correo = pCorreo;
            this.Contraseña = pContraseña;
            this.Pais = pPais;
            this.FechaNacimiento = pFechaNacimiento;
        }


    }
}