using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


namespace studieren
{
    /// <summary>
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        
        

        SqlConnection sqlConnection;
        
        public AddUsers()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection("server = DESKTOP-I7FI92O\\SQLEXPRESS; Database = test; Trusted_Connection = True;");
            sqlConnection.Open();

            
            
        }

        
        
        private void addType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _ = 0;
        }
        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO stud (name, mounth, faculty) values (@name, @mounth, @faculty);";

            command.Parameters.AddWithValue("@name", addName.Text);
            command.Parameters.AddWithValue("@mounth", addMounth.Text);
            command.Parameters.AddWithValue("@faculty", addType.Text);  
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка!\n{ex.Message}");
            }
            
        }


        
    }
}
