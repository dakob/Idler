using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idler.Model
{
    public class TaskCollection: ICollection<IdleTask>
    {
        public int Count => Tasks.Count;

        public bool IsReadOnly => false;

        ICollection<IdleTask> Tasks { get; private set; }

        public void Add(IdleTask item)
        {
            throw new NotImplementedException()T
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IdleTask item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IdleTask[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IdleTask> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IdleTask item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
