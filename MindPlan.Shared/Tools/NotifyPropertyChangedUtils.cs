using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MindPlan.Shared.Tools
{
    public static class NotifyPropertyChangedUtils
    {
        public static bool Is(this PropertyChangedEventArgs e, Expression<Func<object>> property)
        {
            var info = (PropertyInfo)((MemberExpression)property.Body).Member;
            return info.Name == e.PropertyName;
        }
    }
}
