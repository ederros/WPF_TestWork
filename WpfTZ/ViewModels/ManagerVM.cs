using WpfTZ.Models;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTZ.ViewModels
{
    public class ManagerVM : INotifyPropertyChanged
    {
        public ManagerVM()
        {
            allUsers = DB_Worker.GetAllUsers();
            allApps = DB_Worker.GetAllApps();
            allInfo = DB_Worker.GetAllInfo();
        }
        private List<User> allUsers;
        public List<User> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }
        private List<Application> allApps;
        public List<Application> AllApps
        {
            get { return allApps; }
            set
            {
                allApps = value;
                NotifyPropertyChanged("AllApps");
            }
        }
        private List<Information> allInfo;
        public List<Information> AllInfo
        {
            get { return allInfo; }
            set
            {
                allInfo = value;
                NotifyPropertyChanged("AllInfo");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
