using Idler.UIAdorners;
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
                                     Window mainWindow)
        {
            IOpenWindow IOpenWindowStrategy = null;

            switch (windowTypes)
            {

                case WindowTypes.AddTask:
                    IOpenWindowStrategy = new SpecialDesignWindowHandling(mainWindow, adorner, dockPanel);
                    break;

                default:
                    break;
            }
            IOpenWindowStrategy.CloseWindow();
        }

    }
}