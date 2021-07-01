using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsSalesApp.Interfaces;

namespace WinFormsSalesApp.Models
{
    class SalesPerson : BaseModel, IActive
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public bool Active { get; set; }


        public virtual SalesRegion Region { get; set; }
        [Required]
        public int RegionId { get; set; }

        public ObservableListSource<Sale> sales { get; set; }
    }
}
