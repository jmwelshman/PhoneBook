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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBook
{
    /// <summary>
    /// Phone book app - primary function is to store, lookup, update, and delete phone book records containing minimum LastName, FirstName,Phone.
    /// To Do: Boop
    /// Improve printing - currently only prints the displayed window. Must print grid results in a user friendly fashion
    /// Add UPDATE function
    /// Add DELETE function
    /// Add Alphanumeric lookup function
    /// Add more detailed columns. Company, Address, etc
    /// Add dynamic Datagrid sorting
    /// Figure out placeholder watermark text. Don't be fucking lazy with that.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }
        // Datagrid
        private void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        //Search button method
        public void SearchButtonClick()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '"+buttoncontent"%'ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }
// Clear button - empty textbox fields
private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            FirstNameText.Text = "";
            LastNameText.Text = "";
            PhoneText.Text = "";
        }
        // Save button and content check
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var serial = LastNameText.Text;
            var line = FirstNameText.Text;
            var station = PhoneText.Text;

            if (LastNameText.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a Last Name");
            }
            else if (FirstNameText.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Please enter a First Name");
            }
            else if (PhoneText.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a Phone Number");
            }
            else
            {
                //Connection string
                string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                string CmdString = string.Empty;
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    //SQL Query
                    SqlCommand cmd = new SqlCommand("INSERT INTO PhoneBook (LastName, FirstName, PhoneNumber, Status) VALUES (@LastName, @FirstName, @PhoneNumber, 'A')");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@LastName", LastNameText.Text);
                    cmd.Parameters.AddWithValue("@FirstName", FirstNameText.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneText.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Save completed successfully");
                FirstNameText.Text = "";
                LastNameText.Text = "";
                PhoneText.Text = "";
                FillDataGrid();
            }
        }
        //Print - this type of print only prints the window. Fix it.
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
             PrintDialog printDialog = new PrintDialog();
             if (printDialog.ShowDialog() == true)
             {
                 printDialog.PrintVisual(PhoneBookGrid, "Phone Book");
             }

        }

        private void allButton_Click_1(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void aButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'A%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void bButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'B%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        public void OnButtonClick(object sender, EventArgs args)
        {
            switch (args)
                case aButton: //do this
                break;
            case b: //dp this
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'C%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void dButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'D%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void eButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'E%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void fButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'F%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void gButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'G%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void hButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'H%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void iButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'I%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void jButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'J%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void kButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'K%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void lButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'L%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void mButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'M%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void nButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'N%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void oButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'O%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void pButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'P%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void qButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'Q%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void rButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'R%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void sButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'S%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void tButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'T%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void uButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'U%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void vButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'V%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void wButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'W%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void xButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'X%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void yButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'Y%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void zButton_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE 'Z%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _0Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '0%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _1Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '1%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _2Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '2%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _3Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '3%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _4Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '4%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _5Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '5%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _6Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '6%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _7Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '7%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _8Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '8%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void _9Button_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT LastName, FirstName, PhoneNumber FROM PhoneBook WHERE Status = 'A' AND LastName LIKE '9%' ORDER BY LastName ASC, FirstName ASC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PhoneBookGrid");
                sda.Fill(dt);
                PhoneBookGrid.ItemsSource = dt.DefaultView;
            }
        }
    }
}
