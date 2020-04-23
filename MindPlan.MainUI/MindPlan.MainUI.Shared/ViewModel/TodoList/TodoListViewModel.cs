using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MindPlan.MainUI.Shared.ViewModel.TodoList
{
    public class TodoListViewModel: ObservableObject
    {
        private ObservableCollection<TodoItemViewModel> _items;
        public ObservableCollection<TodoItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public Command CreateNewItem
        {
            get;
            private set;
        }

        public TodoListViewModel()
        {
            CreateNewItem = new Command(() => _items.Add(new TodoItemViewModel()));
        }
    }
}
