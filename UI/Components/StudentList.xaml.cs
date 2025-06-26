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
using DataLayer.Database;
using DataLayer.Model;
namespace UI.Components
{
    /// <summary>
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : UserControl
    {
        private List<DatabaseUser> users;

        public StudentList()
        {
            InitializeComponent();

            try
            {
                using (var context = new DatabaseContext())
                {
                    users = context.Users.ToList();
                    students.ItemsSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на студентите:\n" + ex.Message);
            }
        }

        private void AvgAge_Click(object sender, RoutedEventArgs e)
        {
            if (users.Count == 0)
            {
                MessageBox.Show("Няма потребители.");
                return;
            }
            double avg = users.Average(u => u.Age);
            MessageBox.Show($"Средна възраст: {avg:F2} години");
        }

        private void Over50_Click(object sender, RoutedEventArgs e)
        {
            int count = users.Count(u => u.Age > 50);
            MessageBox.Show($"Потребители над 50 години: {count}");
        }

        private void Youngest_Click(object sender, RoutedEventArgs e)
        {
            var youngest = users.OrderBy(u => u.Age).FirstOrDefault();
            MessageBox.Show($"Най-младият е {youngest?.Name} ({youngest?.Age} г.)");
        }

        private void Oldest_Click(object sender, RoutedEventArgs e)
        {
            var oldest = users.OrderByDescending(u => u.Age).FirstOrDefault();
            MessageBox.Show($"Най-възрастният е {oldest?.Name} ({oldest?.Age} г.)");
        }

        private void TotalAge_Click(object sender, RoutedEventArgs e)
        {
            int total = users.Sum(u => u.Age);
            MessageBox.Show($"Обща възраст: {total} години");
        }

    }
}
