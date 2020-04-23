using MindPlan.MainUI.Shared.ViewModel.TodoList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MindPlan.Shared;
using MindPlan.Json;
using MindPlan.Shared.TodoList;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MindPlan.MainUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // TODO: remove.
        const string saveFileName = "myTodoList.json";
        private TodoListModel _model;

        public MainPage()
        {
            this.InitializeComponent();
            this.LoadModel();
            _model = _model ?? new TodoListModel(Guid.NewGuid(), new List<TodoItemModel>());
            _model.PropertyChanged += _model_PropertyChanged;
            MyList = new TodoListViewModel(_model);
        }

        private void _model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.SaveModel(saveFileName);
        }

        // TODO: remove.
        public TodoListViewModel MyList
        {
            get;
            private set;
        }

        //TODO: remove
        partial void LoadModel();
        partial void SaveModel(string fileName);
    }
}
