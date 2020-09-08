using System.Collections.Generic;
using System.ComponentModel;

namespace ChatterBot.Domain.State
{
    public abstract class BaseSet<T>
    {
        public BindingList<T> Items { get; protected set; } = new BindingList<T>();

        public void Initialize(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
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