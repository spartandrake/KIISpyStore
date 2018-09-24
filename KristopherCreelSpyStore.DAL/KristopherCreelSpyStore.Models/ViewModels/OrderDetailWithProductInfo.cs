using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KristopherCreelSpyStore.Models.Entities.Base;
using KristopherCreelSpyStore.Models.ViewModels.Base;

namespace KristopherCreelSpyStore.Models.ViewModels
{
    public class OrderDetailWithProductInfo : ProductAndCategoryBase
    {
        public int OrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DataType(DataType.Currency), Display(Name = "Total")]
        public decimal? LineItemTotal { get; set; }
    }
}
