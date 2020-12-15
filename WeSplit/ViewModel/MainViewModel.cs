using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeSplit.Model;

namespace WeSplit.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public DateTime Today = DateTime.Today;
        public ICommand AddJourneyCommand { get; set; }
        public ICommand ShowAddJourneyView { get; set; }
        public ICommand AddJRouteCommand { get; set; }
        public ICommand RenderListJourney { get; set; }

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
        public MainViewModel()
        {
            ListJourney = new ObservableCollection<Model.journey>(DataProvider.Ins.DB.journeys);
            ListPlace = new ObservableCollection<Model.place>(DataProvider.Ins.DB.places);
            ListProvince = new ObservableCollection<Model.province>(DataProvider.Ins.DB.provinces);
            ListRoute = new ObservableCollection<route>();
            SelectedPlace = ListPlace != null ? ListPlace.First() : null;
            SelectedProvince = ListProvince.Count != 0 ? ListProvince.First() : null;
            StartDate = EndDate = Today;
            ShowAddJourneyView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //handle logic here
            });

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
                var journey = new journey() { name = Name, end_place = SelectedPlace.id, date_end = EndDate, date_start = StartDate, total_cost = total };

                DataProvider.Ins.DB.journeys.Add(journey);
                foreach(route RouteIns in ListRoute)
                {
                    RouteIns.journey_id = journey.id;
                    DataProvider.Ins.DB.routes.Add(RouteIns);
                }
                DataProvider.Ins.DB.SaveChanges();
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

            RenderListJourney = new RelayCommand<object>((p) =>{ return true; }, (p) =>
            {
                var ListEndOfTrip = DataProvider.Ins.DB.journeys.Where(x => x.status == 1).ToList<journey>();
                ListJourney = new ObservableCollection<journey>(ListEndOfTrip);
            });
        }
    }
}
