using WpfTZ.Models;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTZ.ViewModels
{
    public class PopupMessage
    {
        
        private Label label;
        public PopupMessage(Label label)
        {
            this.label = label;
        }

        private void TypeDepending(MessageType type)
        {
            switch (type)
            {
                case MessageType.Success:
                    label.Background = new SolidColorBrush(Color.FromArgb(0xa8,0xff,0xb8,0x6c));
                    break;
                case MessageType.InputError:
                    label.Background = new SolidColorBrush(Color.FromRgb(0xff,0x55,0x55));
                    break;
                case MessageType.InternalError:
                    label.Background = new SolidColorBrush(Color.FromRgb(0xff, 0x55, 0x55));
                    break;
                default:
                    label.Background = new SolidColorBrush(Color.FromArgb(0xa8, 0xff, 0xb8, 0x6c));
                    break;
            }
        }
        public void Show(Message message)
        {

            TypeDepending(message.type);
            label.Content = message.messageText;
            DoubleAnimation showAnimation = new DoubleAnimation(label.MaxHeight,TimeSpan.FromSeconds(0.5));
            showAnimation.BeginTime = TimeSpan.FromSeconds(0);
            showAnimation.Completed += HideAnimation;
            label.BeginAnimation(FrameworkElement.HeightProperty,showAnimation);

            

        }
        private void HideAnimation(object sender, EventArgs e)
        {
            DoubleAnimation hideAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.5));
            hideAnimation.BeginTime = TimeSpan.FromSeconds(2);
            label.BeginAnimation(FrameworkElement.HeightProperty, hideAnimation);
        }
    }
}
