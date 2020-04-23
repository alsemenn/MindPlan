using System;
using System.Collections.Generic;
using System.Linq;

namespace MindPlan.Shared.TodoList
{
    public class TodoList: IEquatable<TodoList>
    {
        public Guid Id { get; }
        public IEnumerable<TodoListItem> Items { get; }

        public TodoList(Guid id, IEnumerable<TodoListItem> items)
        {
            this.Id = id;
            this.Items = items;
        }

        public bool Equals(TodoList? other)
        {
            return (other != null)
                && (Id == other.Id)
                && Items.SequenceEqual(other.Items);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TodoList);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
