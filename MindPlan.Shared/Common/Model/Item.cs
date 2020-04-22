using System;
using System.Collections.Generic;
using System.Text;

namespace MindPlan.Shared.Common.Model
{
    /// <summary>
    /// A class to represent all items in the system.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Id of the time. A Guid property helps to be more explicit about items id, instead of relying on the databases to create one. 
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// A parent of the item. <i>Null</i> if the item is top-level.
        /// </summary>
        public Item? Parent { get; }

        public string Name { get; }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="name"> Name of the item. </param>
        /// <param name="id"> Item's id. If <i>null</i> will create new id. </param>
        /// <param name="parent"> Item's parent. </param>
        public Item(string name, Guid? id = null, Item? parent = null)
        {
            Id = id ?? Guid.NewGuid();
            Parent = parent;
            Name = name;
        }
    }
}
