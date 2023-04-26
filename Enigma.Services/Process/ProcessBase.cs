namespace Numion.Services.Process
{
    public enum TypeBusinessProcess
    { Saving, Deleting }

    public abstract class ProcessBase
    {
        public abstract bool Process();

        public TypeBusinessProcess m_TypeBusinessProcess { get; set; }
    }
}