
using System.Windows.Controls;
using System.Windows.Documents;

using System.Windows;
using Idler.UIAdorners;
using Shared;
using Idler.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace Idler.WindowHandling
{
    class AddTaskWindowHandling : Window, IOpenWindow
    {
        private readonly Window mainWindow;
       private readonly DockPanel dockPanel;
        private readonly GreyOutAdorner adorner;
        readonly TasksVM TasksVM;

        public AddTaskWindowHandling(Window mainWindow, GreyOutAdorner adorner, DockPanel dockPanel, TasksVM tasksVM)
        {
            this.mainWindow = mainWindow;
            this.dockPanel = dockPanel;
            this.adorner = adorner;
            TasksVM = tasksVM;

            OpenWindow();
        }

        public void OpenWindow()
        {
            AttachAdorner(dockPanel, adorner);
            TaskVM taskVM = new TaskVM();
            var addTask = new AddTaskView()
            {
                Owner = GetWindow(mainWindow), DataContext = taskVM
                
            };

            if(addTask.ShowDialog().Value)
            {
                TasksVM.Tasks.Add(taskVM);
            }
        }

        private void AttachAdorner(DockPanel dockPanel, GreyOutAdorner adorner)
        {
            dockPanel.UpdateLayout();
            AdornerLayer parentAdorner = AdornerLayer.GetAdornerLayer(dockPanel);
            parentAdorner.Add(adorner);
        }

        private void DettachAdorner(DockPanel dockPanel, GreyOutAdorner adorner)
        {
            AdornerLayer parentAdorner = AdornerLayer.GetAdornerLayer(dockPanel);
            parentAdorner.Remove(adorner);
        }

        public void CloseWindow()
        {
            DettachAdorner(dockPanel, adorner);
            this.Close();
        }
    }
}
