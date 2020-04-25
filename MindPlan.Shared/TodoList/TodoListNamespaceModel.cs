using MindPlan.Shared.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MindPlan.Shared.TodoList
{
    public class TodoListNamespaceModel: TrackableObjectBase, IEquatable<TodoListNamespaceModel>
    {
        private List<TodoListModel> _todoLists;
        private const string TodayListName = "Today";

        public IEnumerable<TodoListModel> TodoLists { get => this._todoLists; }
        public TodoListModel TodayList { get; }

        public TodoListNamespaceModel(Guid id, IEnumerable<TodoListModel> todoLists)
            : base(id)
        {
            this._todoLists = todoLists.ToList();
            var todayList = this._todoLists.Where(_ => _.Name == TodayListName).SingleOrDefault();
            if (todayList == null)
            {
                todayList = new TodoListModel(Guid.NewGuid(), TodayListName, new List<TodoItemModel>());
                this._todoLists.Add(todayList);
            }
            this.TodayList = todayList;
        }

        /// <summary>
        /// Creates and adds new to-do list.
        /// </summary>
        /// <returns> Added item. </returns>
        public TodoListModel CreateNewList()
        {
            var ret = new TodoListModel(Guid.NewGuid(), string.Empty, new List<TodoItemModel>());
            this._todoLists.Add(ret);
            return ret;
        }

        public bool Equals(TodoListNamespaceModel? other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (other == null) return false;
            return (this.Id == other.Id)
                && this.TodoLists.SequenceEqual(other.TodoLists);
        }
    }
}
