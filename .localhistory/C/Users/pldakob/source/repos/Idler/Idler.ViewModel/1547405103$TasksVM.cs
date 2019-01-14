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
            AddTask = new RelayCommand(addTask);
            RemoveTask = new RelayCommand(removeTask);

            Tasks.Add(new TaskVM() { Name = "Damian" });
            Tasks.Add(new TaskVM() { Name = "Jusia" });

            Tasks.CollectionChanged += (send, args) => OnPropertyChanged("Tasks");
            
        }
        public RelayCommand AddTask { get; private set; }

        public RelayCommand RemoveTask { get; private set; }

        ObservableCollection<TaskVM> tasks;
        public ObservableCollection<TaskVM> Tasks
        {
            get
            {
                if (tasks == null)
                    tasks = new ObservableCollection<TaskVM>();

                return tasks;
            }
            set
            {
                SetProperty(ref tasks, value);
            }
        }


        private void removeTask()
        {
            Tasks.Clear();
        }

        private void addTask()
        {
            Tasks.Add(new TaskVM() { Name = "The one" });
            OnPropertyChanged("Tasks");
        }
    }
}
