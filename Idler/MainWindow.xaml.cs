using GalaSoft.MvvmLight.Messaging;
using Idler.ViewModel;
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

namespace Idler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AddTaskView addTaskView;

        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            Loaded += (s, e) =>
            {
                addTaskView = new AddTaskView(this);
            };

            Messenger.Default.Register<ShowChildWindowMessage>(this, (msg) => addTaskView.ShowDialog());
            Messenger.Default.Register<HideChildWindowMessage>(this, (msg) => addTaskView.Hide());
        }
    }
}
