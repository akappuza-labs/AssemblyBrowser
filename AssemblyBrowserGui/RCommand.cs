using System;
using System.Windows.Input;

namespace AssemblyBrowserGui;

public class RCommand : ICommand
{
    private readonly Action<object?>? _execute;
    private readonly Func<object?, bool>? _ableExecute;
    
    public RCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _ableExecute = canExecute;
    }
    
    public bool AbleExecute(object? parameter)
    {
        return _ableExecute == null || _ableExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute?.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}