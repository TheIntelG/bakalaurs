using Bakalaurs.Commands;
using Bakalaurs.Stores;
using System.Windows.Input;

namespace Bakalaurs.ViewModels
{
    public class TesterViewModel : ViewModelBase
    {

        public ICommand NavigateElementMenuCommand { get; set; }
        public string CanvasImage { get; }
        public TesterViewModel(NavigationStore navigationStore)
        {
            NavigateElementMenuCommand = new NavigateCommand<ElementMenuViewModel>(navigationStore, () => new ElementMenuViewModel(navigationStore));

            DataLibrary dataLibrary = new DataLibrary();
            CanvasImage = dataLibrary.getDesignFilePath();
        }
    }
}
