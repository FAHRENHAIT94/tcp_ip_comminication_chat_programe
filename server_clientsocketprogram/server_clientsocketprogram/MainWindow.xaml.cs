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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace server_clientsocketprogram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static networking.ServerSocket ServerSocket = new networking.ServerSocket();
        public MainWindow()
        {
            InitializeComponent();


            ServerSocket.Bind(6556);
            ServerSocket.Listener(500);
            ServerSocket.Accept();

            while (true)
                Console.ReadLine();
        }
    }
}
