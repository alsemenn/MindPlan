using System;
using System.Collections.Generic;
using System.Text;

namespace MindPlan.Shared.TodoList
{
    public class TodoItemModel: IEquatable<TodoItemModel>
    {
        public Guid Id { get; }

        public string Text { get; set; }

        public TodoItemModel(Guid id)
        {
            Text = string.Empty;
            Id = id;
        }

        public bool Equals(TodoItemModel? other)
        {
            if (other == null)
            {
                return false;
            }
            return (Id == other.Id) && (Text == other.Text);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TodoItemModel);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
