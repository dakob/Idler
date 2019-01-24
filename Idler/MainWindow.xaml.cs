using GalaSoft.MvvmLight.Messaging;
using Idler.UIAdorners;
using Idler.ViewModel;
using Idler.WindowHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Shared.Enums;

namespace Idler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AddTaskView addTaskView;
        public GreyOutAdorner greyOutAdorner;

        public MainWindow()
        {
            InitializeComponent();

            greyOutAdorner = new GreyOutAdorner(DockPanel);

            Messenger.Default.Register<WindowTypes>(this, NotificationMessageRecived);

            Messenger.Default.Register<NotificationMessage>(this, "ShadeIn Adorner", ShadeInAdorner);
            Messenger.Default.Register<NotificationMessage>(this, "ShadeOut Adorner", ShadeOutAdorner);
        }

        public void ShadeInAdorner(NotificationMessage obj)
        {
            AdornerLayer windowAdorner = AdornerLayer.GetAdornerLayer(this);
            windowAdorner.Add(greyOutAdorner);
        }
        public void ShadeOutAdorner(NotificationMessage obj)
        {
            AdornerLayer windowAdorner = AdornerLayer.GetAdornerLayer(this);
            windowAdorner.Remove(greyOutAdorner);
        }

        private void NotificationMessageRecived(WindowTypes obj)
        {
            WindowHandlingStrategy windowHandlingStrategy = new WindowHandlingStrategy();

            windowHandlingStrategy.HandlingStrategy(obj,
                                                    greyOutAdorner,
                                                    DockPanel,
                                                    this, ((TasksVM)this.DataContext));
        }

    }
}
