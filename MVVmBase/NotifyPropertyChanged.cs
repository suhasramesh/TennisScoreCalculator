using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;

namespace MvvmBase
{
    public class NotifyPropertyChanged
   : DependencyObject
   , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Propertychanged

        public static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }

        protected void InvokePropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

        protected bool CanExecute(object parameter)
        {
            return true;
        }

        protected void OnExecute()
        {

        }
        #endregion
    }
}