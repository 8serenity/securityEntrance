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

        public ObservableCollection<DayCheckedInfo> daysChecked { get; set; }
        public ObservableCollection<Employee> defaultListEmployees { get; set; }

        public CheckAbsent()
        {
            InitializeComponent();
        }

        public CheckAbsent(ObservableCollection<Employee> listEmployeeFromMainWindows)
        {
            InitializeComponent();
            defaultListEmployees = new ObservableCollection<Employee>();
            defaultListEmployees = listEmployeeFromMainWindows;
            DayCheckedInfo infoDataToday = new DayCheckedInfo();
            foreach (Employee e in listEmployeeFromMainWindows)
            {
                InfoCheckEmployee temp = new InfoCheckEmployee();
                temp.Id = e.Id;
                temp.Name = e.Name;
                temp.Position = e.Position;
                infoDataToday.infoEmployees.Add(temp);
            }
            infoDataToday.dayChecked = DateTime.Today;
            daysChecked = new ObservableCollection<DayCheckedInfo>();
            daysChecked.Add(infoDataToday);

            employeeList.ItemsSource = daysChecked.Last().infoEmployees;
            checkCalendar.SelectedDate = DateTime.Today;
        }
        
        

        private void checkCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            bool hasChangedList = false;

            for (int i = 0; i < daysChecked.Count; i++)
            {
                if (daysChecked[i].dayChecked == checkCalendar.SelectedDate)
                {
                    hasChangedList = true;
                }
            }

            if (!hasChangedList)
            {
                DayCheckedInfo infoDataNew = new DayCheckedInfo();

                foreach (Employee employeeTempNew in defaultListEmployees)
                {
                    InfoCheckEmployee temp = new InfoCheckEmployee();
                    temp.Id = employeeTempNew.Id;
                    temp.Name = employeeTempNew.Name;
                    temp.Position = employeeTempNew.Position;
                    infoDataNew.infoEmployees.Add(temp);
                }
                infoDataNew.dayChecked = (DateTime)checkCalendar.SelectedDate;
                daysChecked.Add(infoDataNew);
                employeeList.ItemsSource = daysChecked.Last().infoEmployees;
            }
            else
            {
                for (int i = 0; i < daysChecked.Count; i++)
                {
                    if (checkCalendar.SelectedDate == daysChecked[i].dayChecked)
                    {
                        employeeList.ItemsSource = daysChecked[i].infoEmployees;
                    }
                }
            }

        }
    }

    public class DayCheckedInfo
    {
        public List<InfoCheckEmployee> infoEmployees { get; set; }
        public DateTime dayChecked { get; set; }
        public DayCheckedInfo()
        {
            infoEmployees = new List<InfoCheckEmployee>();
        }
    }
}

public class InfoCheckEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool IsEntered { get; set; }
    }

