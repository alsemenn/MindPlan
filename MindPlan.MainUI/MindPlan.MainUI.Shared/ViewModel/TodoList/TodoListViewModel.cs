using MindPlan.Shared.TodoList;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MindPlan.MainUI.Shared.ViewModel.TodoList
{
    public class TodoListViewModel: ObservableObject
    {
        private List<TodoItemViewModel> _items;
        public List<TodoItemViewModel> Items
        {
            get => _items;
            private set => SetProperty(ref _items, value);
        }

        public Command CreateNewItem
        {
            get;
            private set;
        }

        public TodoListViewModel(TodoListModel model)
        {
            UpdateItems(model);
            CreateNewItem = new Command(() => model.CreateNewItem());
            model.PropertyChanged += Model_PropertyChanged;
        }

        private void UpdateItems(TodoListModel model)
        {
            Items = model.Items.Select(i => new TodoItemViewModel(i)).ToList();
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateItems((TodoListModel)sender);
        }
    }
}
