using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MindPlan.Shared.Tools
{
    public abstract class TrackableObjectBase: ObservableObject
    {
        public Guid Id { get; private set; }
        
        protected TrackableObjectBase(Guid id)
        {
            this.Id = id;
        }
    }
}
