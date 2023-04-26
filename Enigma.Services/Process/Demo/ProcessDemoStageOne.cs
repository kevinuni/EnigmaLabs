using Enigma.Domain.Dto;

namespace Numion.Services.Process.Demo
{
    public class ProcessDemoStageOne : ProcessDecorator<PersonaDto>
    {
        public ProcessDemoStageOne(ProcessObject<PersonaDto> processPlanilla, TypeBusinessProcess typeBusinessProcess) : base(processPlanilla, typeBusinessProcess)
        {
        }

        public override bool Process()
        {
            bool result = true;
            result &= m_processBase.Process();

            if (m_TypeBusinessProcess == TypeBusinessProcess.Saving)
            {
                //do fancy things to save
            }
            else if (m_TypeBusinessProcess == TypeBusinessProcess.Deleting)
            {
                // do fancy things to delete
            }
            else
            {
                throw new Exception("Process not defined");
            }

            return result;
        }
    }
}