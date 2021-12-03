using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TapiaExamen
{
    public class RegistroUsuario
    {
        [PrimaryKey, AutoIncrement]
        public int id { set; get; }
        [MaxLength(50)]
        public string Usuario { set; get; }
        [MaxLength(10)]
        public string Contrasenia { set; get; }
    }
}
