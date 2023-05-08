using WpfTZ.Models;
using WpfTZ.Views;
using System.Collections.Generic;

namespace WpfTZ.ViewModels
{
    public partial class ManagerVM
    {
        private List<AppData> allApps = DB_Worker.GetAllApps();
        public List<AppData> AllApps
        {
            get { return allApps; }
            set
            {
                allApps = value;
                NotifyPropertyChanged("AllApps");
            }
        }

        private RelayCommand openAddAppWindow;
        public RelayCommand OpenAddAppWindow
        {
            get
            {
                return openAddAppWindow ?? (openAddAppWindow = new RelayCommand(obj =>
                {
                    OpenWindow(new AddAppWindow());
                }));
            }
        }

        private RelayCommand openSubAppWindow;
        public RelayCommand OpenSubAppWindow
        {
            get
            {
                return openSubAppWindow ?? (openSubAppWindow = new RelayCommand(obj =>
                {
                    OpenWindow(new SubAppWindow());
                }));
            }
        }

        private RelayCommand addApp;
        public RelayCommand AddApp
        {
            get
            {
                return addApp ?? (addApp = new RelayCommand(obj =>
                {
                    AddAppWindow win = (obj as AddAppWindow);
                    if (!DB_Worker.AddApp(win.NameBox.Text)) return;
                    AllApps = DB_Worker.GetAllApps();
                    win.Close();
                }));
            }
        }

        private RelayCommand subApp;
        public RelayCommand SubApp
        {
            get
            {
                return subApp ?? (subApp = new RelayCommand(obj =>
                {

                    SubAppWindow win = (obj as SubAppWindow);
                    if (!DB_Worker.RemoveApp(win.NameBox.Text)) return;
                    AllApps = DB_Worker.GetAllApps();
                    AllInfo = DB_Worker.GetAllInfo();
                    win.Close();
                }));
            }
        }
    }
}