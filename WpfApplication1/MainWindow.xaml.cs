using System;
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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data data = new Data("init val");
        public MainWindow()
        {
            InitializeComponent();
            textBox1.DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data.backSpace();
        }
    }

    class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string val;
        public string Value
        {
            get { return val; }
            set {
                if (val != value)
                {
                    val = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                    }
                }    
            }
        }

        public Data(string v)
        {
            val = v;
        }

        public void backSpace()
        {
            if (!string.IsNullOrEmpty(Value))
            {
                Value = Value.Remove(Value.Length - 1);
            }
        }


    }
}
