using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idler.Model
{
    public class IdleTasks: ICollection<IdleTask>
    {
        public int Count => Tasks.Count;

        public bool IsReadOnly => false;

        public ObservableCollection<IdleTask> Tasks { get; set; } = new ObservableCollection<IdleTask>();

        public void Add(IdleTask item)
        {
            Tasks.Add(item);
        }

        public void Clear()
        {
            Tasks.Clear();
        }

        public bool Contains(IdleTask item)
        {
            return Tasks.Contains(item);
        }

        public void CopyTo(IdleTask[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IdleTask> GetEnumerator()
        {
            return Tasks.GetEnumerator();
        }

        public bool Remove(IdleTask item)
        {
            return Tasks.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
