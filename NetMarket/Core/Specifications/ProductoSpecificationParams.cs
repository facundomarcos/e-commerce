using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoSpecificationParams
    {
        public int? Marca { get; set; }
        public int? Categoria { get; set; }
        public string Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        private const int MaxPageSize = 50;
        private int _pageSize = 3;
        public int PageSize
        {
            get => _pageSize;
            //controla el limite de elementos que devuelve -> no va a devolver mas de 50
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value ;
        }


    }
}
