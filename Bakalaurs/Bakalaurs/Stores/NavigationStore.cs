using Bakalaurs.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakalaurs.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public static implicit operator NavigationStore(Func<object>  v)
        {
            throw new NotImplementedException();
        }
    }
}
