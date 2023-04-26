namespace Numion.Services.Process
{
    public abstract class ProcessObject<T> : ProcessBase
    {
        protected T m_processObject;

        public T processObject
        {
            get
            {
                return m_processObject;
            }
        }
    }
}