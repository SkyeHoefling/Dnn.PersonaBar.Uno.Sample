using Dnn.PersonaBar.Uno.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Dnn.PersonaBar.Uno.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
