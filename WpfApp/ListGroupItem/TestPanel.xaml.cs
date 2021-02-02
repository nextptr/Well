using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ListGroupItem
{
    /// <summary>
    /// TestPanel.xaml 的交互逻辑
    /// </summary>
    public partial class TestPanel : UserControl
    {
        public TestPanel()
        {
            InitializeComponent();
        }

        private IDIO io;
        public IDIO IO
        {
            set
            {
                io = value;
                IOInit();
            }
            get => io;
        }

        private void IOInit()
        {
            if (IO != null)
            {
                this.Dispatcher.Invoke(() =>
                {
                    //设置列表控件资源，并定义组的规则和排序
                    its.ItemsSource = IO;
                    ICollectionView cv = CollectionViewSource.GetDefaultView(its.ItemsSource);
                    cv.SortDescriptions.Clear();
                    cv.GroupDescriptions.Clear();
                    cv.SortDescriptions.Add(new SortDescription("Attr.IOIndex", ListSortDirection.Ascending));
                    cv.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                    cv.GroupDescriptions.Add(new PropertyGroupDescription("Attr.GroupName"));
                }, System.Windows.Threading.DispatcherPriority.Send);
            }
        }
    }

    public class IDIO : IEnumerable<IoItem>
    {
        public IEnumerator<IoItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class IoItem
    {

    }
}
