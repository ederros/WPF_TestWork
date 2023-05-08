using WpfTZ.Models;
using WpfTZ.Views;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;

namespace WpfTZ.ViewModels
{
    public partial class ManagerVM
    {
        private List<UserData> allUsers = DB_Worker.GetAllUsers();
        public List<UserData> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }
        private RelayCommand openAddUserWindow;
        public RelayCommand OpenAddUserWindow
        {
            get
            {
                return openAddUserWindow ?? (openAddUserWindow = new RelayCommand(obj =>
                {
                    OpenWindow(new AddUserWindow());
                }));
            }
        }
        private RelayCommand addUser;
        public RelayCommand AddUser
        {
            get
            {
                return addUser ?? (addUser = new RelayCommand(obj =>
                {
                    AddUserWindow win = (obj as AddUserWindow);

                    if (!DB_Worker.AddUser(win.NameBox.Text)) return;
                    ManagerVM.Instance.AllUsers = DB_Worker.GetAllUsers();
                    win.Close();
                }));
            }
        }

        private RelayCommand subUser;
        public RelayCommand SubUser
        {
            get
            {
                return subUser ?? (subUser = new RelayCommand(obj =>
                {

                    SubUserWindow win = (obj as SubUserWindow);
                    if (!DB_Worker.RemoveUser(win.NameBox.Text)) return;
                    ManagerVM.Instance.AllUsers = DB_Worker.GetAllUsers();
                    ManagerVM.Instance.AllInfo = DB_Worker.GetAllInfo();
                    win.Close();
                }));
            }
        }

        private RelayCommand openSubUserWindow;
        public RelayCommand OpenSubUserWindow
        {
            get
            {
                return openSubUserWindow ?? (openSubUserWindow = new RelayCommand(obj =>
                {

                    OpenWindow(new SubUserWindow());
                }));
            }
        }
    }
}