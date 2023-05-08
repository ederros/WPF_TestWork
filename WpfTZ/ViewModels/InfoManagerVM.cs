using WpfTZ.Models;
using WpfTZ.Views;
using System.Collections.Generic;

namespace WpfTZ.ViewModels
{
    public partial class ManagerVM
    {
        private bool AvailableForEdit = false;

        private RelayCommand openAddInfoWindow;
        public RelayCommand OpenAddInfoWindow
        {
            get
            {
                return openAddInfoWindow ?? (openAddInfoWindow = new RelayCommand(obj =>
                {
                    AddInfoWindow win = new AddInfoWindow();
                    OpenWindow(win);
                    InitInfoAddWindow(win);
                }));
            }
        }

        private RelayCommand openSubInfoWindow;
        public RelayCommand OpenSubInfoWindow
        {
            get
            {
                return openSubInfoWindow ?? (openSubInfoWindow = new RelayCommand(obj =>
                {
                    OpenWindow(new SubInfoWindow());
                }));
            }
        }

        private RelayCommand openEditInfoWindow;
        public RelayCommand OpenEditInfoWindow
        {
            get
            {
                return openEditInfoWindow ?? (openEditInfoWindow = new RelayCommand(obj =>
                {
                    EditInfoWindow win = new EditInfoWindow();
                    OpenWindow(win);
                    InitInfoEditWindow(win);
                }));
            }
        }

        private RelayCommand addInfo;
        public RelayCommand AddInfo
        {
            get
            {
                return addInfo ?? (addInfo = new RelayCommand(obj =>
                {
                    AddInfoWindow win = (obj as AddInfoWindow);
                    if (!DB_Worker.AddInformation(win.userNameBox.Text, win.appNameBox.Text, win.commentBox.Text)) return;
                    AllInfo = DB_Worker.GetAllInfo();
                    win.Close();

                }));
            }
        }

        private RelayCommand editInfo;
        public RelayCommand EditInfo
        {
            get
            {
                return editInfo ?? (editInfo = new RelayCommand(obj =>
                {
                    if (!AvailableForEdit){
                        ReceiveMessage(new Message("Select available id first",MessageType.InputError));
                        return;
                    }
                    EditInfoWindow win = (obj as EditInfoWindow);
                    if (!DB_Worker.EditInformation(int.Parse(win.IdBox.Text),win.userNameBox.Text, win.appNameBox.Text, win.commentBox.Text)) return;
                    AllInfo = DB_Worker.GetAllInfo();
                    win.Close();

                }));
            }
        }
        public void InitInfoAddWindow(AddInfoWindow window)
        {
            
            window.appNameBox.ItemsSource = DB_Worker.GetAppNamesInfo();
            window.userNameBox.ItemsSource = DB_Worker.GetUserNamesInfo();
            window.appNameBox.SelectedIndex = 0;
            window.userNameBox.SelectedIndex = 0;
        }
        public void InitInfoEditWindow(EditInfoWindow window)
        {
            window.appNameBox.ItemsSource = DB_Worker.GetAppNamesInfo();
            window.userNameBox.ItemsSource = DB_Worker.GetUserNamesInfo();
            window.appNameBox.SelectedIndex = -1;
            window.userNameBox.SelectedIndex = -1;
            InfoEditWindowEnable(window, false);
        }
        private void InfoEditWindowEnable(EditInfoWindow window, bool value)
        {
            window.appNameBox.IsEnabled = value;
            window.userNameBox.IsEnabled = value;
            window.commentBox.IsEnabled = value;
        }
        public bool FillInfoFieldsById(EditInfoWindow window, string IdText)
        {
            List<string> values;
            int id;
            if (!int.TryParse(IdText, out id)|| !DB_Worker.GetInfoRowByIdIfExists(id, out values))
            {
                window.userNameBox.SelectedIndex = -1;
                window.appNameBox.SelectedIndex = -1;
                window.commentBox.Text = "";
                AvailableForEdit = false;
                InfoEditWindowEnable(window, false);
                return false;
            }
            AvailableForEdit = true;
            InfoEditWindowEnable(window, true);
            //ReceiveMessage(new Message(values[0], MessageType.Success));
            window.userNameBox.SelectedValue = values[1];
            window.appNameBox.SelectedValue = values[2];
            window.commentBox.Text = values[3];
            return true;
        }

        private RelayCommand subInfo;
        public RelayCommand SubInfo
        {
            get
            {
                return subInfo ?? (subInfo = new RelayCommand(obj =>
                {

                    SubInfoWindow win = (obj as SubInfoWindow);
                    int intId;
                    if (!int.TryParse(win.NameBox.Text, out intId))
                    {
                        ReceiveMessage(new Message("Id must be integer", MessageType.InputError));
                        return;
                    }
                    if (!DB_Worker.RemoveInformation(int.Parse(win.NameBox.Text))) return;

                    AllInfo = DB_Worker.GetAllInfo();
                    win.Close();
                }));
            }
        }

        private List<InfoData> allInfo = DB_Worker.GetAllInfo();
        public List<InfoData> AllInfo
        {
            get { return allInfo; }
            set
            {
                allInfo = value;
                NotifyPropertyChanged("AllInfo");
            }
        }

    }
}