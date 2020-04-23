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
            var list = new Shared.TodoList.TodoList(Guid.NewGuid(), new[] {
                new TodoListItem(Guid.NewGuid()),
                new TodoListItem(Guid.NewGuid()) {Text = "My test text"}
            });

            string s = testObj.Serialize(list);
            var newList = testObj.Deserialize(s);

            Assert.Equal(list, newList);
        }
    }
}
