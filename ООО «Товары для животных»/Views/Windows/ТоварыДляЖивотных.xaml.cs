using System.Windows;
using ООО__Товары_для_животных_.ViewModels;

namespace ООО__Товары_для_животных_.Views.Windows;

public partial class ТоварыДляЖивотных : Window
{
    public ТоварыДляЖивотных()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}