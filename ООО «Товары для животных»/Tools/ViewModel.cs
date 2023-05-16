using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ООО__Товары_для_животных_.Tools;

public abstract class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new(name));
    }
}