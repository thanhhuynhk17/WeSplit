using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeSplit.Helpers;
using WeSplit.Model;

namespace WeSplit.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public DateTime Today = DateTime.Today;
        #region Journey_Command
        public ICommand AddJourneyCommand { get; set; }
        public ICommand AddJRouteCommand { get; set; }
        public ICommand ListJourneyCommand { get; set; }
        public ICommand ListJourneyGoneCommand { get; set; }
        public ICommand ListJourneyGoingToCommand { get; set; }
        #endregion

        #region Place_Command
        public ICommand AddPlaceCmd { get; set; }
        public ICommand OpenFileDialogCmd { get; set; }
        #endregion

        #region ControlBar_Command
        public ICommand CloseWindowCmd { get; set; }
        public ICommand RestoreWindowCmd { get; set; }
        public ICommand MinimizeWindowCmd { get; set; }
        public ICommand MouseMoveWindowCmd { get; set; }
        public ICommand SearchJourneyCmd { get; set; }

        #endregion

        #region List_Model
        private ObservableCollection<Model.journey> _ListJourney;
        public ObservableCollection<Model.journey> ListJourney { get => _ListJourney; set { _ListJourney = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.place> _ListPlace;
        public ObservableCollection<Model.place> ListPlace { get => _ListPlace; set { _ListPlace = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.province> _ListProvince;
        public ObservableCollection<Model.province> ListProvince { get => _ListProvince; set { _ListProvince = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.route> _ListRoute;
        public ObservableCollection<Model.route> ListRoute { get => _ListRoute; set { _ListRoute = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.place> _ListEndPlace;
        public ObservableCollection<Model.place> ListEndPlace { get => _ListEndPlace; set { _ListEndPlace = value; OnPropertyChanged(); } }
        #endregion

        #region property
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private Model.place _SelectedPlace;
        public Model.place SelectedPlace { get => _SelectedPlace; set { _SelectedPlace = value; OnPropertyChanged(); } }

        private Model.province _SelectedProvince;
        public Model.province SelectedProvince { get => _SelectedProvince; set { _SelectedProvince = value; OnPropertyChanged(); } }

        private float _HireCarCost;
        public float HireCarCost { get => _HireCarCost; set { _HireCarCost = value; OnPropertyChanged(); } }

        private float _HireRoomCost;
        public float HireRoomCost { get => _HireRoomCost; set { _HireRoomCost = value; OnPropertyChanged(); } }

        private float _PlaneTicketCost;
        public float PlaneTicketCost { get => _PlaneTicketCost; set { _PlaneTicketCost = value; OnPropertyChanged(); } }

        private string _EndPlace;
        public string EndPlace { get => _EndPlace; set { _EndPlace = value; OnPropertyChanged(); } }

        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged(); } }
        private float _RouteCost;
        public float RouteCost { get => _RouteCost; set { _RouteCost = value; OnPropertyChanged(); } }

        private DateTime _StartDate;
        public DateTime StartDate { get => _StartDate; set { _StartDate = value; OnPropertyChanged(); } }
        
        private DateTime _EndDate;
        public DateTime EndDate { get => _EndDate; set { _EndDate = value; OnPropertyChanged(); } }

        private Boolean _IsHiringCar;
        public Boolean IsHiringCar { get => _IsHiringCar; set { _IsHiringCar = value; OnPropertyChanged(); } }

        private Boolean _IsHiringRoom;
        public Boolean IsHiringRoom { get => _IsHiringRoom; set { _IsHiringRoom = value; OnPropertyChanged(); } }

        private Boolean _IsBuyPlaneTicket;
        public Boolean IsBuyPlaneTicket { get => _IsBuyPlaneTicket; set { _IsBuyPlaneTicket = value; OnPropertyChanged(); } }

        private journey _SelectedItem;
        public journey SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        private string _Keyword;
        public string Keyword { get => _Keyword; set { _Keyword = value; OnPropertyChanged(); } }

        private string _PlaceName;
        public string PlaceName { get => _PlaceName; set { _PlaceName = value; OnPropertyChanged(); } }

        private string _DescriptionPlace;
        public string DescriptionPlace { get => _DescriptionPlace; set { _DescriptionPlace = value; OnPropertyChanged(); } }

        private string _AddressPlace;
        public string AddressPlace { get => _AddressPlace; set { _AddressPlace = value; OnPropertyChanged(); } }

        private string _PlaceImage;
        public string PlaceImage { get => _PlaceImage; set { _PlaceImage = value; OnPropertyChanged(); } }
        #endregion
        public MainViewModel()
        {
            #region constructor
            Keyword = "";
            ListJourney = new ObservableCollection<Model.journey>(DataProvider.Ins.DB.journeys);
            ListPlace = new ObservableCollection<Model.place>(DataProvider.Ins.DB.places);
            ListProvince = new ObservableCollection<Model.province>(DataProvider.Ins.DB.provinces);
            ListRoute = new ObservableCollection<route>();
            SelectedPlace = ListPlace != null ? ListPlace.First() : null;
            SelectedProvince = ListProvince.Count != 0 ? ListProvince.First() : null;
            StartDate = EndDate = Today;
            #endregion

            #region Journey Handlers
            AddJourneyCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(Name))
                    return false;

                var nameList = DataProvider.Ins.DB.journeys.Where(x => x.name == Name);
                if (nameList == null || nameList.Count() != 0)
                    return false;

                if (SelectedPlace == null)
                    return false;

                if (StartDate < EndDate || StartDate == null)
                    return false;

                return true;
            }, (p) =>
            {
                var total = _HireCarCost + _HireRoomCost + _PlaneTicketCost;
                var journey = new journey() { name = Name, end_place = SelectedPlace.id, status=2, date_end = EndDate, date_start = StartDate, total_cost = total };

                DataProvider.Ins.DB.journeys.Add(journey);
                foreach(route RouteIns in ListRoute)
                {
                    RouteIns.journey_id = journey.id;
                    DataProvider.Ins.DB.routes.Add(RouteIns);
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });

            AddJRouteCommand = new RelayCommand<object>((p) => 
            {
                if (EndPlace == null)
                    return false;
                return true; 
            }, (p) =>
            {
                var RouteIns = new route() { place_start = EndPlace, description = Description, province_id = SelectedProvince.id, costs = RouteCost };
                ListRoute.Add(RouteIns);
            });

            ListJourneyCommand = new RelayCommand<object>((p) =>{ return true; }, (p) =>
            {
                var ListEndOfTrip = DataProvider.Ins.DB.journeys.Where(x => x.name.Contains(Keyword)).ToList<journey>();
                ListJourney = new ObservableCollection<journey>(ListEndOfTrip);
            });

            ListJourneyGoneCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var ListJourneyGone = DataProvider.Ins.DB.journeys.Where(x=> x.status == 1).Where(x => x.name.Contains(Keyword)).ToList<journey>();
                ListJourney = new ObservableCollection<journey>(ListJourneyGone);
            });

            ListJourneyGoingToCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var ListJourneyGone = DataProvider.Ins.DB.journeys.Where(x => x.status == 2).Where(x => x.name.Contains(Keyword)).ToList<journey>();
                ListJourney = new ObservableCollection<journey>(ListJourneyGone);
            });
            #endregion
            
            #region ControlBar handlers
            // Close Window
            CloseWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = WindowHandler.GetParentWindow(p);
                                        var w = (window as Window);
                                        if (w != null)
                                        {
                                            w.Close();
                                        }
                                    });
            // Restore Up&Down Window
            RestoreWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = WindowHandler.GetParentWindow(p);
                                        var w = (window as Window);
                                        if (w != null)
                                        {
                                            // Check window state: maximized or minimized
                                            if (w.WindowState != WindowState.Maximized)
                                            {
                                                w.WindowState = WindowState.Maximized;
                                            }
                                            else
                                            {
                                                w.WindowState = WindowState.Normal;
                                            }
                                        }
                                    });
            // Minimize Window
            MinimizeWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = WindowHandler.GetParentWindow(p);
                                        var w = (window as Window);
                                        if (w != null)
                                        {
                                            w.WindowState = WindowState.Minimized;
                                        }
                                    });
            // Mouse left button down move Window
            MouseMoveWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = WindowHandler.GetParentWindow(p);
                                        var w = (window as Window);
                                        w.DragMove();
                                    });

            // Search Journey by keyword
            SearchJourneyCmd = new RelayCommand<UserControl>((p) => 
            { 
                return Keyword == null ? false : true; 
            }, (p) => 
            {
                var ListJFilteredourney = DataProvider.Ins.DB.journeys.Where(x => x.name.Contains(Keyword)).ToList<journey>();
                ListJourney = new ObservableCollection<journey>(ListJFilteredourney);
            });

            #endregion

            #region Place Handler
            AddPlaceCmd = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(PlaceName))
                    return false;

                var nameList = DataProvider.Ins.DB.places.Where(x => x.name == PlaceName);
                if (nameList == null || nameList.Count() != 0)
                    return false;

                if (SelectedProvince == null)
                    return false;

                return true;
            }, (p) =>
            {
                var place = new place() { name = PlaceName, description = DescriptionPlace, address = AddressPlace, province_id = SelectedProvince.id, image = PlaceImage };
                ListPlace.Add(place);

                DataProvider.Ins.DB.places.Add(place);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                
            });

            OpenFileDialogCmd = new RelayCommand<object>((p) => { return true;}, (p) =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                dlg.DefaultExt = ".png";
                //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                    PlaceImage = dlg.FileName;
            });
            #endregion
        }
    }
}
