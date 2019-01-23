using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Idler.Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Enums;

namespace Idler.ViewModel
{
    public class TasksVM : BindableBase
    {

        public TasksVM()
        {
            Tasks = new ObservableCollection<TaskVM>();
            AddTask = new RelayCommand(addTask);
            RemoveTask = new RelayCommand(removeTask);

            //Tasks.Add(new TaskVM() { Name = "Damian" });
            //Tasks.Add(new TaskVM() { Name = "Jusia" });
           
        }
        public RelayCommand AddTask { get; private set; }

        public RelayCommand RemoveTask { get; private set; }

        ObservableCollection<TaskVM> tasks;
        public ObservableCollection<TaskVM> Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                SetProperty(ref tasks, value);
            }
        }

        private AddTaskVM addTaskVM;

        public AddTaskVM AddTaskVM
        {
            get { return addTaskVM; }
            set { SetProperty(ref addTaskVM, value); }
        }

        private void removeTask()
        {
            Tasks.Clear();
        }

        private void addTask()
        {
            Messenger.Default.Send(WindowTypes.AddTask);
            //Tasks.Add(new TaskVM() { Name = "The one", Id = Tasks.Count + 1 });


        }
    }


    public class ShowChildWindowMessage : MessageBase { }
    public class HideChildWindowMessage : MessageBase { }

}
