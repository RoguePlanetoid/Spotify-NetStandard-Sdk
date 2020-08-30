using System;
using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Generic Command
    /// </summary>
    /// <typeparam name="TAction">Action Type</typeparam>
    public class GenericCommand<TAction> : ICommand
    {
        private readonly Action<TAction> _execute;
        private readonly Predicate<bool> _canExecute;

        /// <summary>
        /// Raised when RaiseCanExecuteChanged is called
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new command that can always execute
        /// </summary>
        /// <param name="execute">The execution logic</param>
        public GenericCommand(Action<TAction> execute)
            : this(execute, null) { }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic</param>
        /// <param name="canExecute">The execution status logic</param>
        public GenericCommand(Action<TAction> execute, Predicate<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether this <see cref="GenericCommand{TAction}"/> can execute in its current state
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false</returns>
        public bool CanExecute(object parameter) =>
            _canExecute == null ? true : _canExecute((bool)parameter);

        /// <summary>
        /// Executes the <see cref="GenericCommand{TAction}"/> on the current command target
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null
        /// </param>
        public void Execute(object parameter) =>
            _execute((TAction)parameter);

        /// <summary>
        /// Method used to raise the <see cref="CanExecuteChanged"/> event
        /// to indicate that the return value of the <see cref="CanExecute"/>
        /// method has changed
        /// </summary>
        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
