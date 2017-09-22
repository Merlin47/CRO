using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CRO
{
	public class Employee
	{
		public string DisplayName { get; set; }
        public string Order { get; set; }
	}

    public partial class CROPage : ContentPage
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public CROPage()
        {
            InitializeComponent();

            employees.Add(new Employee { DisplayName = "Amazing Spider Man #1", Order="1" });
			employees.Add(new Employee { DisplayName = "Amazing Spider Man #2", Order = "2" });
			employees.Add(new Employee { DisplayName = "Amazing Spider Man #3", Order = "3" });
			employees.Add(new Employee { DisplayName = "Amazing Spider Man #4", Order = "4" });
			employees.Add(new Employee { DisplayName = "Amazing Spider Man #5", Order = "5" });
            EmployeeView.ItemsSource = employees;
            Employee2View.ItemsSource = employees;
        }
		void OnItemTaped(object sender, ItemTappedEventArgs e)
		{
            if (e.Item == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
            Employee selectEmployee = (Employee)e.Item;
            DisplayAlert("Item Selected", selectEmployee.Order, "Ok");
			//((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
		}
    }
}
