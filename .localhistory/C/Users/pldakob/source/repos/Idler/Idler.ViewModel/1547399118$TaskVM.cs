using Idler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idler.ViewModel
{
    public class TaskVM : IdleTask, INotifyPropertyChanged
    {
        string name;
        public override string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
