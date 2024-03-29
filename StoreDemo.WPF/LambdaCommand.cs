using System.Windows.Input;

namespace StoreDemo.WPF;

public class LambdaCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?> _canExecute;

    public LambdaCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute ?? (o => true);
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute.Invoke(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}