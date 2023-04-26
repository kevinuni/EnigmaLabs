namespace Numion.Services.Process
{
    public abstract class ProcessDecorator<T> : ProcessObject<T>
    {
        protected ProcessObject<T> m_processBase;

        protected ProcessDecorator(ProcessObject<T> processBase, TypeBusinessProcess typeBusinessProcess)
        {
            m_processBase = processBase;
            m_processObject = processBase.processObject;
            m_TypeBusinessProcess = typeBusinessProcess;
        }
    }
}