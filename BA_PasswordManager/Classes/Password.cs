using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace BA_PasswordManager.Classes
{
    [DataContract]
    internal class Password
    {
        internal static int selectedIndex;
        [DataMember] internal string name { get; set; } = string.Empty;
        [DataMember] internal string login { get; private set; } = string.Empty;
        [DataMember] internal string email { get; private set; } = string.Empty;
        [DataMember] internal string password { get; private set; } = string.Empty;
        [DataMember] internal string image { get; private set; } = string.Empty;
        [DataMember] internal string phone { get; private set; } = string.Empty;
        [DataMember] internal Collection<string> note { get; set; } = new Collection<string>();

        public Password(string name, string login, string email, string password, string image, string phone, Collection <string> note)
        {
            this.name = name;
            this.login = login;
            this.email = email;
            this.password = password;
            this.image = image;
            this.phone = phone;
            this.note = note;
        }

        public Password() { }
    }

    internal class PasswordTemplate
    {

        Border body { get; set; }
        Grid root { get; set; }
        StackPanel leftBlock { get; set; }
        Border image { get; set; }
        TextBlock label { get; set; }
        StackPanel rightBlock { get; set; }
        TextBlock login { get; set; }
        TextBlock password { get; set; }

        
        public PasswordTemplate(Password password)
        {
            body = new Border()
            {
                Margin = new Thickness(5),
                Height = 64,
                Background = new SolidColorBrush(Color.FromRgb(91, 97, 219)),
                CornerRadius = new CornerRadius(5),
            };

            body.MouseLeftButtonDown += (sender, e) =>
            {
                App.passwordViewer.modePass(password);
                Password.selectedIndex = App.userPasswords.IndexOf(password);
            };

            root = new Grid() 
            { 
                
            };
            body.Child = root;

            image = new Border();
            image.Background = new ImageBrush(); //TODO: Допилить
            label = new TextBlock();
            label.Text = password.name;
            label.FontSize = 20;
            label.Margin = new Thickness(15);
            label.VerticalAlignment = VerticalAlignment.Center;
            leftBlock = new StackPanel() 
            { 
                Orientation = Orientation.Horizontal,
                Children =
                {
                    image,
                    label,
                }
            };

            root.Children.Add(leftBlock);

            login = new TextBlock();
            login.Text = "Логин: " + password.login;
            login.FontSize = 20;
            login.Margin = new Thickness(15);
            login.VerticalAlignment = VerticalAlignment.Center;
            this.password = new TextBlock();
            this.password.Text = "Пароль: " + password.password;
            this.password.FontSize = 20;
            this.password.Margin = new Thickness(15);
            this.password.VerticalAlignment = VerticalAlignment.Center;

            rightBlock = new StackPanel() 
            { 
                HorizontalAlignment = HorizontalAlignment.Right,
                Orientation = Orientation.Horizontal,
                Children =
                {
                    login,
                    this.password
                }
            };
            root.Children.Add(rightBlock);
        }

        public Border getTemplate() => body;
        // PasswordTemplate (XAML)
        //        <Border Margin = "5" Height="64" Background="#5B61DB" CornerRadius="5">
        //    <Border.Effect>
        //        <DropShadowEffect Color = "#FF1759A4" ></ DropShadowEffect >
        //    </ Border.Effect >
        //    < Grid >
        //        < StackPanel Orientation="Horizontal">
        //            <Border HorizontalAlignment = "Left" VerticalAlignment="Center" Width="55" Height="55" Margin="5" >
        //                <Border.Background>
        //                    <ImageBrush ImageSource = "/Source/LocalAccount.png" />
        //                </ Border.Background >
        //            </ Border >
        //            < TextBlock VerticalAlignment="Center" FontSize="20" Margin="15">PasswordName</TextBlock>
        //        </StackPanel>
        //        <StackPanel HorizontalAlignment = "Right" Orientation="Horizontal">
        //            <TextBlock VerticalAlignment = "Center" FontSize="20" Margin="15">Логин:</TextBlock>
        //            <TextBlock VerticalAlignment = "Center" FontSize="20" Margin="15">Пароль:</TextBlock>
        //        </StackPanel>
        //    </Grid>
        //</Border>
    }
}
