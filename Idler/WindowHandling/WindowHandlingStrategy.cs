using Idler.UIAdorners;
using Idler.ViewModel;
using Shared;
using System.Windows;
using System.Windows.Controls;
using static Shared.Enums;

namespace Idler.WindowHandling
{
    public class WindowHandlingStrategy
    {

        public void HandlingStrategy(WindowTypes windowTypes,
                                     GreyOutAdorner adorner,
                                     DockPanel dockPanel,
                                     Window mainWindow,
                                     TasksVM tasksVM)
        {
            IOpenWindow IOpenWindowStrategy = null;

            switch (windowTypes)
            {

                case WindowTypes.AddTask:
                    IOpenWindowStrategy = new AddTaskWindowHandling(mainWindow, adorner, dockPanel, tasksVM);
                    break;

                default:
                    break;
            }

            if (IOpenWindowStrategy != null)
            {
                IOpenWindowStrategy.CloseWindow();
            }
        }

    }
}