using ApplicationLogic;
using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private int selectedCapacity;
        private string selectedCategory;
        private DataRowView selectedRow;
        private DataTable table;
        public ObservableCollection<int> Capacities { get; set; }
        public ObservableCollection<string> Categories { get; set; }
        public DataSet Rooms { get; set; }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand(obj =>
                  {
                      Rooms = new DataSet();
                      try
                      {
                          checkFullField();
                          Rooms = Logic.GetFreeRooms(selectedCapacity, selectedCategory);
                          Table = Rooms.Tables[0];
                      }
                      catch(ArgumentException ex)
                      {
                          DialogService.ShowMessage(ex);
                      }
                  }));
            }
        }
        private RelayCommand nextCommand;
        public RelayCommand NextCommand
        {
            get
            {
                return nextCommand ??
                  (nextCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          DialogService.ShowMessage(new Exception(SelectedRow.Row.ItemArray[0].ToString()));
                      }
                      catch (ArgumentException ex)
                      {
                          DialogService.ShowMessage(ex);
                      }
                  },
                  (obj) => SelectedRow != null));
            }
        }

        private void checkFullField()
        {
            if (SelectedCapacity == 0 || SelectedCategory == null)
            {
                throw new ArgumentException("Не выбраны критерии поиска.");
            }
        }

        public DataRowView SelectedRow
        {
            get { return selectedRow; }
            set
            {
                selectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
        }

        public DataTable Table
        {

            get { return table; }
            set
            {
                table = value;
                OnPropertyChanged("Table");
            }
        }
        public int SelectedCapacity
        {
            
            get { return selectedCapacity; }
            set
            {
                selectedCapacity = value;
                OnPropertyChanged("SelectedCapacity");
            }
        }
        public string SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        
        public ApplicationViewModel(string hotelCode)
        {
            Capacities = new ObservableCollection<int>();
            Categories = new ObservableCollection<string>();
            Capacities = Logic.GetCapacity(hotelCode);
            Categories = Logic.GetCategory(hotelCode);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
