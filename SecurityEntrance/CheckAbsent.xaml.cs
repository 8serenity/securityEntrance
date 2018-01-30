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
using System.Windows.Shapes;

namespace SecurityEntrance
{
    /// <summary>
    /// Логика взаимодействия для CheckAbsent.xaml
    /// </summary>
    public partial class CheckAbsent : Window
    {
        public CheckAbsent()
        {
            InitializeComponent();
        }

        public CheckAbsent(ObservableCollection<Employee> listEmployeeFromMainWindows)
        {
            InitializeComponent();
            List<InfoCheckEmployee> infoData = new List<InfoCheckEmployee>();
            foreach (Employee e in listEmployeeFromMainWindows)
            {
                InfoCheckEmployee temp = new InfoCheckEmployee();
                temp.Id = e.Id;
                temp.Name = e.Name;
                temp.Position = e.Position;
                infoData.Add(temp);
            }

            employeeList.ItemsSource = infoData;

        }
    }


    public class InfoCheckEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool IsEntered { get; set; }
    }
}
