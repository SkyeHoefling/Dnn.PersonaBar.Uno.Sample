using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uno.Foundation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dnn.PersonaBar.Uno
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
#if __WASM__
            var data = WebAssemblyRuntime.InvokeJS("getData()");
            var myModel = JsonConvert.DeserializeObject<MyModel>(data);
            this.textBlock.Text = $"Hello {myModel.Name}";
#endif
        }
    }

    [JsonObject]
    public class MyModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
