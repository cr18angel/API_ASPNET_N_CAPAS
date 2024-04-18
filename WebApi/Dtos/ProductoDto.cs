﻿using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Dtos
{
    public class ProductoDto
    {

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }


        public int MarcaId { get; set; }
        public string Marca { get; set; }





        public decimal Precio { get; set; }

        public string Imagen { get; set; }
    }
}
