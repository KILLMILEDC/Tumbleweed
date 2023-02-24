using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
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
    /// Interaction logic for CountdownSettingWindow.xaml
    /// </summary>
    public partial class CountdownSettingWindow : Window
    {

        public CountdownSettingWindow()
        {
            InitializeComponent();

            this.Activate();
            //this.Deactivated += CountdownSettingWindowDeactivated;//失去焦点

            Topmost = true;//置于顶层

            double ScreenHeight = SystemParameters.WorkArea.Height;//获取当前屏幕工作区高度
            this.Top = ScreenHeight - this.Height - 150;//150 == MainWindow.Height

            CountdownSliderNumber.Text = Settings.Default.CSN;
            CountdownSlider.Value = Settings.Default.CSV;
        }

        //private void CountdownSettingWindowDeactivated(object sender, EventArgs e)
        //{
        //    this.Hide();//窗体失焦后隐藏
        //}

        private void CountdownSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(CountdownSlider.Value == 0)
            {
                CountdownSliderNumber.Text = "00 H 00 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 0;
                Settings.Default.CSNH = 0;
                Settings.Default.CSNM = 0;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 10)
            {
                CountdownSliderNumber.Text = "00 H 30 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 10;
                Settings.Default.CSNH = 0;
                Settings.Default.CSNM = 30;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 20)
            {
                CountdownSliderNumber.Text = "01 H 00 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 20;
                Settings.Default.CSNH = 01;
                Settings.Default.CSNM = 0;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 30)
            {
                CountdownSliderNumber.Text = "01 H 30 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 30;
                Settings.Default.CSNH = 01;
                Settings.Default.CSNM = 30;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 40)
            {
                CountdownSliderNumber.Text = "02 H 00 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 40;
                Settings.Default.CSNH = 02;
                Settings.Default.CSNM = 0;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 50)
            {
                CountdownSliderNumber.Text = "02 H 30 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 50;
                Settings.Default.CSNH = 02;
                Settings.Default.CSNM = 30;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 60)
            {
                CountdownSliderNumber.Text = "03 H 00 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 60;
                Settings.Default.CSNH = 03;
                Settings.Default.CSNM = 0;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 70)
            {
                CountdownSliderNumber.Text = "03 H 30 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 70;
                Settings.Default.CSNH = 03;
                Settings.Default.CSNM = 30;
                Settings.Default.Save();
            }
            else if(CountdownSlider.Value == 80)
            {
                CountdownSliderNumber.Text = "04 H 00 M";
                Settings.Default.CSN = CountdownSliderNumber.Text;
                Settings.Default.CSV = 80;
                Settings.Default.CSNH = 04;
                Settings.Default.CSNM = 0;
                Settings.Default.Save();
            }
        }
    }
}
