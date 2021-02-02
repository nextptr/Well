using CommonEventAggregator;
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

namespace WpfApp
{
    /// <summary>
    /// EventAggregratorPanel.xaml 的交互逻辑
    /// </summary>
    public partial class EventAggregratorPanel : UserControl, IEventHandler<TestEventArgs>
    {
        public EventAggregratorPanel()
        {
            InitializeComponent();

            CMEventAggregator.Instance.Subscribe(this);
            
        }

        public void Handler(TestEventArgs @event)
        {
            ls_box.Items.Add(@event.ObjVal);
            ls_box.IsEnabled = true;
            ls_box.Opacity = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CMEventAggregator.Instance.Publish(new TestEventArgs("btn click"));
        }
    }

    public class TestEventArgs : IEventArgs
    {
        private object objVal;
        public object ObjVal
        {
            get
            {
                return objVal;
            }
            set
            {
                objVal = value;
            }
        }
        public TestEventArgs(object val)
        {
            ObjVal = val;
        }
    }
}
