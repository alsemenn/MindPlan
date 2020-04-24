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
        public Shared.TodoList.TodoListModel Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<TodoListJson>(str).Create();
        }

        public string Serialize(TodoListModel todoList)
        {
            return JsonConvert.SerializeObject(new TodoListJson(todoList));
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class TodoListJson
        {
            [JsonProperty]
            public List<TodoItemJson> Items { get; set; }

            [JsonProperty]
            public Guid Id { get; set; }

            public TodoListModel Create()
            {
                return new TodoListModel(Id, Items.Select(i => i.Create()).ToList());
            }

            public TodoListJson()
            {
            }

            public TodoListJson(TodoListModel todoList)
            {
                Items = todoList.Items.Select(i => new TodoItemJson(i)).ToList();
                Id = todoList.Id;
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
                return new TodoItemModel(Id) { Text = Text };
            }

            public TodoItemJson()
            {
            }

            public TodoItemJson(TodoItemModel item)
            {
                Id = item.Id;
                Text = item.Text;
            }
        }
    }
}
