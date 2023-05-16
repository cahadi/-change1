using System;
using System.Windows.Input;

namespace ООО__Товары_для_животных_.Tools;

public sealed class Command : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public Command(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute is null || _canExecute();
    }

    public void Execute(object? parameter)
    {
        _execute();
    }
}