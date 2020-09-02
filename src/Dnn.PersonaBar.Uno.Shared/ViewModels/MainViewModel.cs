using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Dnn.PersonaBar.Uno.Shared.Services;

namespace Dnn.PersonaBar.Uno.Shared.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // Typically in MVVM you would invoke this from
            // the thread that initializes the View Model.
            // For our sample it is okay to invoke the Async
            // method and ignore the task that is generated.
            InitializeAsync();
        }

        private string _setting;
        public string Setting
        {
            get => _setting;
            set
            {
                if (_setting == value)
                    return;

                _setting = value;
                RaisePropertyChanged(nameof(Setting));
            }
        }

        private async Task InitializeAsync()
        {
            var service = new DnnService();
            var data = await service.GetSettingAsync();
            Setting = data;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void RaisePropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
