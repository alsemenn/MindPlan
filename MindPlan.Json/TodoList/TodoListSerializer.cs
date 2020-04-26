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
        public TodoListWorkspaceModel Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<TodoNamespaceJson>(str).Create();
        }

        public string Serialize(TodoListWorkspaceModel todoListWorkspace)
        {
            return JsonConvert.SerializeObject(new TodoNamespaceJson(todoListWorkspace));
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

            public TodoNamespaceJson(TodoListWorkspaceModel model)
            {
                this.TodoLists = model.TodoLists.Select(_ => new TodoListJson(_)).ToList();
                this.Id = model.Id;
            }

            public TodoListWorkspaceModel Create()
            {
                return new TodoListWorkspaceModel(this.Id, this.TodoLists.Select(_ => _.Create()).ToList());
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
                return new TodoListModel(Id, this.Name, Items.Select(i => i.Create()).ToList());
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
