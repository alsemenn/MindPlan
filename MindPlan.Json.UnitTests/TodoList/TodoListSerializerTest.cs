using MindPlan.Json.TodoList;
using MindPlan.Shared.TodoList;
using System;
using Xunit;

namespace MindPlan.Json.UnitTests
{
    public class TodoListSerializerTest
    {
        [Fact]
        public void SerializeDeserializeTest()
        {
            var testObj = new TodoListSerializer();
            var list = new Shared.TodoList.TodoListModel(Guid.NewGuid(), new[] {
                new TodoItemModel(Guid.NewGuid()),
                new TodoItemModel(Guid.NewGuid()) {Text = "My test text"}
            });

            string s = testObj.Serialize(list);
            var newList = testObj.Deserialize(s);

            Assert.Equal(list, newList);
        }
    }
}
