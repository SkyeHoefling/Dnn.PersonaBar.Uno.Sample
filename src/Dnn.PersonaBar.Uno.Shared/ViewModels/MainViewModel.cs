using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Dnn.PersonaBar.Uno.Shared.Common;
using Dnn.PersonaBar.Uno.Shared.Services;

namespace Dnn.PersonaBar.Uno.Shared.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Save = new RelayCommand(async () => await OnSave());

            // Typically in MVVM you would invoke this from
            // the thread that initializes the View Model.
            // For our sample it is okay to invoke the Async
            // method and ignore the task that is generated.
            InitializeAsync();
        }

        [Bindable(true)]
        public ICommand Save { get; }

        private string _setting;

        [Bindable(true)]
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

        async Task OnSave()
        {
            var service = new DnnService();
            Setting = await service.UpdateSetting(Setting);

        }

        async Task InitializeAsync()
        {
            var service = new DnnService();
            Setting = await service.GetSettingAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void RaisePropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
