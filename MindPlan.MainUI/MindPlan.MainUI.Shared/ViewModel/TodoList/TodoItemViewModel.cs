using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MindPlan.MainUI.Shared.ViewModel.TodoList
{
    public class TodoItemViewModel: ObservableObject
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
