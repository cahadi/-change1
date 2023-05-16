using System.Windows.Controls;
using ООО__Товары_для_животных_.ViewModels;

namespace ООО__Товары_для_животных_.Views.Pages;

public partial class LogInPage : Page
{
    public LogInPage(MainViewModel mainViewModel)
    {
        InitializeComponent();

        DataContext = new LoginViewModel(mainViewModel, capchaCanvas, passBox);
    }
}