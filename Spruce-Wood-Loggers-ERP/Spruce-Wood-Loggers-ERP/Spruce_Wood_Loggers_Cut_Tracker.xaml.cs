using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

/**
 * Main grid window for the Cut Tracker application, holding a grid of buttons 
 * for each dimension combination of thickness, width, and length.
 */

namespace Spruce_Wood_Loggers_ERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Spruce_Wood_Loggers_Cut_Tracker : Window
    {

        static List<double> widths = [3, 4, 6, 8, 10];
        static List<double> thicknesses = [1, 2, 3, 4];
        static List<double> lengths = [4, 4.5, 6, 7, 8, 9, 10, 12, 14, 16];

        public Spruce_Wood_Loggers_Cut_Tracker()
        {
            InitializeComponent();

            // Ensure the database is created
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            initGrid();
        }

        // Dynamically create a grid with headers, and rows and
        // columns of buttons for each dimension combination
        public void initGrid()
        {
            int numColumns = widths.Count * thicknesses.Count();

            for (int i = 0; i < numColumns; i++)
            {
                ColumnDefinition newCol = new ColumnDefinition();
                MainGrid.ColumnDefinitions.Add(newCol);

                double thicknessIndex = i / widths.Count();

                // Set up each column header
                TextBlock header = new TextBlock
                {
                    Text = $"{thicknesses[(int)Math.Floor(thicknessIndex)]}\" x {widths[i % widths.Count]}\"",
                    FontSize = 10,
                    TextAlignment = TextAlignment.Center,
                    Foreground = Brushes.White
                };

                header.Margin = new Thickness(0, 5, 0, 2);

                Grid.SetRow(header, 0);
                Grid.SetColumn(header, i + 1);

                MainGrid.Children.Add(header);
            }

            for (int i = 0; i < lengths.Count; i++)
            {
                RowDefinition newRow = new RowDefinition();
                MainGrid.RowDefinitions.Add(newRow);

                // Set up each row header
                TextBlock header = new TextBlock
                {
                    Text = $"{lengths[i]}'",
                    FontSize = 10,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Right,
                    Foreground = Brushes.White
                };

                header.Margin = new Thickness(4, 0, 3, 0);

                Grid.SetRow(header, i + 1);
                Grid.SetColumn(header, 0);

                MainGrid.Children.Add(header);
            }

            // Initialize grid of buttons
            for (int i = 0; i < lengths.Count; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    double thickness = thicknesses[j / widths.Count()];
                    double width = widths[j % widths.Count()];
                    double length = lengths[i];

                    // Set button settings
                    var button = new DimensionButton
                    {
                        Margin = new Thickness(3),
                        IsEnabled = true, // This will be replaced by the binding below
                        Padding = new Thickness(2),
                        CutThickness = thickness,
                        CutWidth = width,
                        CutLength = length
                    };

                    // Set in place in grid
                    Grid.SetRow(button, i + 1);
                    Grid.SetColumn(button, j + 1);
                    button.Click += GridButton_Click; // Set up event handler

                    double thicknessIndex = j / widths.Count();

                    // Set style
                    MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(button, new CornerRadius(5));

                    // Change colouring every thickness
                    if (thicknessIndex % 2 == 0)
                    {
                        button.Style = (System.Windows.Style)Application.Current.FindResource("MaterialDesignRaisedLightButton");
                    }
                    else
                    {
                        button.Style = (System.Windows.Style)Application.Current.FindResource("MaterialDesignRaisedButton");
                    }

                    // Set up text
                    button.Content = new TextBlock
                    {
                        Text = $"{thickness}\" x {width}\"\n x {length}'",
                        FontSize = 8,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center
                        
                    };

                    MainGrid.Children.Add(button);
                }
            }
        }

        // Initialize Entry Confirmation screen based on button that is clicked
        private async void GridButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as DimensionButton;

            var entryConfirmation = new EntryConfirmation(button.CutThickness, button.CutWidth, button.CutLength)
            {
                Owner = this
            };

            this.Opacity = 0.6; // Dim the main window while the entry confirmation is open

            entryConfirmation.ShowDialog();
        }

        // Print a daily report
        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            bool? result = printDialog.ShowDialog();

            if (result == true)
            {
                FlowDocument doc = new FlowDocument();
                doc.Blocks.Add(new System.Windows.Documents.Paragraph(new Run("Hello World")));

                printDialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Printing FlowDocument");
            }
        }
    }
}