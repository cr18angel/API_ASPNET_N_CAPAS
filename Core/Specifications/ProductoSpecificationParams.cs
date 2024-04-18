using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoSpecificationParams
    {
        public string Sort { get; set; }


        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }


        //public int MarcaId { get; set; }
        public string Marca { get; set; }

        public string pageIndex { get; set; }

        public int PageIndex { get; set; } = 1;

        private const int MaxPageSize = 50;
        private int _pageSize = 20;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Search { get; set; }
    }
}
