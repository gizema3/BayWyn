using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BayWyn.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged //Informs that property changed.
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null!) //Caller member name allows to automated username changed information.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}