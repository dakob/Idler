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
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand OKCommand { get; private set; }

        public AddTaskVM(TaskVM taskVM)
        {
            TaskVM = taskVM;
            CancelCommand = new RelayCommand(CancelSpecialDesign);
            OKCommand = new RelayCommand(ApproveSpecialDesign);

        }

        public TaskVM TaskVM { get; set; }

        private void CancelSpecialDesign()
        {
            ResetInitialData();
            Messenger.Default.Send(new NotificationMessage("SpecialDesignCommit"));
            this.GoBackToMainWindow();
        }

        private void ResetInitialData()
        {
            throw new NotImplementedException();
        }

        private void ApproveSpecialDesign()
        {
            SaveInitData();
            Messenger.Default.Send(new NotificationMessage("SpecialDesignCommit"));
            this.GoBackToMainWindow();
        }

        private void SaveInitData()
        {
            throw new NotImplementedException();
        }

        private void GoBackToMainWindow()
        {
            Messenger.Default.Send(new NotificationMessage("Close SpecialDesign Window"), "SpecialDesignView");
        }

    }
}
