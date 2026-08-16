using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spruce_Wood_Loggers_ERP
{
    /// <summary>
    /// Interaction logic for PieceSelectionWindow.xaml
    /// </summary>
    public partial class PieceSelectionWindow : Window
    {

        private int numPieces;
        private bool selectCustomNumber;

        public PieceSelectionWindow()
        {
            InitializeComponent();

            this.selectCustomNumber = false;
            this.numPieces = 0;
        }

        private void NumberPiecesClose_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void SelectCustomNumber_Button_Click(object sender, RoutedEventArgs e)
        {
            this.selectCustomNumber = true;
            this.Close();
        }

        private void PieceNumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var textBlock = button!.Content as TextBlock;

            //int numPieces = int.Parse(textBlock!.Text);
            this.numPieces = int.Parse(textBlock!.Text);
            DialogResult = true;
            this.Close();
        }

        public int getNumPieces()
        {
            return numPieces;
        }

        public bool getSelectCustomNumber()
        {
            return selectCustomNumber;
        }
    }
}
