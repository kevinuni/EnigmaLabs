using System.Collections.Concurrent;

namespace Util
{
    public class FixedSizedQueue<T>
    {
        private ConcurrentQueue<T> q = new ConcurrentQueue<T>();
        private object lockObject = new object();

        public int Limit { get; set; }

        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            lock (lockObject)
            {
                T overflow;
                while (q.Count > Limit && q.TryDequeue(out overflow)) ;
            }
        }

        public bool Dequeue(out T item)
        {
            return q.TryDequeue(out item);
        }
    }
}