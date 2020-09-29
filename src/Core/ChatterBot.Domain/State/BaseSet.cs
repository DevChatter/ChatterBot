using System.Collections.Generic;
using System.ComponentModel;

namespace ChatterBot.Domain.State
{
    public abstract class BaseSet<T>
    {
        public BindingList<T> Items { get; protected set; }

        protected BaseSet(List<T> items)
        {
            Items = new BindingList<T>(items)
            {
                AllowNew = true,
                AllowRemove = true,
                AllowEdit = true,
                RaiseListChangedEvents = true,
            };
        }

        public void Register(T item)
        {
            Items.Add(item);
        }

        public void UnRegister(T item)
        {
            Items.Remove(item);
        }
    }
}