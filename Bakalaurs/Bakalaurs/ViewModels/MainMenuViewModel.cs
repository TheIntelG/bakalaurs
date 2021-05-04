using Bakalaurs.Commands;
using Bakalaurs.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Bakalaurs.ViewModels
{
    class MainMenuViewModel : ViewModelBase
    {
        public ICommand NavigateElementMenuCommand { get; set; }
        public ICommand QuitCommand { get; }
        public MainMenuViewModel(NavigationStore navigationStore)
        {
            NavigateElementMenuCommand = new NavigateCommand<ElementMenuViewModel>(navigationStore, () => new ElementMenuViewModel(navigationStore));

            QuitCommand = new RelayCommand((par) => { Application.Current.Shutdown(); });
        }
    }
}
