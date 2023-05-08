using WpfTZ.Models;
using WpfTZ.Views;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;

namespace WpfTZ.ViewModels
{
    public partial class ManagerVM : INotifyPropertyChanged
    {
        public PopupMessage MainPopup;

       
        private static ManagerVM instance;
        public static ManagerVM Instance
        {
            get
            {
                if (instance == null) instance = new ManagerVM();
                return instance;
            }
        }
        public void ReceiveMessage(Message message)
        {
            //MessageBox.Show("message");
            MainPopup.Show(message);
            
        }
       
        private ManagerVM() { }

        #region WINDOW MANIPULATION

        private Window secondWindow;
        public void OpenWindow(Window win)
        {
            OpenWindow(win, this);
        }

        public void OpenWindow(Window win, object context)
        {
            secondWindow?.Close();
            secondWindow = win;
            win.DataContext = this;
            win.Owner = Application.Current.MainWindow;
            win.Show();
            win.Activate();
        }

        private RelayCommand cancelBtnClick;
        public RelayCommand CancelBtnClick
        {
            get
            {
                return cancelBtnClick ?? (cancelBtnClick = new RelayCommand(obj =>
                {
                    Window win = (obj as Window);
                    win.Close();
                }));
            }
        }

        #endregion

       

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
