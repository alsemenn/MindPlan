using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MindPlan.Shared.TodoList
{
    public class TodoListModel: ObservableObject, IEquatable<TodoListModel>
    {
        private string _name;
        
        public Guid Id { get; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<TodoItemModel> Items { get; }

        public TodoListModel(Guid id, List<TodoItemModel> items, string name)
        {
            this.Id = id;
            this._name = name;
            this.Items = new ObservableCollection<TodoItemModel>(items);
        }

        public void CreateNewItem()
        {
            Items.Add(new TodoItemModel(Guid.NewGuid()));
        }

        public void RemoveItem(TodoItemModel i)
        {
            Items.Remove(i);
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
