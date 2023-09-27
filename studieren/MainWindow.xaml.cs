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
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace studieren
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        

        public MainWindow()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection("server = DESKTOP-I7FI92O\\SQLEXPRESS; Database = test; Trusted_Connection = True;");
            sqlConnection.Open();
            

        }
        public class DataItem
        {
            public int Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM  stud  ";
            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                phonesGrid.Items.Clear();
                while (reader.Read())
                {
                    
                    int ID = (int)reader["ID"];
                    string name = (string)reader["Name"];
                    string mounth = (string)reader["Mounth"];

                    string faculty = null;

                    if (reader["Faculty"] != DBNull.Value)
                    {
                        faculty = (string)reader["Faculty"];
                    }
                    
                    phonesGrid.Items.Add(new DataItem() { Column1 = ID, Column2 = name, Column3 = mounth, Column4 = faculty});
                    
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            SqlCommand delete = sqlConnection.CreateCommand();
            delete.CommandText = "DELETE FROM stud where ID = @ID";
            delete.Parameters.AddWithValue("@ID", ((DataItem)phonesGrid.SelectedItem).Column1);
            delete.ExecuteNonQuery();

        }
        private void changeButton_Click(Object sender, RoutedEventArgs e)
        {
            AddUsers taskwindow = new AddUsers();
           
            taskwindow.Show();
        }


    }
}
