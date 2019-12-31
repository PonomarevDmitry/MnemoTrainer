using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип тренировки сетки
    /// </summary>
    public class ExerciseTypeNetTrain : ExerciseType
    {
        public ExerciseTypeNetTrain()
        {
            this.type = TrainType.NetTrain;
        }

        public override string GetDescription()
        {
            string result = "Тренировка сетки.";

            return result;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeNetTrain))
            {
                return false;
            }

            return true;
        }
    }
}
