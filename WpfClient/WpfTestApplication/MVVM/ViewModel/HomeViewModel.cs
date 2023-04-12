using System;
using WpfTestApplication.Core;

namespace WpfTestApplication.MVVM.ViewModel {
    class HomeViewModel : ObservableObject 
    {


        public HomeViewModel HomeVM { get; set; }   

        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set 
            { 
                currentView = value; 
                OnPropertyChanged();
            }
        }
        public HomeViewModel() 
        {
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
        }
    }
}
