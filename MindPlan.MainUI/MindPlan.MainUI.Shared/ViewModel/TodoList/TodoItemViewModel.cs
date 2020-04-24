using MindPlan.Shared.TodoList;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MindPlan.MainUI.Shared.ViewModel.TodoList
{
    public class TodoItemViewModel: ObservableObject
    {
        private TodoItemModel _model;

        public string Text
        {
            get => _model.Text;
            set => _model.Text = value;
        }

        public Command DeleteItem
        {
            get;
            private set;
        }

        public event Action RemoveRequested;

        public TodoItemViewModel(TodoItemModel model)
        {
            _model = model;
            DeleteItem = new Command(() =>
            {
                RemoveRequested?.Invoke();
            });
        }

        public bool UsesModel(TodoItemModel m)
        {
            return _model == m;
        } 
    }
}
