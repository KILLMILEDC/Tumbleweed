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
using Tumbleweed.Properties;

namespace Tumbleweed
{
    /// <summary>
    /// Interaction logic for PromptWindow.xaml
    /// </summary>
    public partial class PromptWindow : Window
    {
        public PromptWindow()
        {
            InitializeComponent();
            PromptF.Text = "YOU'VE BEEN WORKING FOR " + Settings.Default.CSNH.ToString().PadLeft(2, '0') + " HOURS " + Settings.Default.CSNM.ToString().PadLeft(2, '0') + " MINUTES,";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
