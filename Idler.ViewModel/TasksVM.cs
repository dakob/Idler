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
            ClearTasks = new RelayCommand(clearTasks);

            Messenger.Default.Register<NotificationMessage>(this, "Save state", (message) => SaveState(message));
            Messenger.Default.Register<NotificationMessage>(this, "Get state", (message) => GetState(message));
            Messenger.Default.Register<TaskVM>(this, "RemoveTask", (message) => RemoveTask(message));
        }

        private void SaveState(NotificationMessage message)
        {
            IdleTasks tasks = new IdleTasks();
            foreach (var task in Tasks)
            {
                tasks.Add(new IdleTask()
                {
                    Name = task.Name,
                    SDay = task.DTStart.Day,
                    SHour = task.DTStart.Hour,
                    SMinutes = task.DTStart.Minute,
                    SMonth = task.DTStart.Month,
                    EHour = task.DTStop.Hour,
                    EMinutes = task.DTStop.Minute

                });
            }
            new Serializer().SaveState(tasks);
        }

        private void GetState(NotificationMessage message)
        {
            IdleTasks tasks = new Serializer().GetState();
            Tasks = new ObservableCollection<TaskVM>();
            foreach (var task in tasks)
            {
                Tasks.Add(new TaskVM()
                {
                    Name = task.Name,
                    DTStart = new DateTime(DateTime.Now.Year, task.SMonth == 0 ? DateTime.Now.Month : task.SMonth, task.SDay == 0 ? DateTime.Now.Day : task.SDay, task.SHour, task.SMinutes, 0),
                    DateStart = new DateTime(DateTime.Now.Year, task.SMonth == 0 ? DateTime.Now.Month : task.SMonth, task.SDay == 0 ? DateTime.Now.Day : task.SDay, task.SHour, task.SMinutes, 0).ToShortDateString() + "/" + new DateTime(DateTime.Now.Year, task.SMonth == 0 ? DateTime.Now.Month : task.SMonth, task.SDay == 0 ? DateTime.Now.Day : task.SDay, task.SHour, task.SMinutes, 0).ToLongTimeString(),
                DTStop = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, task.EHour, task.EMinutes, 0)
                });
            }
        }

        public RelayCommand AddTask { get; private set; }

        public RelayCommand ClearTasks { get; private set; }

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

        private void clearTasks()
        {
            Tasks.Clear();
        }

        private void RemoveTask(TaskVM message)
        {
            Tasks.Remove(tasks.First(t => t.Id == message.Id));
        }

        private void addTask()
        {
            Messenger.Default.Send(WindowTypes.AddTask);
        }
    }

}
