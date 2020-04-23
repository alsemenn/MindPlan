using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MindPlan.Shared.TodoList
{
    public class TodoListModel: ObservableObject, IEquatable<TodoListModel>
    {
        private readonly List<TodoItemModel> _items;
        public Guid Id { get; }

        public IEnumerable<TodoItemModel> Items { get => _items; }

        public TodoListModel(Guid id, List<TodoItemModel> items)
        {
            this.Id = id;
            _items = items;
        }

        public void CreateNewItem()
        {
            _items.Add(new TodoItemModel(Guid.NewGuid()));
            OnPropertyChanged();   
        }

        public bool Equals(TodoListModel? other)
        {
            return (other != null)
                && (Id == other.Id)
                && Items.SequenceEqual(other.Items);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TodoListModel);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
