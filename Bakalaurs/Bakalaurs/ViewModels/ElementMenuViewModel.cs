using Bakalaurs.Commands;
using Bakalaurs.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Bakalaurs.ViewModels
{
    public class ElementMenuViewModel : ViewModelBase
    {
        public ICommand NavigateMainMenuCommand { get; set; }
        public ElementMenuViewModel(NavigationStore navigationStore)
        {
            NavigateMainMenuCommand = new NavigateCommand<MainMenuViewModel>(navigationStore, () => new MainMenuViewModel(navigationStore));
        }
    }
}
