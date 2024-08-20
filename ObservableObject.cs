using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace LSWindowStateManager
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T backingField, T value, [CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            // Check whether the maximum length is exceeded
            var property = GetType().GetProperty(propertyName);
            if (value is string stringValue && property?.GetCustomAttribute(typeof(MaxLengthAttribute)) is MaxLengthAttribute maxLengthAttribute && stringValue.Length > maxLengthAttribute.Length)
            {
                throw new ArgumentException($"{propertyName} may be a maximum of {maxLengthAttribute.Length} characters long.", propertyName);
            }

            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
