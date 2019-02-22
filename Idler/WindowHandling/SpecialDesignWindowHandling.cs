
using System.Windows.Controls;
using System.Windows.Documents;

using System.Windows;
using Idler.UIAdorners;
using Shared;
using Idler.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace Idler.WindowHandling
{
    class SpecialDesignWindowHandling : Window, IOpenWindow
    {
        private Window mainWindow;
       private DockPanel dockPanel;
        private GreyOutAdorner adorner;
        TasksVM TasksVM;

        public SpecialDesignWindowHandling(Window mainWindow, GreyOutAdorner adorner, DockPanel dockPanel, TasksVM tasksVM)
        {
            this.mainWindow = mainWindow;
            this.dockPanel = dockPanel;
            this.adorner = adorner;
            TasksVM = tasksVM;

            OpenWindow();
            
            Messenger.Default.Register<NotificationMessage>(this, "AddTaskView", Close);
        }

        public void OpenWindow()
        {
            Messenger.Default.Register<NotificationMessage>(this, "AddTaskView", Close);
            AttachAdorner(dockPanel, adorner);

            var addTask = new AddTaskView()
            {
                Owner = GetWindow(mainWindow)
            };
            addTask.ShowDialog();
            DettachAdorner(dockPanel, adorner);
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
            CloseWindow();
        }

        public void Close(NotificationMessage message)
        {
            DettachAdorner(dockPanel, adorner);
            this.Close();
        }

        public void CloseWindow()
        {
            this.Close();
        }
    }
}
