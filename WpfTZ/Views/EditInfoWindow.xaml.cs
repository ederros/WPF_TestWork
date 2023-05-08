using WpfTZ.ViewModels;
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

namespace WpfTZ.Views
{
    /// <summary>
    /// Логика взаимодействия для EditInfoWindow.xaml
    /// </summary>
    public partial class EditInfoWindow : Window
    {
        public EditInfoWindow()
        {
            InitializeComponent();
        }
        private void OnIdChanged(object sender, EventArgs e)
        {
           ManagerVM.Instance.FillInfoFieldsById(this, IdBox.Text);
        }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
