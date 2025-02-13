using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.Queries.DTOs
{
    public class ProductInStockDTOs
    {
        //Propiertes

        [Key]
        public int ProductInStockId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Stock {  get; set; }

        
    }
}
