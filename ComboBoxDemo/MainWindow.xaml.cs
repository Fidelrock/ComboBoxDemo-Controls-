using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ComboBoxDemo
{
    public partial class MainWindow : Window
    {
        // Dictionary to store transaction types and their transporters.
        private Dictionary<string, List<string>> transporters;
        private Dictionary<string, List<string>> vehicles;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            transporters = new Dictionary<string, List<string>>
            {
                {"OUTGROWER", new List<string>{"Transporter1", "Transporter2"} },
                {"OUTREACH", new List<string>{ "Transporter3", "Transporter4"} },
                {"ESTATE", new List<string>{"Transporter5", "Transporter6"} },
                {"OTHERS", new List<string>{"Transporter7", "Transporter8"} }
            };

            vehicles = new Dictionary<string, List<string>>
            {
                { "Transporter1", new List<string>{"Vehicle1", "Vehicle2"} },
                { "Transporter2", new List<string>{"Vehicle3", "Vehicle4"} },
                { "Transporter3", new List<string>{"Vehicle5", "Vehicle6"} },
                { "Transporter4", new List<string>{"Vehicle7", "Vehicle8"} },
                { "Transporter5", new List<string>{"Vehicle9", "Vehicle10"} },
                { "Transporter6", new List<string>{"Vehicle11", "Vehicle12"} },
                { "Transporter7", new List<string>{"Vehicle13", "Vehicle14"} },
                { "Transporter8", new List<string>{"Vehicle15", "Vehicle16"} }
            };
        }

        private void cmbTransactionType_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected transaction type
            var selectedTransactionType = (cmbTransactionType.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Clear the existing items in the transporters ComboBox
            cmbTransporter.Items.Clear();
            cmbVehicles.Items.Clear(); // Clear vehicles too, as transporter selection will be updated

            // Add transporters of the selected transaction type to the transporters ComboBox
            if (selectedTransactionType != null && transporters.ContainsKey(selectedTransactionType))
            {
                foreach (var transporter in transporters[selectedTransactionType])
                {
                    cmbTransporter.Items.Add(transporter);
                }
            }
        }

        private void cmbTransporters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected transporter
            var selectedTransporter = cmbTransporter.SelectedItem as string;

            // Clear the existing items in the vehicles ComboBox
            cmbVehicles.Items.Clear();

            // Add vehicles of the selected transporter to the vehicles ComboBox
            if (selectedTransporter != null && vehicles.ContainsKey(selectedTransporter))
            {
                foreach (var vehicle in vehicles[selectedTransporter])
                {
                    cmbVehicles.Items.Add(vehicle);
                }
            }
        }
    }
}
