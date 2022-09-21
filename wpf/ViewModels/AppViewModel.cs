using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf.Commands;
using wpf.Models;
using wpf.Repositpries;

namespace wpf.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public FakeRepo PrinterRepository { get; set; }
        public ObservableCollection<Printer> Printers { get; set; }
        public RelayCommand SelectedCommand {get; set;}
        public RelayCommand AddCommand { get; set; }
        private Printer printer;

        public Printer Printer
        {
            get { return printer; }
            set { printer = value; OnPropertyChanged(); }
        }

        public AppViewModel()
        {
            PrinterRepository = new FakeRepo();
            Printers = new ObservableCollection<Printer> (PrinterRepository.GetAll());

            AddCommand = new RelayCommand(o =>
            {
                Printers.Add(new Printer { Color = "Black", Model = "SomeModel", Vendor = "SomeOne" });
                MessageBox.Show("Printer added succesfully");
            });

            SelectedCommand = new RelayCommand(o =>
            {
                var printer = o as Printer;
                Printer= printer;   
            }
               ); 



            



            
        }
    }
}
