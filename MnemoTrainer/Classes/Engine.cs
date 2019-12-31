using MnemoTrainerLibrary;
using SAClasses;

namespace MnemoTrainer.Classes
{
    public static class Engine
    {
        public static Controller controller;

        static Engine()
        {
            controller = new Controller();

            controller.SystemAccumulation = SASerializer.CreateSAFromXml(Config.SystemAccumulationFileName);
        }
    }
}
