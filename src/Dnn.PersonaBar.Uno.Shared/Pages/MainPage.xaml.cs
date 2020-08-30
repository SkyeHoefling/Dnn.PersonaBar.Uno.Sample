using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Dnn.PersonaBar.Uno.Shared.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

#if __WASM__
using Newtonsoft.Json;
using Uno.Foundation;
#endif

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dnn.PersonaBar.Uno.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
#if __WASM__
            //var data = WebAssemblyRuntime.InvokeJS("getData()");
            //var myModel = JsonConvert.DeserializeObject<MyModel>(data);
            //this.textBlock.Text = $"Hello {myModel.Name}";
#endif
        }
    }
}
