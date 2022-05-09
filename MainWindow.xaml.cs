using System;
using System.Windows;
using System.Windows.Threading;

namespace ExamTimer
{
    public partial class MainWindow : Window
    {
        private DateTime target = Convert.ToDateTime("2022-04-26");
        private string exam = "期中考试";

        public MainWindow()
        {
            //处理程序参数
            var args = Environment.GetCommandLineArgs();
            if (args != null)
            {
                if (args.Length > 1) target = Convert.ToDateTime(args[1]);
                if (args.Length > 2) exam = args[2];
            }

            //设置线程计时器延迟
            Win32.TimeBeginPeriod(1);

            //配置 DispatcherTimer 计时器对象
            var Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(UpdateTime);
            Timer.Interval = new TimeSpan(10000);

            //初始化布局
            InitializeComponent();

            //配置窗口动态信息
            Left = SystemParameters.PrimaryScreenWidth - 620;
            Top = 20;
            ShowInTaskbar = false;
            Label_Text.Content = "距离" + exam + "还有";

            //启用计时器
            Timer.Start();
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            var current = DateTime.Now;
            var lastTime = target - current;
            if (lastTime > TimeSpan.Zero)
            {
                Label_D.Content = lastTime.Days + " 天";
                Label_HMS.Content =
                    lastTime.Hours + " 时 " +
                    lastTime.Minutes + " 分 " +
                    lastTime.Seconds + " 秒";
            }
            else
            {
                MessageBox.Show("倒计时程序温馨提醒：该参加" + exam + "了！");
                Application.Current.Shutdown();
            }
        }
    }
}
