using NavigationWPF01.Core;
using NavigationWPF01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationWPF01.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }        
        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToSettingsCommand { get; set; }
        public MainViewModel(INavigationService navigation)
        {
            Navigation = navigation;            
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.Navigate<HomeViewModel>(); }, o => true);
            NavigateToSettingsCommand = new RelayCommand(o => { Navigation.Navigate<SettingsViewModel>(); }, o => true);
        }
    }
}
