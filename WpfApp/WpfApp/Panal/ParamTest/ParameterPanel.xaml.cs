using ParameterManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp.Panal.paramTest
{
    /// <summary>
    /// ParameterPanel.xaml 的交互逻辑
    /// </summary>
    public partial class ParameterPanel : UserControl
    {
        private TestParam testParam = null; 

        public ParameterPanel()
        {
            InitializeComponent();
            testParam = new TestParam();
        }

        private void Button_Read_Click(object sender, RoutedEventArgs e)
        {
            testParam.Read();
            ls_box.Items.Clear();
            foreach (var item in testParam.DataLs)
            {
                ls_box.Items.Add(item);
            }
        }

        private void Button_Write_Click(object sender, RoutedEventArgs e)
        {
            testParam.DataLs.Add(tex_input.Text);
            testParam.Write();
        }
    }


    public class TestParam : ParameterBase
    {
        private ObservableCollection<string> dataLs;
        public ObservableCollection<string> DataLs
        {
            get
            {
                return dataLs;
            }
            set
            {
                dataLs = value;
                RaisePropertyChanged(nameof(DataLs));
            }
        }
  
        public override void Copy(IParameter source)
        {
            TestParam sp = source as TestParam;
            if (sp != null)
            {
                this.DataLs.Clear();
                foreach (var item in sp.DataLs)
                {
                    this.DataLs.Add(item);
                }
            }
        }

        public TestParam()
        {
            this.DataLs = new ObservableCollection<string>();
        }
    }

}
