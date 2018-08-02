using FactorioBlueprintHelper.Model;
using Microsoft.Win32;
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

namespace FactorioBlueprintHelper.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = Serializer.Decode(textBox.Text);

            textBoxOut.Text = Serializer.Encode(t);

            if (textBox.Text != textBoxOut.Text)
            {
                this.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() ?? false)
            {
                var imageEd = new ImageEditor(ofd.FileName);
                imageEd.RoundToLampColors();
                imageEd.SaveOnDisk();
            }
        }
    }
}
