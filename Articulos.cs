using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    public class Articulos
    {
        public Articulos(long Ariculoid, string Detalle) 
        {
            Articulosid = Ariculoid;
            this.Detalle = Detalle;
        }
        public long Articulosid { get; set; }
        public string Detalle { get; set; }
    }
}
