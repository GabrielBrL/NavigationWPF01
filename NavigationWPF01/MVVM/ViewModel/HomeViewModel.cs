using NavigationWPF01.Core;
using NavigationWPF01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationWPF01.MVVM.ViewModel
{
    public class HomeViewModel : ViewModelBase
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

        public RelayCommand NavigateToSettingsViewModel { get; set; }

        public HomeViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToSettingsViewModel = new RelayCommand(o => { Navigation.Navigate<SettingsViewModel>(); }, o => true);
        }
    }
}
