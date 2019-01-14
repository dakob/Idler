using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idler.ViewModel
{
    public class TasksVM : BindableBase
    {

        public TasksVM()
        {
            Tasks.Add(new TaskVM() { Name = "Damian" });
            Tasks.Add(new TaskVM() { Name = "Jusia" });
            
        }
        public RelayCommand AddTask { get; private set; }

        public RelayCommand RemoveTask { get; private set; }

        public ObservableCollection<TaskVM> Tasks { get; set; } = new ObservableCollection<TaskVM>();

        public TasksVM()
        {
            AddTask = new RelayCommand(addTask);
            RemoveTask = new RelayCommand(removeTask);

        }

        private void removeTask()
        {
            Tasks.Clear();
        }

        private void addTask()
        {
            Tasks.Add(new TaskVM() { Name = "The one" });
            
        }
    }
}
