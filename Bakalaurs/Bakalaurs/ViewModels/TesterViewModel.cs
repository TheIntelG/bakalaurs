using Bakalaurs.Commands;
using Bakalaurs.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Bakalaurs.ViewModels
{
    public class TesterViewModel : ViewModelBase
    {
        public ICommand NavigateElementMenuCommand { get; set; }
        public TesterViewModel(NavigationStore navigationStore)
        {
            NavigateElementMenuCommand = new NavigateCommand<ElementMenuViewModel>(navigationStore, () => new ElementMenuViewModel(navigationStore));
        }
    }
}
