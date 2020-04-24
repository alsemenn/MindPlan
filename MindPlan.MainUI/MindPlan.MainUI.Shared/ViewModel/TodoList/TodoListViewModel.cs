using MindPlan.Shared.TodoList;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Uno.Extensions.Specialized;

namespace MindPlan.MainUI.Shared.ViewModel.TodoList
{
    public class TodoListViewModel: ObservableObject
    {
        private ObservableCollection<TodoItemViewModel> _items;
        public ObservableCollection<TodoItemViewModel> Items
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
            model.Items.CollectionChanged += Items_CollectionChanged;
        }

        private void UpdateItems(TodoListModel model)
        {
            Items = new ObservableCollection<TodoItemViewModel>(model.Items.Select(i => new TodoItemViewModel(i)));
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateItems((TodoListModel)sender);
        }
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                e.NewItems.ForEach(i => Items.Add(new TodoItemViewModel((TodoItemModel)i)));
                return;
            }

            UpdateItems((TodoListModel)sender);
        }
    }
}
