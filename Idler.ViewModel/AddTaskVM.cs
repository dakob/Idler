using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idler.ViewModel
{
    public class AddTaskVM: BindableBase
    {
        public AddTaskVM()
        {
            TaskVM = new TaskVM();
            CancelCommand = new RelayCommand(CancelSpecialDesign);
            OKCommand = new RelayCommand(ApproveSpecialDesign);
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand OKCommand { get; private set; }

        public TaskVM TaskVM { get; set; }

        private void CancelSpecialDesign()
        {
            TaskVM = null;
            GoBackToMainWindow();
        }

        private void ApproveSpecialDesign()
        {
            Messenger.Default.Send<TaskVM>(TaskVM);
            GoBackToMainWindow();
        }

        private void GoBackToMainWindow()
        {
            Messenger.Default.Send(new NotificationMessage("CloseWindow"), "AddTaskView");
        }

    }
}
