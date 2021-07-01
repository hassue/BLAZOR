using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsSalesApp.Interfaces;

namespace WinFormsSalesApp.Models
{
    class SalesRegion : BaseModel, IActive
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(3)]
        [MaxLength(3)]
        [MinLength(3)]
        public string Code { get; set; }
        [Required]
        public bool Active { get; set; }

        //public ICollection<SalesPerson> salesPeople { get; set; }
        //public ICollection<Sale> salesPeople { get; set; }
        public ObservableListSource<SalesPerson> salesPeople { get; set; }
        public ObservableListSource<Sale> sales { get; set; }
    }
}
