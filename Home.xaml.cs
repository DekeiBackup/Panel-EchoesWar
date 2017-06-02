using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panel_EchoesWar
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation op = new ThicknessAnimation();
            op.From = new Thickness(0, -600, 0, 0);
            op.To = new Thickness(0, 0, 0, 0);
            op.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            TeamSpeakBlock.Opacity = 1;
            BotAdminBlock.Opacity = 1;
            BotRadioBlock.Opacity = 1;
            WebBlock.Opacity = 1;
            statusBar.Opacity = 1;
            Container.BeginAnimation(MarginProperty, op);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button) e.Source;
            String prefix = "";
            DoubleAnimation status = new DoubleAnimation();
            status.From = 1;
            status.To = 0;
            status.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            status.AutoReverse = true;
            statusBar.BeginAnimation(OpacityProperty, status);
            switch (b.Name)
            {
                case "teamspeakPlayButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Démarrage du serveur TeamSpeak";
                    WebClient c3 = new WebClient();
                    c3.OpenRead("http://panel.echoeswar.fr/pages/tsscript.php?command=start");
                    c3.Dispose();
                    break;
                case "teamspeakStopButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Arrêt du serveur TeamSpeak";
                    WebClient c4 = new WebClient();
                    c4.OpenRead("http://panel.echoeswar.fr/pages/tsscript.php?command=stop");
                    c4.Dispose();
                    break;
                case "teamspeakRestartButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Redémarrage du serveur TeamSpeak";
                    WebClient c5 = new WebClient();
                    c5.OpenRead("http://panel.echoeswar.fr/pages/tsscript.php?command=reboot");
                    c5.Dispose();
                    break;
                case "botadminPlayButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Démarrage du Bot Admin";
                    WebClient c6 = new WebClient();
                    c6.OpenRead("http://panel.echoeswar.fr/pages/tsscript.php?command=reboot");
                    c6.Dispose();
                    break;
                case "botadminStopButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Arrêt du Bot Admin";
                    WebClient c7 = new WebClient();
                    c7.OpenRead("http://panel.echoeswar.fr/pages/tsscript.php?command=reboot");
                    c7.Dispose();
                    break;
                case "botadminRestartButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Redémarrage du Bot Admin";
                    WebClient c8 = new WebClient();
                    c8.OpenRead("http://panel.echoeswar.fr/pages/tsscript.php?command=reboot");
                    c8.Dispose();
                    break;
                case "botradioPlayButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Démarrage du Bot Radio";
                    WebClient c = new WebClient();
                    c.OpenRead("http://panel.echoeswar.fr/pages/radioscript.php?command=start");
                    c.Dispose();
                    break;
                case "botradioStopButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Arrêt du Bot Radio";
                    WebClient c1 = new WebClient();
                    c1.OpenRead("http://panel.echoeswar.fr/pages/radioscript.php?command=stop");
                    c1.Dispose();
                    break;
                case "botradioRestartButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Redémarrage du Bot Radio";
                    WebClient c2 = new WebClient();
                    c2.OpenRead("http://panel.echoeswar.fr/pages/radioscript.php?command=reboot");
                    c2.Dispose();
                    break;
                case "webPlayButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Démarrage du serveur Web";
                    break;
                case "webStopButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Arrêt du serveur Web";
                    break;
                case "webRestartButton":
                    statusText.Content = prefix + "Dernière commande exécutée: Redémarrage du serveur Web";
                    break;
            }
        }

        private void TeamSpeakBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showContainer(BlockContainer, TeamSpeakContainer);
        }

        private void BotAdminBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showContainer(BlockContainer, BotAdminContainer);
        }

        private void BotRadioBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showContainer(BlockContainer, BotRadioContainer);
        }

        private void WebBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            showContainer(BlockContainer, WebContainer);
        }

        public void showContainer(Grid s, Grid d)
        {
            ThicknessAnimation op = new ThicknessAnimation();
            op.From = new Thickness(0, 0, 0, 0);
            op.To = new Thickness(-900, 0, 0, 0);
            op.Duration = new Duration(TimeSpan.FromSeconds(1));
            s.BeginAnimation(MarginProperty, op);
            s.OpacityMask = Brushes.Black;
            s.Opacity = 0.5;
            s.IsEnabled = false;

            ThicknessAnimation op1 = new ThicknessAnimation();
            op1.From = new Thickness(940, 100, 40, 50);
            op1.To = new Thickness(40, 100, 40, 50);
            op1.Duration = new Duration(TimeSpan.FromSeconds(1));
            d.BeginAnimation(MarginProperty, op1);
            d.Opacity = 1;
            d.IsEnabled = true;
        }

        public void backContainer(Grid s, Grid d)
        {
            ThicknessAnimation op = new ThicknessAnimation();
            op.From = new Thickness(-900, 0, 0, 0);
            op.To = new Thickness(0, 0, 0, 0);
            op.Duration = new Duration(TimeSpan.FromSeconds(1));
            s.BeginAnimation(MarginProperty, op);
            s.OpacityMask = null;
            s.Opacity = 1;
            s.IsEnabled = true;

            ThicknessAnimation op1 = new ThicknessAnimation();
            op1.From = new Thickness(40, 100, 40, 50);
            op1.To = new Thickness(940, 100, 40, 50);
            op1.Duration = new Duration(TimeSpan.FromSeconds(1));
            d.BeginAnimation(MarginProperty, op1);
            d.OpacityMask = Brushes.Black;
            d.Opacity = 0.5;
            d.IsEnabled = false;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button) e.Source;
            Grid g = (Grid) b.Parent;
            backContainer(BlockContainer, g);
        }
    }
}
