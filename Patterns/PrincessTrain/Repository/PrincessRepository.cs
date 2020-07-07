using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace DisneyPrincessApp
{
    class PrincessRepository: IRepository<Princess, int>
    {
        protected IList<Princess> list;

        public  PrincessRepository(IList<Princess> list)
        {
            this.list = list;
        }

        public Princess[] GetList()
        {
            return list.ToArray();
        }

        public virtual void AddElement(Princess item)
        {
            bool contains = list.Contains(item);
            if (contains == false)
            {
                list.Add(item);
            }
            else
            {
                throw new Exception();
            }
        }

        public virtual void DeleteElement(int atr)
        {

            bool isFind = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (atr == list[i].Number)
                {
                    list.Remove(list[i]);
                    isFind = true;
                }
            }
            if (!isFind)
            {
                throw new Exception();
            }
        }

        public virtual Princess GetElement(int atr) 
        {
            Princess element = null;
            foreach (var el in list)
            {
                if (atr == el.Number)
                {
                    element = el;
                    return element;
                }
            }
            return element;
        }

        public virtual void UpdateElement(Princess item)
        {
            bool contains = false;
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Number == item.Number)
                {
                    list[i] = item;
                    contains = true;
                }
            }
            if (!contains)
            {
                throw new Exception();
            }
        }
        
    }
}
