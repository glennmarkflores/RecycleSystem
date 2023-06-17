using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecycleSystem.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        
        public int TypeModelId { get; set; }
        
        public TypeModel TypeModel { get; set; }
        
        public decimal Weight { get; set; }

        [DisplayName("Computed Rate")]
        public decimal ComputedRate { get; set; }
        
        [MaxLength(150)]
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
    }
}