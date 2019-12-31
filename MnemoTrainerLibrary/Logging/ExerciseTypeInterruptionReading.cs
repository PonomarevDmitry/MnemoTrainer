using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип чтения с прерыванием.
    /// </summary>
    public class ExerciseTypeInterruptionReading : ExerciseType
    {
        public ExerciseTypeInterruptionReading()
        {
            this.type = TrainType.InterruptionReading;
        }

        public override string GetDescription()
        {
            return "Чтение с прерыванием.";
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeInterruptionReading))
            {
                return false;
            }

            return true;
        }
    }
}
