using MindPlan.Shared.Tools;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MindPlan.Shared.TodoList
{
    public class TodoListModel : TrackableObjectBase, IEquatable<TodoListModel>
    {
        public string Name
        {
            get; set;
        }

        private List<TodoItemModel> _items;
        public IEnumerable<TodoItemModel> Items { get => this._items; }

        public TodoListModel(Guid id, string name, IEnumerable<TodoItemModel> items)
            : base(id)
        {
            this.Name = name;
            this._items = items.ToList();
        }

        public TodoItemModel CreateNewItem()
        {
            var add = new TodoItemModel(Guid.NewGuid(), string.Empty);
            this._items.Add(add);
            return add;
        }

        public void RemoveItem(TodoItemModel i)
        {
            this._items.RemoveAll(_ => _.Id == i.Id);
        }

        public bool Equals(TodoListModel? other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (other == null) return false;
            return (Id == other.Id)
                && this.Name == other.Name
                && Items.SequenceEqual(other.Items);
        }
    }
}
