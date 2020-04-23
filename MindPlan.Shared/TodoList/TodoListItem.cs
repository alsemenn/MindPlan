using System;
using System.Collections.Generic;
using System.Text;

namespace MindPlan.Shared.TodoList
{
    public class TodoListItem: IEquatable<TodoListItem>
    {
        public Guid Id { get; }

        public string Text { get; set; }

        public TodoListItem(Guid id)
        {
            Text = string.Empty;
            Id = id;
        }

        public bool Equals(TodoListItem? other)
        {
            if (other == null)
            {
                return false;
            }
            return (Id == other.Id) && (Text == other.Text);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TodoListItem);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
