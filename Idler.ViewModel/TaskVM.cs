using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idler.ViewModel
{
    public class TaskVM : BindableBase
    {
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
             }
        }
        
    }
}
