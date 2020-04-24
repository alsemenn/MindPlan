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
        private TodoListModel _model;

        public MainPage()
        {
            this.InitializeComponent();
            this.LoadModel();
            _model = _model ?? new TodoListModel(Guid.NewGuid(), new List<TodoItemModel>());
            _model.Items.CollectionChanged += (a, b) => this.SaveModel();
            MyList = new TodoListViewModel(_model);
        }

        // TODO: remove.
        public TodoListViewModel MyList
        {
            get;
            private set;
        }

        //TODO: remove
        partial void LoadModel();
        partial void SaveModel();
    }
}
