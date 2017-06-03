using System;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panel_EchoesWar
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void InscriptionLinkButtonClick(object sender, RoutedEventArgs e)
        {
            // Hide the login grid
            Login.Opacity = 0;
            Login.IsEnabled = false;
            Login.HorizontalAlignment = HorizontalAlignment.Right;
            Inscription.HorizontalAlignment = HorizontalAlignment.Left;

            // Set the container background image
            container.Background = (Brush)this.FindResource("Inscription Container");

            // Ajust the height of the container
            DoubleAnimation height = new DoubleAnimation();
            height.From = 350;
            height.To = 429.8;
            height.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            container.BeginAnimation(HeightProperty, height);
            Inscription.IsEnabled = true;
            Inscription.Opacity = 1;
        }

        private void ConnexionButtonClick(object sender, RoutedEventArgs e)
        {
            if(getDataReturn("http://panel.echoeswar.fr/pages/login_check.php?user=" + connexionUsernameBox.Text + "&password=" + connexionPasswordBox.Password) == "ok")
            {
                Home frame = new Home();
                frame.Show();
                this.Close();
            }else
            {
                MessageBox.Show("Votre nom d'utilisateur ou votre mot de passe est incorrect.");
            }
        }

        public string getDataReturn(string url)
        {
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            string status = html.Substring(html.IndexOf("<data>") + ("<data>").Length);
            status = status.Substring(0, status.IndexOf("</data>"));
            return status;
        }

        private void InscriptionButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ConnexionLinkButtonClick(object sender, RoutedEventArgs e)
        {
            // Showing the login grid
            Inscription.Opacity = 0;
            Inscription.IsEnabled = false;
            Login.HorizontalAlignment = HorizontalAlignment.Left;
            Inscription.HorizontalAlignment = HorizontalAlignment.Right;

            // Set the container background image
            container.Background = (Brush)this.FindResource("Login Container");

            // Ajust the height of the container
            DoubleAnimation height = new DoubleAnimation();
            height.From = 429.8;
            height.To = 350;
            height.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            container.BeginAnimation(HeightProperty, height);
            Login.Opacity = 1;
            Login.IsEnabled = true;
        }
    }
}
