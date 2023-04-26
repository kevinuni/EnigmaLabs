namespace Numion.Services.Process
{
    public class ProcessContainer<T> : ProcessObject<T>
    {
        public ProcessContainer(T processObject, TypeBusinessProcess typeBusinessProcess)
        {
            m_processObject = processObject;
            m_TypeBusinessProcess = typeBusinessProcess;
        }

        public override bool Process()
        {
            return true;
        }
    }
}