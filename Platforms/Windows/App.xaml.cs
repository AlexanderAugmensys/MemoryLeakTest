using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Windows.System;
using KeyboardAccelerator = Microsoft.UI.Xaml.Input.KeyboardAccelerator;
using Window = Microsoft.UI.Xaml.Window;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MemoryLeakTest.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var mauiApp = Microsoft.Maui.Controls.Application.Current;
            if (mauiApp != null)
            {
                var mauiWindow = mauiApp.Windows.FirstOrDefault(); 
                if (mauiWindow?.Handler?.PlatformView is Window nativeWindow)
                {
                    // content of the window
                    if (nativeWindow.Content is UIElement rootElement)
                    {
                        // accelerator for F5
                        var acceleratorF5 = new KeyboardAccelerator
                        {
                            Key = VirtualKey.F5,
                        };
                        acceleratorF5.Invoked += AcceleratorF5_Invoked;


                        // add the accelerators to the root element
                        rootElement.KeyboardAccelerators.Add(acceleratorF5);
                        rootElement.KeyboardAcceleratorPlacementMode = KeyboardAcceleratorPlacementMode.Hidden;
                    }
                }
            }
        }

        private void AcceleratorF5_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            GC.Collect();
            //(AppService.TemplateService as TemplateService)?.RefreshResources();
            //AppService.NavigationManager.RefreshPage();
            //EventAggregatorHelper.Instance.GetEvent<ShowSystemToastEvent>()
            //                          .Publish(new ShowSystemToastEventArgs("UBIK", "XAML customizings reloaded."));

            //args.Handled = true;
        }

    }

}
