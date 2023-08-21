using NavigationWPF01.Core;
using NavigationWPF01.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationWPF01.Services
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        void Navigate<TViewModel>() where TViewModel : ViewModelBase;
    }
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModelBase> _viewModelFactory;
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void Navigate<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
