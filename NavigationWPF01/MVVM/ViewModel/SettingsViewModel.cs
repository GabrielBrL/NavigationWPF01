using NavigationWPF01.Core;
using NavigationWPF01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationWPF01.MVVM.ViewModel
{
    public class SettingsViewModel : ViewModelBase
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

        public RelayCommand NavigateToHomeViewModel { get; set; }

        public SettingsViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToHomeViewModel = new RelayCommand(o => { Navigation.Navigate<HomeViewModel>(); }, o => true);
        }
    }
}
