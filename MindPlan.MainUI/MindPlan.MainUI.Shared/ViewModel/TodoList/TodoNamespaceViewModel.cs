﻿using MindPlan.Shared.TodoList;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MindPlan.MainUI.Shared.ViewModel.TodoList
{
    public class TodoWorkspaceViewModel: ObservableObject
    {
        private readonly TodoListWorkspaceModel _model;

        private ObservableCollection<TodoListViewModel> _todoLists;
        public ObservableCollection<TodoListViewModel> TodoLists
        {
            get => this._todoLists;
            set => SetProperty(ref this._todoLists, value);
        }

        public TodoWorkspaceViewModel(TodoListWorkspaceModel model) 
        {
            this._model = model;
            this._todoLists = new ObservableCollection<TodoListViewModel>(model.TodoLists.Select(_ => new TodoListViewModel(_)));
        }
    }
}
