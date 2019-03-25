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

            Messenger.Default.Register<NotificationMessage>(this, "Save state", (message) => PutState(message));
            Messenger.Default.Register<NotificationMessage>(this, "Get state", (message) => GetState(message));
            Messenger.Default.Register<TaskVM>(this, "RemoveTask", (message) => RemoveTask(message));
        }

        private void PutState(NotificationMessage message)
        {
            IdleTasks tasks = new IdleTasks();
            foreach (var task in Tasks)
            {
                tasks.Add(new IdleTask()
                {
                    Name = task.Name,
                    StartDay = task.DateTimeStart.Day,
                    StartHour = task.DateTimeStart.Hour,
                    StartMinutes = task.DateTimeStart.Minute,
                    StartMonth = task.DateTimeStart.Month,
                    EndHour = task.TSpan.Hours,
                    EndDay = task.TSpan.Days,
                    EndMinutes = task.TSpan.Minutes,
                    Status = task.Status,
                    StatusText = task.StatusText
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
                var dt = new DateTime(
                       task.StartYear == 0 ? DateTime.Now.Year : task.StartYear,
                       task.StartMonth == 0 ? DateTime.Now.Month : task.StartMonth,
                       task.StartDay == 0 ? DateTime.Now.Day : task.StartDay,
                       task.StartHour,
                       task.StartMinutes,
                       0);

                Tasks.Add(new TaskVM()
                {
                    Name = task.Name,

                    DateTimeStart = dt,
                    TSpan = new TimeSpan(task.EndHour, task.EndMinutes, 0),
                    TimeSpan = String.Format("{0:0}D/{1:00}:{2:00}.{3:00}", 0, task.EndHour, task.EndMinutes, 0),
                    Status = task.Status,
                    StatusText = task.StatusText
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
