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
        public Shared.TodoList.TodoList Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<TodoListJson>(str).Create();
        }

        public string Serialize(Shared.TodoList.TodoList todoList)
        {
            return JsonConvert.SerializeObject(new TodoListJson(todoList));
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class TodoListJson
        {
            [JsonProperty]
            public List<TodoListItemJson> Items { get; set; }

            [JsonProperty]
            public Guid Id { get; set; }

            public Shared.TodoList.TodoList Create()
            {
                return new Shared.TodoList.TodoList(Id, Items.Select(i => i.Create()).ToList());
            }

            public TodoListJson()
            {
            }

            public TodoListJson(Shared.TodoList.TodoList todoList)
            {
                Items = todoList.Items.Select(i => new TodoListItemJson(i)).ToList();
                Id = todoList.Id;
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class TodoListItemJson
        {
            [JsonProperty]
            public Guid Id { get; set; }

            [JsonProperty]
            public string Text { get; set; }

            public TodoListItem Create()
            {
                return new TodoListItem(Id) { Text = Text };
            }

            public TodoListItemJson()
            {
            }

            public TodoListItemJson(TodoListItem item)
            {
                Id = item.Id;
                Text = item.Text;
            }
        }
    }
}
