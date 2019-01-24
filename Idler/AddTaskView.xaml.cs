﻿using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Shapes;

namespace Idler
{
    /// <summary>
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window   
    {
        public AddTaskView( TasksVM tasksVM)
        {
            InitializeComponent();
            TaskVM taskVM = new TaskVM();
            DataContext = taskVM;
            tasksVM.Tasks.Add(taskVM);
        }

        public AddTaskView(Window owner)
        {
            InitializeComponent();
            Owner = owner;
            Closing += (s, e) =>
            e.Cancel = true;
            Messenger.Default.Send(new HideChildWindowMessage());
        }
    }
}