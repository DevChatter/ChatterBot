using System.Collections.Generic;

namespace ChatterBot.Domain.State
{
    public abstract class BaseSet<T>
    {
        public ICollection<T> Items { get; } = new HashSet<T>();

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