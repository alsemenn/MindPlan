using MindPlan.Shared.TodoList;
using MvvmHelpers;
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

        public TodoItemViewModel(TodoItemModel model)
        {
            _model = model;
        }
    }
}
