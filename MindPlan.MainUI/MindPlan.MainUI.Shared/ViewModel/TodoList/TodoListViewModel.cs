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
            private set;
        }

        public TodoListViewModel(TodoListModel model)
        {
            _model = model;
            UpdateItems(model);
            CreateNewItem = new Command(() => model.CreateNewItem());
            model.Items.CollectionChanged += Items_CollectionChanged;
        }

        private void UpdateItems(TodoListModel model)
        {
            Items = new ObservableCollection<TodoItemViewModel>(model.Items.Select(CreateItemViewModel));
        }

        private TodoItemViewModel CreateItemViewModel(TodoItemModel m)
        {
            var ret = new TodoItemViewModel(m);
            ret.RemoveRequested += () => _model.RemoveItem(m);
            return ret;
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateItems((TodoListModel)sender);
        }
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    e.NewItems.ForEach(i => Items.Add(CreateItemViewModel((TodoItemModel)i)));
                    break;
                case NotifyCollectionChangedAction.Remove:
                    e.OldItems.ForEach(i => Items.Remove(Items.Single(_ => _.UsesModel((TodoItemModel)i))));
                    break;
                default:
                    this.UpdateItems(this._model);
                    break;
            }
        }
    }
}
