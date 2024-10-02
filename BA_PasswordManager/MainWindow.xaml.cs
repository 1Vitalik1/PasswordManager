using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BA_PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush temp = new SolidColorBrush();
        public MainWindow()
        {
            InitializeComponent();
            foreach (Border border in windowsButtonStack.Children)
            {
                border.MouseEnter += WinButton_MouseEnter;
                border.MouseLeave += WinButton_MouseLeave;
            }
            
            
        }

        private void WinButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            border.Background = temp;
        }

        private void WinButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            temp = border.Background;
            border.Background = new SolidColorBrush(Color.FromRgb(54,110,192));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();            
        }

        private void btn_minim_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_state_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
            else this.WindowState = WindowState.Maximized;
            
        }

        private void btn_exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}