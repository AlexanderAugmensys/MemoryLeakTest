using MemoryLeakTest.ViewModels;

namespace MemoryLeakTest;

public partial class NewPage : ContentPage
{

    public NewPage()
    {
        InitializeComponent();
        BindingContext = new NewPageViewModel();
    }
}