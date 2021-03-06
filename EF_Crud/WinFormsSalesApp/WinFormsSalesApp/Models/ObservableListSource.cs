using Microsoft.EntityFrameworkCore; // .ToBindingList()
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel; // for ObservableCollection<T>
using System.ComponentModel;    // for ObservableCollection<T>
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsSalesApp.Models
{
    class ObservableListSource<T> : ObservableCollection<T>, IListSource where T : BaseModel
    {

        private IBindingList _bindingList;
        bool IListSource.ContainsListCollection { get { return false; } }

        IList IListSource.GetList() {
            return _bindingList ?? (_bindingList = this.ToBindingList());
        }

    }
}
