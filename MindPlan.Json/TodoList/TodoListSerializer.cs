using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MindPlan.Shared.TodoList;
using Newtonsoft.Json;

namespace MindPlan.Json.TodoList
{
    public class TodoListSerializer
    {
<<<<<<< HEAD
        public TodoListModel Deserialize(string str)
=======
        public TodoListNamespaceModel Deserialize(string str)
>>>>>>> Add list name
        {
            return JsonConvert.DeserializeObject<TodoNamespaceJson>(str).Create();
        }

        public string Serialize(TodoListNamespaceModel todoListNamespace)
        {
            return JsonConvert.SerializeObject(new TodoNamespaceJson(todoListNamespace));
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class TodoNamespaceJson
        {
            [JsonProperty]
            public List<TodoListJson> TodoLists { get; set; }

            [JsonProperty]
            public Guid Id { get; set; }

            public TodoNamespaceJson()
            {
                this.TodoLists = new List<TodoListJson>();
            }

            public TodoNamespaceJson(TodoListNamespaceModel model)
            {
                this.TodoLists = model.TodoLists.Select(_ => new TodoListJson(_)).ToList();
                this.Id = model.Id;
            }

            public TodoListNamespaceModel Create()
            {
                return new TodoListNamespaceModel(this.Id, this.TodoLists.Select(_ => _.Create()).ToList());
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class TodoListJson
        {
            [JsonProperty]
            public List<TodoItemJson> Items { get; set; }

            [JsonProperty]
            public Guid Id { get; set; }

            [JsonProperty]
            public string Name { get; set; }

            public TodoListModel Create()
            {
<<<<<<< HEAD
                return new TodoListModel(Id, Items.Select(i => i.Create()).ToList(), this.Name);
=======
                return new TodoListModel(Id, this.Name, Items.Select(i => i.Create()).ToList());
>>>>>>> Add list name
            }

            public TodoListJson()
            {
                Items = new List<TodoItemJson>();
                this.Name = "";
            }

            public TodoListJson(TodoListModel todoList)
            {
                this.Items = todoList.Items.Select(i => new TodoItemJson(i)).ToList();
                this.Id = todoList.Id;
                this.Name = todoList.Name;
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class TodoItemJson
        {
            [JsonProperty]
            public Guid Id { get; set; }

            [JsonProperty]
            public string Text { get; set; }

            public TodoItemModel Create()
            {
                return new TodoItemModel(this.Id, this.Text);
            }

            public TodoItemJson()
            {
                this.Text = "";
            }

            public TodoItemJson(TodoItemModel item)
            {
                Id = item.Id;
                Text = item.Text;
            }
        }
    }
}
