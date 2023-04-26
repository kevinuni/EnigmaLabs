using Enigma.Domain.Dto;

namespace Numion.Services.Process.Demo
{
    public class ProcessDemoFactory
    {
        public static ProcessObject<PersonaDto> update(PersonaDto planillaDto, TypeBusinessProcess typeBusinessProcess)
        {
            ProcessObject<PersonaDto> processPlanilla = null;
            if (typeBusinessProcess == TypeBusinessProcess.Saving)
            {
                processPlanilla = new ProcessContainer<PersonaDto>(planillaDto, typeBusinessProcess);
                processPlanilla = new ProcessDemoStageOne(processPlanilla, typeBusinessProcess);
                processPlanilla = new ProcessDemoStageTwo(processPlanilla, typeBusinessProcess);
            }
            else if (typeBusinessProcess == TypeBusinessProcess.Deleting)
            {
                processPlanilla = new ProcessContainer<PersonaDto>(planillaDto, typeBusinessProcess);
                processPlanilla = new ProcessDemoStageTwo(processPlanilla, typeBusinessProcess);
                processPlanilla = new ProcessDemoStageOne(processPlanilla, typeBusinessProcess);
            }
            else
            {
                throw new Exception("Process not defined");
            }

            return processPlanilla;
        }
    }
}