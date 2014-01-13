using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoCraft.Entidades.GlobalObject
{
    public abstract class ItemCollection<T> where T : Item
    {
        private IList<T> _items = new List<T>();

        public virtual void AddItem(T item)
        {
            this.Items.Add(item);
        }

        public virtual void AddItemAt(T item, int position)
        {
            // siempre , es el item
            // si no es el final, item + 1            
            this.Items.Insert(position, item);
        }

        public virtual void RemoveItemAt(int position)
        {
            // si borro al final, nada
            // sino item + 1
            if (!InvalidIndex(position))
            {
                this.Items.RemoveAt(position);
            }
        }

        public virtual void RemoveItem(T item)
        {
            this.Items.Remove(item);
        }

        public virtual T GetPreviousItem(T item)
        {
            int pos = this.GetItemPos(item);
            if (pos == 0)
            {
                return null;
            }
            return this.GetItemOrNull(pos - 1);
        }

        public virtual void MoveItem(int oldpos, int newpos)
        {
            if (oldpos == newpos || InvalidIndex(oldpos))
            {
                return;
            }
            this.MoveItem(this.Items[oldpos], newpos);
        }

        public virtual void MoveItem(T item, int newpos)
        {
            // le aviso al + 1 de la nueva pos y al + 1 de la vieja pos
            if (InvalidIndex(newpos))
            {
                return;
            }
            this.Items.Remove(item);
            this.Items.Insert(newpos, item);
        }

        private bool InvalidIndex(int pos)
        {
            return pos < 0 || pos >= this.Items.Count;
        }

        public virtual int GetItemPos(T item)
        {
            return this.Items.IndexOf(item);
        }

        public virtual T GetItemOrNull(int pos)
        {
            if (InvalidIndex(pos))
            {
                return null;
            }
            return this.Items[pos];
        }

        public System.Collections.Generic.IList<T> Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }
    }
}
