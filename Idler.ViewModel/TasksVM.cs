using GalaSoft.MvvmLight.Command;
using Idler.Model;
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
        private IdleTasks idleTasks = new IdleTasks();
        
        public TasksVM()
        {
            
            AddTask = new RelayCommand(addTask);
            RemoveTask = new RelayCommand(removeTask);

            idleTasks.Add(new IdleTask() { Name = "Damian" });
            idleTasks.Add(new IdleTask() { Name = "Jusia" });
           
        }
        public RelayCommand AddTask { get; private set; }

        public RelayCommand RemoveTask { get; private set; }

        public ObservableCollection<IdleTask> Tasks
        {
            get => idleTasks.Tasks;
            set => idleTasks.Tasks = value;
        }


        private void removeTask()
        {
            Tasks.Clear();
        }

        private void addTask()
        {
            idleTasks.Add(new IdleTask() { Name = "The one" });

        }
    }
}
