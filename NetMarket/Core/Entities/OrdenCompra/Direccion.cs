﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrdenCompra
{
    public class Direccion
    {
        public Direccion()
        {
            
        }
        public Direccion(string calle, string ciudad, string codigoPostal)
        {
            Calle = calle;
            Ciudad = ciudad;
            CodigoPostal = codigoPostal;
        }

        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }

    }


}
