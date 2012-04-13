using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnOOInterface.Composite
{
    public abstract class BaseComponent:IComponent
    {
        IdentityMap<IComponent> componentMap = null;

        IComponent myParent;

        public BaseComponent()
        {
            myParent = null;
        }

        IdentityMap<IComponent> CurrentProvider
        {
            get
            {
                if (componentMap == null)
                {
                    componentMap = new IdentityMap<IComponent>();
                }
                return componentMap;
            }
        }

        #region IComponent Members

        public virtual IComponent Add(IComponent newChild)
        {
            CurrentProvider.Add(newChild, Guid.NewGuid());

            return newChild;
        }

        public virtual IComponent Remove(IComponent usedChild)
        {
            CurrentProvider.Remove(CurrentProvider.GetEntityKey(usedChild));
            return usedChild;
        }

        public virtual IComponent Parent
        {
            get
            {
                return myParent;
            }
            set
            {
                if (myParent != value)
                {
                    myParent = value;
                }
            }
        }

        public virtual IEnumerable<IComponent> Items()
        {
            return CurrentProvider.GetEnumerable();
        }

        public abstract String Display();

        #endregion

    }

    public class IdentityMap<T>
    {
        Dictionary<Guid, T> entitiesMap = new Dictionary<Guid, T>();

        public T GetById(Guid key)
        {
            if (entitiesMap.ContainsKey(key))
                return (T)entitiesMap[key];
            else
                return default(T);
        }

        public void Add(T entity, Guid key)
        {
            if (!entitiesMap.ContainsKey(key))
            {
                entitiesMap.Add(key, entity);
            }
        }

        public T Remove(Guid key)
        {
            T currentEntiy = default(T);
            if (entitiesMap.ContainsKey(key))
            {
                currentEntiy = entitiesMap[key];
                entitiesMap.Remove(key);
            }

            return currentEntiy;
        }

        public Guid GetEntityKey(T currentEntity)
        {
            return (from item in entitiesMap where item.Value.Equals(currentEntity) select item.Key).FirstOrDefault();
        }

        public IEnumerable<T> GetEnumerable()
        {
            foreach (var curItem in entitiesMap.Values)
            {
                yield return curItem;
            }
        }
    }

}
