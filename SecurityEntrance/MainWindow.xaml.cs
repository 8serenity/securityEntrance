using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SecurityEntrance
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> ListEmployee { get; set; }
        public MainWindow()
        {
            ListEmployee = new ObservableCollection<Employee>();
            InitializeComponent();

            Employee employee1 = new Employee { Id = 1, Name = "Muhammad", Position = "SEO" };
            Employee employee2 = new Employee { Id = 2, Name = "Bob", Position = "Art Director" };
            Employee employee3 = new Employee { Id = 3, Name = "Cho Min", Position = "Security Director" };
            Employee employee4 = new Employee { Id = 4, Name = "Alexander", Position = "Salesman" };
            Employee employee5 = new Employee { Id = 5, Name = "Pattal", Position = "Software Engineer" };
            Employee employee6 = new Employee { Id = 6, Name = "Kenesari", Position = "Manager" };
            ListEmployee.Add(employee1);
            ListEmployee.Add(employee2);
            ListEmployee.Add(employee3);
            ListEmployee.Add(employee4);
            ListEmployee.Add(employee5);
            ListEmployee.Add(employee6);

            employeeList.ItemsSource = ListEmployee;




        }


        private void CheckAbsent(object sender, RoutedEventArgs e)
        {
            CheckAbsent checkWindow = new CheckAbsent(ListEmployee);
            checkWindow.Show();


        }
    }
}
