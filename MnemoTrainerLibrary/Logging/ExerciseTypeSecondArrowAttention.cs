using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип тренировки внимания секундной стрелкой.
    /// </summary>
    public class ExerciseTypeSecondArrowAttention : ExerciseType
    {
        public ExerciseTypeSecondArrowAttention()
        {
            this.type = TrainType.SecondArrowAttention;
        }

        public override string GetDescription()
        {
            return "Тренировка внимания секундной стрелкой.";
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseTypeSecondArrowAttention))
            {
                return false;
            }

            return true;
        }
    }
}
