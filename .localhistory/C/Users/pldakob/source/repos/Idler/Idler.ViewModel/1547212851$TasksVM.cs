using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idler.ViewModel
{
    public class TasksVM : BindableBase
    {
        public RelayCommand AddTask { get; private set; }

        public RelayCommand RemoveTask { get; private set; }


        public TasksVM()
        {
            AddTask = new RelayCommand(addTask);
            RemoveTask = new RelayCommand(removeTask);

        }
    }
}
