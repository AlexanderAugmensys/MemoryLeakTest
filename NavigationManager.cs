using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemoryLeakTest
{
    public class NavigationManager
    {
        NavigationPage NavigationPage => App.Current?.Windows?.FirstOrDefault()?.Page as NavigationPage;
        public RelayCommand NavigateTo { get; }
        public RelayCommand NavigateBack { get; }

        public NavigationManager()
        {
            NavigateTo = new RelayCommand(async () =>
            {
                await NavigationPage.PushAsync(new NewPage());
            }, CanExecute); 
            
            NavigateBack = new RelayCommand(async () =>
            {
                await NavigationPage.PopAsync();
            }, CanExecute);
        }

        public bool CanExecute()
        {
            return true;
        }
    }

}
