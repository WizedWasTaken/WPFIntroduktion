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
using WPFIntroduktion;
using WPFIntroduktion.BIZ;



namespace WPFIntroduktion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ classBIZ = new ClassBIZ();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BindDataToListBox()
        {
            listBoxRes.ItemsSource = ClassBIZ.Opgave10();
        }

        /*
         * object sender = er en måde at spørge "hvem trykkede på Knappen". Hvis din ven Mads trykkede på knappen
         * Ville koden sende dette afsted.
         *
         * routedEventsArgs e = teknisk set er det et argument som indeholder noget data. Det inkludere bl.a. hvad klokken var
         * når vi trykkede på knappen. og andet spændende. 
         */
        private void buttonOpg12_Click(object sender, RoutedEventArgs e)
        {
            ClassBIZ.Opgave2(listBoxRes);
        }

        private void buttonOpg13_Click(object sender, RoutedEventArgs e)
        {
            ClassBIZ.Opgave3(listBoxRes);
        }

        private void buttonOpg14_Click(object sender, RoutedEventArgs e)
        {
            ClassBIZ.Opgave4(listBoxRes);
        }

        private void buttonOpg15_Click(object sender, RoutedEventArgs e)
        {
            ClassBIZ.Opgave5(listBoxRes);
        }

        private void buttonOpg16_Click(object sender, RoutedEventArgs e)
        {
            ClassBIZ.Opgave6(listBoxRes);
        }

        private void buttonOpg17_Click(object sender, RoutedEventArgs e)
        {
            ClassBIZ.Opgave7(listBoxRes);
        }

        private void ClearList(ListBox listBox)
        {
            listBox.ItemsSource = null;
            listBox.Items.Clear();
        }

        private void buttonOpg18_Click(object sender, RoutedEventArgs e)
        {
            ClearList(listBoxRes);
            listBoxRes.ItemsSource = ClassBIZ.GenerateRandomNums(25);
        }

        private void buttonOpg19_Click(object sender, RoutedEventArgs e)
        {
            ClassBIZ.Opgave9(listBoxRes);
        }

        private void buttonOpg191_Click_1(object sender, RoutedEventArgs e)
        {
            BindDataToListBox();
        }
    }
}
