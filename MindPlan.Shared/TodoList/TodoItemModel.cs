using MindPlan.Shared.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace MindPlan.Shared.TodoList
{
    public class TodoItemModel: TrackableObjectBase, IEquatable<TodoItemModel>
    {
        public string Text { get; set; }

        public TodoItemModel(Guid id, string text)
            : base(id)
        {
            Text = text;
        }

        public bool Equals(TodoItemModel? other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (other == null) return false;
            return (Id == other.Id) && (Text == other.Text);
        }
    }
}
