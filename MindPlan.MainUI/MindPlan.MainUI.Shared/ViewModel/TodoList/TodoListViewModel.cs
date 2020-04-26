using MindPlan.Shared.TodoList;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Uno.Extensions.Specialized;


namespace MindPlan.MainUI.Shared.ViewModel.TodoList
{
    public class TodoListViewModel: ObservableObject
    {
        private readonly TodoListModel _model;
        private ObservableCollection<TodoItemViewModel> _items;
        public ObservableCollection<TodoItemViewModel> Items
        {
            get => _items;
            private set => SetProperty(ref _items, value);
        }

        public Command CreateNewItem
        {
            get;
        }

        public string Name
        {
            get => _model.Name;
            set 
            {
                _model.Name = value;
                OnPropertyChanged();
            }
        }

        public TodoListViewModel(TodoListModel model)
        {
            _model = model;
            UpdateItems();
            CreateNewItem = new Command(CreateNewItemAction);
        }

        private void CreateNewItemAction(object obj)
        {
            var createdItem = this._model.CreateNewItem();
            this.Items.Add(CreateItemViewModel(createdItem));
        }

        private void UpdateItems()
        {
            Items = new ObservableCollection<TodoItemViewModel>(_model.Items.Select(CreateItemViewModel));
        }

        private TodoItemViewModel CreateItemViewModel(TodoItemModel m)
        {
            var ret = new TodoItemViewModel(m);
            ret.RemoveRequested += () =>
            {
                this.Items.Remove(ret);
                _model.RemoveItem(m);
            };
            return ret;
        }
    }
}
