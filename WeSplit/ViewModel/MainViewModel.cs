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

using LiveCharts;
using LiveCharts.Wpf;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Controls.Primitives;

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
        public ICommand FilterOptionCommand { get; set; }
        public ICommand ToggleShowScrCmd { get; set; }

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
        public ICommand AddMemberCmd { get; set; }
        public ICommand ShowDetailCmd { get; set; }

        #endregion

        #region Detail_Command
        public ICommand ShowAddMemberCmd { get; set; }
        public ICommand BackToDetailCmd { get; set; }
        public ICommand CloseJourneyCmd { get; set; }
        public ICommand EditJourneyMemberCmd { get; set; }
        public ICommand ShowEditMemberCmd { get; set; }
        public ICommand EditMemberCmd { get; set; }
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

        private ObservableCollection<Model.member> _ListMember;
        public ObservableCollection<Model.member> ListMember { get => _ListMember; set { _ListMember = value; OnPropertyChanged(); } }
        #endregion

        #region property
        // Show screen state
        private bool _IsShowScr;
        public bool IsShowScr
        {
            get{
                _IsShowScr = bool.Parse(ConfigurationManager.AppSettings["isShowSplashScr"]);
                return _IsShowScr;
            }
            set{
                _IsShowScr = value;

                // update config value 
                var config = ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
                config.AppSettings.Settings["isShowSplashScr"].Value = (value == true) ? "true" : "false";
                config.Save(ConfigurationSaveMode.Minimal);

                OnPropertyChanged();
            }
        }

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

        private bool _IsShowAddMember;
        public bool IsShowAddMember { get => _IsShowAddMember; set { _IsShowAddMember = value; OnPropertyChanged(); } }

        private string _MemberName;
        public string MemberName { get => _MemberName; set { _MemberName = value; OnPropertyChanged(); } }

        private string _MemberPhone;
        public string MemberPhone { get => _MemberPhone; set { _MemberPhone = value; OnPropertyChanged(); } }

        private float _MemberMoney;
        public float MemberMoney { get => _MemberMoney; set { _MemberMoney = value; OnPropertyChanged(); } }

        private MemberJourneyDetail _SelectedMemberItem;
        public MemberJourneyDetail SelectedMemberItem { get => _SelectedMemberItem; set { _SelectedMemberItem = value; OnPropertyChanged(); } }
        #endregion

        #region property_status_ui
        private string _IsInHomeContent;
        public string IsInHomeContent { get => _IsInHomeContent; set { _IsInHomeContent = value; OnPropertyChanged(); } }

        private string _IsInAddJourneyUC;
        public string IsInAddJourneyUC { get => _IsInAddJourneyUC; set { _IsInAddJourneyUC = value; OnPropertyChanged(); } }

        private string _IsInDetailUC;
        public string IsInDetailUC { get => _IsInDetailUC; set { _IsInDetailUC = value; OnPropertyChanged(); } }

        private string _IsInManagerMemberUC;
        public string IsInManagerMemberUC { get => _IsInManagerMemberUC; set { _IsInManagerMemberUC = value; OnPropertyChanged(); } }

        private string _IsInAddPlace;
        public string IsInAddPlace { get => _IsInAddPlace; set { _IsInAddPlace = value; OnPropertyChanged(); } }

        private string _IsInAddMemberUC;
        public string IsInAddMemberUC { get => _IsInAddMemberUC; set { _IsInAddMemberUC = value; OnPropertyChanged(); } }

        private string _IsInEditMember;
        public string IsInEditMember { get => _IsInEditMember; set { _IsInEditMember = value; OnPropertyChanged(); } }
        #endregion

        //Chart label
        public Func<ChartPoint, string> PointLabel { get; set; }

        public MainViewModel()
        {
            #region constructor
            Keyword = "";
            ListJourney = new ObservableCollection<Model.journey>(DataProvider.Ins.DB.journeys);
            ListPlace = new ObservableCollection<Model.place>(DataProvider.Ins.DB.places);
            ListProvince = new ObservableCollection<Model.province>(DataProvider.Ins.DB.provinces);
            ListRoute = new ObservableCollection<route>();
            ListMember = new ObservableCollection<Model.member>(DataProvider.Ins.DB.members);
            IsShowAddMember = false;
            SelectedPlace = ListPlace != null ? ListPlace.First() : null;
            SelectedProvince = ListProvince.Count != 0 ? ListProvince.First() : null;
            StartDate = EndDate = Today;
            IsInAddJourneyUC = "Hidden";
            IsInManagerMemberUC = "Hidden";
            IsInAddMemberUC = "Hidden";
            IsInAddPlace = "Hidden";
            IsInDetailUC = "Hidden";
            IsInEditMember = "Hidden";
            IsInHomeContent = "Visible";
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
                var journey = new journey() { name = Name, end_place = SelectedPlace.id, status=2, 
                                            date_end = EndDate, date_start = StartDate,
                                            hire_vehicle_cost = _HireCarCost, hire_room_cost = _HireRoomCost,
                                            plane_ticket_cost = _PlaneTicketCost, total_cost = total };

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

            //ListJourneyCommand = new RelayCommand<object>((p) =>{ return true; }, (p) =>
            //{
            //    var ListEndOfTrip = DataProvider.Ins.DB.journeys.Where(x => x.name.Contains(Keyword)).ToList<journey>();
            //    ListJourney = new ObservableCollection<journey>(ListEndOfTrip);
            //});

            //ListJourneyGoneCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    var ListJourneyGone = DataProvider.Ins.DB.journeys.Where(x=> x.status == 1).Where(x => x.name.Contains(Keyword)).ToList<journey>();
            //    ListJourney = new ObservableCollection<journey>(ListJourneyGone);
            //});

            //ListJourneyGoingToCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            //{
            //    var ListJourneyGone = DataProvider.Ins.DB.journeys.Where(x => x.status == 2).Where(x => x.name.Contains(Keyword)).ToList<journey>();
            //    ListJourney = new ObservableCollection<journey>(ListJourneyGone);
            //});

            // Filter 
            FilterOptionCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                // Get selected status
                var itemSelected = (ListBoxItem)p;
                int statusSelected = Int32.Parse(itemSelected.Tag.ToString());


                // Filter
                if (statusSelected == 0){   // get all
                    var ListJourneyFilter = DataProvider.Ins.DB.journeys.Where(x => x.name.Contains(Keyword)).ToList<journey>();
                    ListJourney = new ObservableCollection<journey>(ListJourneyFilter);
                }
                else{   // filter by status
                    var ListJourneyFilter = DataProvider.Ins.DB.journeys.Where(x => x.status == statusSelected).Where(x => x.name.Contains(Keyword)).ToList<journey>();
                    ListJourney = new ObservableCollection<journey>(ListJourneyFilter);
                }
            });

            CloseJourneyCmd = new RelayCommand<object>((p) =>
            {
                if(SelectedItem != null)
                {
                    if (SelectedItem.status == 1)
                    {
                        return false;
                    }
                }
                return true;
            }, (p) =>
            {
                SelectedItem.status = 1;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Chuyến đi kết thúc", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
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

            // Toggle to change show splash screen state
            ToggleShowScrCmd = new RelayCommand<object>(
                                    (p) => { return p == null ? false : true; },
                                    (p) =>
                                    {
                                        var toggleBtn = (ToggleButton)p;
                                        IsShowScr = (bool)(toggleBtn.IsChecked);
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

            #region Add Member Handlers
            ShowAddMemberCmd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                IsInAddJourneyUC = "Hidden";
                IsInAddMemberUC = "Visible";
                IsInManagerMemberUC = "Hidden";
                IsInAddPlace = "Hidden";
                IsInDetailUC = "Hidden";
                IsInHomeContent = "Hidden";
                IsInEditMember = "Hidden";

            });
            AddMemberCmd = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(MemberName))
                    return false;
                return true;
            }, (p) =>
            {
                var member = new member() { name = MemberName, phone = MemberPhone };
                DataProvider.Ins.DB.members.Add(member);
                ListMember.Add(member);
                DataProvider.Ins.DB.SaveChanges();

                var memberIns = (member)DataProvider.Ins.DB.members.Where(x => x.name.Equals(MemberName)).FirstOrDefault();
                var jouney_member = new journey_member() { journey_id = SelectedItem.id, member_id = memberIns.id, journey_member_money = MemberMoney };
                DataProvider.Ins.DB.journey_member.Add(jouney_member);
                DataProvider.Ins.DB.SaveChanges();

                var journeyIns = (journey)DataProvider.Ins.DB.journeys.Where(x => x.id == SelectedItem.id).FirstOrDefault();
                var input_money =jouney_member.journey_member_money;
                double return_money = (double)(input_money - SelectedItem.total_cost);
                MemberJourneyDetail detail = new MemberJourneyDetail() { name = MemberName, phone = MemberPhone, input_money = (double)input_money, return_money = return_money };
                SelectedItem.ListMember.Add(detail);

                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            #endregion

            #region Detail Handlers
            BackToDetailCmd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                IsInAddJourneyUC = "Hidden";
                IsInAddMemberUC = "Hidden";
                IsInManagerMemberUC = "Hidden";
                IsInAddPlace = "Hidden";
                IsInDetailUC = "Visible";
                IsInHomeContent = "Hidden";
                IsInEditMember = "Hidden";

            });
            ShowDetailCmd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                IsInAddJourneyUC = "Hidden";
                IsInAddMemberUC = "Hidden";
                IsInManagerMemberUC = "Hidden";
                IsInAddPlace = "Hidden";
                IsInDetailUC = "Visible";
                IsInHomeContent = "Hidden";
                IsInEditMember = "Hidden";

            });
            ShowEditMemberCmd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                IsInAddJourneyUC = "Hidden";
                IsInAddMemberUC = "Hidden";
                IsInManagerMemberUC = "Hidden";
                IsInAddPlace = "Hidden";
                IsInDetailUC = "Hidden";
                IsInHomeContent = "Hidden";
                IsInEditMember = "Visible";

                var dataGrid = (DataGrid)p;
                var item = dataGrid.SelectedItem;
                SelectedMemberItem = (MemberJourneyDetail)item;
            });

            EditMemberCmd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            #endregion

            //Chart label
            PointLabel = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P1})";
        }
    }
}
