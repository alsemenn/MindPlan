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
            var ns = new TodoListNamespaceModel(Guid.NewGuid(), new[] {
                new TodoListModel(Guid.NewGuid(), "Name 1", new[] {
                    new TodoItemModel(Guid.NewGuid(), string.Empty),
                    new TodoItemModel(Guid.NewGuid(), "My test text")
                }),
                new TodoListModel(Guid.NewGuid(), "Na2e 1", new[] {
                    new TodoItemModel(Guid.NewGuid(), "Some text"),
                    new TodoItemModel(Guid.NewGuid(), string.Empty)
                })
            });

            string s = testObj.Serialize(ns);
            var newNs = testObj.Deserialize(s);

            Assert.Equal(ns, newNs);
        }
    }
}
