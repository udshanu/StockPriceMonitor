using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Entities.Models.Common
{
    public abstract class Entity
    {
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string CreatedBy { get; set; }

        public DateTime? DateLastUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
