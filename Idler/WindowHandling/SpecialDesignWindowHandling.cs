
using System.Windows.Controls;
using System.Windows.Documents;

using System.Windows;
using Idler.UIAdorners;
using Shared;

namespace Idler.WindowHandling
{
    class SpecialDesignWindowHandling : Window, IOpenWindow
    {
        private Window mainWindow;
       private DockPanel dockPanel;
        private GreyOutAdorner adorner;

        public SpecialDesignWindowHandling(Window mainWindow, GreyOutAdorner adorner, DockPanel dockPanel)
        {
            this.mainWindow = mainWindow;
            this.dockPanel = dockPanel;
            this.adorner = adorner;

            OpenWindow();
        }

        public void OpenWindow()
        {

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
        }


        public void CloseWindow()
        {
            this.Close();
        }
    }
}
