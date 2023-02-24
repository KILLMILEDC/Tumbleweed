using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Tumbleweed.Properties;
using Tumbleweed.Resources.cs;
using Button = System.Windows.Controls.Button;

namespace Tumbleweed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CountdownSettingWindow CSW;//声明CountdownSettingWindow窗体
        private PromptWindow PW;//声明PromptWindow窗体
        private AboutWindow AW;//声明AboutWindow窗体

        private static System.Timers.Timer countdown;//新建一个计时器

        NotifyIcon notifyIcon;

        readonly Dictionary<string, short> hotKeyDic = new Dictionary<string, short>();

        //win32 api
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = (-20);
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        public MainWindow()
        {
            InitializeComponent();

            icon();
            contextMenu();//状态栏菜单

            Topmost = true;//置于顶层

            Countdown.Content = Settings.Default.CSNH.ToString().PadLeft(2, '0') + " H" + " " +  Settings.Default.CSNM.ToString().PadLeft(2, '0') + " M";

            CapitalizeMark.Opacity = 0.2;
            double ScreenHeight = SystemParameters.WorkArea.Height;//获取当前屏幕工作区高度
            this.Top = ScreenHeight - this.Height;//设置主窗体垂直方向位置

            //定义“CapsLock”为热键
            this.Loaded += (sender, e) =>
            {
                var wpfHwnd = new WindowInteropHelper(this).Handle;

                var hWndSource = HwndSource.FromHwnd(wpfHwnd);
                //添加处理程序
                if (hWndSource != null) hWndSource.AddHook(MainWindowProc);
                hotKeyDic.Add("CapsLock", Win32Helper.GlobalAddAtom("CapsLock"));
                hotKeyDic.Add("Alt+C", Win32Helper.GlobalAddAtom("Alt+C"));
                hotKeyDic.Add("Alt+Q", Win32Helper.GlobalAddAtom("Alt+Q"));
                Win32Helper.RegisterHotKey(wpfHwnd, hotKeyDic["CapsLock"], Win32Helper.KeyModifiers.None, (int)System.Windows.Forms.Keys.CapsLock);
                Win32Helper.RegisterHotKey(wpfHwnd, hotKeyDic["Alt+C"], Win32Helper.KeyModifiers.Alt, (int)System.Windows.Forms.Keys.C);
                Win32Helper.RegisterHotKey(wpfHwnd, hotKeyDic["Alt+Q"], Win32Helper.KeyModifiers.Alt, (int)System.Windows.Forms.Keys.Q);
            };

            //窗体穿透
            this.SourceInitialized += delegate
            {
                IntPtr hwnd = new WindowInteropHelper(this).Handle;
                uint extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle |
                WS_EX_TRANSPARENT);
            };
        }

        private void icon()
        {
            string path = System.IO.Path.GetFullPath(@"Resources\Images\LOGO.ico");//需要设置图标属性为“Content", "Copy always"
            if (File.Exists(path))
            {
                this.notifyIcon = new NotifyIcon();
                this.notifyIcon.Text = "Tumbleweed";
                System.Drawing.Icon icon = new System.Drawing.Icon(path);
                this.notifyIcon.Icon = icon;
                this.notifyIcon.Visible = true;
                notifyIcon.MouseDoubleClick += OnNotifyIconDouble_Click;
            }
        }

        private void OnNotifyIconDouble_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void contextMenu()//状态栏图标右键菜单
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            ToolStripMenuItem supportMenuItem = new ToolStripMenuItem();
            supportMenuItem.Text = "Support";
            supportMenuItem.Click += new EventHandler(supportMenuItem_Click);
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem();
            aboutMenuItem.Text = "About";
            aboutMenuItem.Click += new EventHandler(aboutMenuItem_Click);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem();
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += new EventHandler(exitMenuItem_Click);

            contextMenuStrip.Items.Add(supportMenuItem);
            contextMenuStrip.Items.Add(aboutMenuItem);
            contextMenuStrip.Items.Add(exitMenuItem);
        }

        private void supportMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("https://killmiledc.github.io/");
        }
        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AW = new AboutWindow();
            AW.Show();
        }
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            System.Windows.Application.Current.Shutdown();//终止程序
        }

        //检查是否按下“CapsLock;Alt+Q”
        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case Win32Helper.WmHotkey:
                    {
                        int sid = wParam.ToInt32();
                        if (sid == hotKeyDic["CapsLock"])
                        {
                            if (CapitalizeMark.Opacity == 0.2)
                            {
                                CapitalizeMark.Opacity = 1;
                            }
                            else
                            {
                                CapitalizeMark.Opacity = 0.2;
                            }
                        }
                        else if (sid == hotKeyDic["Alt+C"])
                        {
                            //等价Countdown.PerformClick();
                            //计时器开始
                            ButtonAutomationPeer peer = new ButtonAutomationPeer(Countdown);
                            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                            invokeProv.Invoke();
                        }
                        else if(sid == hotKeyDic["Alt+Q"])
                        {
                            countdown.Stop();//计时器停止
                            Countdown.Content = Settings.Default.CSNH.ToString().PadLeft(2, '0') + " H" + " " + Settings.Default.CSNM.ToString().PadLeft(2, '0') + " M";//恢复之前的定时状态
                        }
                        break;
                    }
            }
            return IntPtr.Zero;
        }

        private void Countdown_Click(object sender, RoutedEventArgs e)
        {
            //new CountdownSettingWindow().Visibility = Visibility.Visible;//打开子窗体
            if(CSW == null)//如果CountdownSettingWindow实例未创建
            {
                CSW = new CountdownSettingWindow();//创建新的实例
                CSW.Show();
                CSW.Activate();
                Countdown.Content = Settings.Default.CSN;
            }
            else
            {
                if(CSW.IsVisible == true)//如果CountdownSettingWindow可见
                {
                    CSW.Hide();
                    Settings.Default.CSNHC = Settings.Default.CSNH;
                    Settings.Default.CSNMC = Settings.Default.CSNM;
                    Settings.Default.Save();
                    Countdown.Content = Settings.Default.CSNH.ToString().PadLeft(2, '0') + " H" + " " + Settings.Default.CSNM.ToString().PadLeft(2, '0') + " M";

                    //执行TimerButton_Click
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(TimerButton);
                    IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                    invokeProv.Invoke();
                }
                else//如果CountdownSettingWindow不可见
                {
                    CSW.Show();
                    CSW.Activate();
                    Settings.Default.CSNHC = Settings.Default.CSNH;
                    Settings.Default.CSNMC = Settings.Default.CSNM;
                    Settings.Default.Save();
                    Countdown.Content = Settings.Default.CSNH.ToString().PadLeft(2, '0') + " H" + " " + Settings.Default.CSNM.ToString().PadLeft(2, '0') + " M";

                    //执行TimerButtonEnd_Click
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(TimerButtonEnd);
                    IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                    invokeProv.Invoke();
                }
            }
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(COUNTDOWN);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        public void TimerButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            countdown.Stop();//计时器停止
        }

        private void COUNTDOWN_Click(object sender, EventArgs e)
        {
            countdown = new System.Timers.Timer(60000);//60s执行一次循环
            countdown.Elapsed += COUNTDOWN_Tick;
            countdown.Start();//计时器启动
        }

        private void COUNTDOWN_Tick(object sender, EventArgs e)
        {
            countdown.Stop();
            //计时器引发的事件
            int h = Settings.Default.CSNHC;
            int m = Settings.Default.CSNMC;
            if (m > 0)
            {
                m = m -1;
                Settings.Default.CSNMC = m;
                Settings.Default.Save();
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Countdown.Content = Settings.Default.CSNHC.ToString().PadLeft(2, '0') + " H" + " " + Settings.Default.CSNMC.ToString().PadLeft(2, '0') + " M";
                }), null);
                countdown.Start();
            }
            else if(m == 0)
            {
                if(h > 0)
                {
                    h = h -1;
                    Settings.Default.CSNHC = h;
                    Settings.Default.CSNMC = 59;
                    Settings.Default.Save();
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Countdown.Content = Settings.Default.CSNHC.ToString().PadLeft(2, '0') + " H" + " " + Settings.Default.CSNMC.ToString().PadLeft(2, '0') + " M";
                    }), null);
                    countdown.Start();
                }
                else if(h == 0)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        PW = new PromptWindow();
                        PW.Show();//计时结束后弹出提示窗口
                    }), null);
                }
            }
        }
    }
}
