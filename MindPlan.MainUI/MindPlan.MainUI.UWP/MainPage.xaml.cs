using MindPlan.Json.TodoList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MindPlan.MainUI
{
    // TODO: remove
    partial class MainPage
    {
        const string saveFileName = "myTodoList.json";
        private readonly TodoListSerializer serializer = new TodoListSerializer();

        partial void LoadModel()
        {
            Task.Run(async () => await MyImpl().ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        partial void SaveModel()
        {
            Task.Run(async () => await MyIml().ConfigureAwait(false)).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        async Task MyImpl()
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var it = await storageFolder.TryGetItemAsync(saveFileName);
            if (it == null)
            {
                return;
            }
            var f = await storageFolder.GetFileAsync(saveFileName);
            var s = FileIO.ReadTextAsync(f).GetResults();
            this._model = this.serializer.Deserialize(s);
        }

        async Task MyIml()
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var it = await storageFolder.TryGetItemAsync(saveFileName);
            StorageFile f;
            if (it == null)
            {
                f = await storageFolder.CreateFileAsync(saveFileName);
            }
            else
            {
                f = await storageFolder.GetFileAsync(saveFileName);
            }
            string s = this.serializer.Serialize(_model);
            FileIO.WriteTextAsync(f, s).GetResults();
        }

    }
}
