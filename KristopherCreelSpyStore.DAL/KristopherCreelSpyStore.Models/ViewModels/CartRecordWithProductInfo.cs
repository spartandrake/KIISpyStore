using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using KristopherCreelSpyStore.Models.Entities.Base;
using KristopherCreelSpyStore.Models.ViewModels.Base;


namespace KristopherCreelSpyStore.Models.ViewModels
{
    public class CartRecordWithProductInfo : ProductAndCategoryBase
    {
        [DataType(DataType.Date), Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        public int? CustomerId { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency), Display(Name = "Line Total")]
        public decimal LineItemTotal { get; set; }
    }
}
