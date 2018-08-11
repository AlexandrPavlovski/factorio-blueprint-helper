using FactorioBlueprintHelper.Model;
using FactorioBlueprintHelper.Model.BlueprintConstatns;
using FactorioBlueprintHelper.Model.BlueprintObjects;
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
        private PreviewDrawer pidr = new PreviewDrawer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Canvas.Children.Clear();

            var ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() ?? false)
            {
                var imageWorker = new ImageWorker(ofd.FileName);
                var libb = new LampImageBlueprintBuilder();
                Map map = libb.CreateColoredLampsImageBluepringMap(imageWorker);
                //textBoxOut.Text = map.ToEncodedString();

                pidr.Init(this.Canvas, map);
            }
        } 

        private void DrawPreview(Map map)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pidr.ToggleGrid();

        }
    }
}
