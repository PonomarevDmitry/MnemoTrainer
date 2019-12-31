
namespace MnemoTrainerLibrary.Classes
{
    /// <summary>
    /// Общий тип упражнения.
    /// </summary>
    public enum TrainType
    {
        None,

        /// <summary>
        /// Устный счет
        /// </summary>
        Calculate,

        /// <summary>
        /// Устный счет рядов
        /// </summary>
        CalculationSeries,

        /// <summary>
        /// Вычисление дня недели
        /// </summary>
        Date,

        /// <summary>
        /// Тренировка зрительной памяти
        /// </summary>
        Impression,

        /// <summary>
        /// Тренировка цифрового алфавита
        /// </summary>
        NumericAlphabet,

        /// <summary>
        /// Тренировка кратковременной памяти
        /// </summary>
        RecentMemory,

        /// <summary>
        /// Упражнение Степанова
        /// </summary>
        Stepanov,

        /// <summary>
        /// Тренировка внимания секундной стрелкой
        /// </summary>
        SecondArrowAttention,

        /// <summary>
        /// Чтение с прерыванием.
        /// </summary>
        InterruptionReading,

        /// <summary>
        /// Тест Струпа
        /// </summary>
        Strup,

        /// <summary>
        /// Генератор чисел
        /// </summary>
        NumberGenerator,

        /// <summary>
        /// Тренировка сетки
        /// </summary>
        NetTrain,

        /// <summary>
        /// Последовательные ассоциации.
        /// </summary>
        ConsecutiveAssociations,

        /// <summary>
        /// Закрытые ассоциации.
        /// </summary>
        ClosedAssociations,

        /// <summary>
        /// Числовые ассоциации.
        /// </summary>
        NumberAssociations,

        /// <summary>
        /// Ассоциации пар.
        /// </summary>
        AssociationsPair,

        /// <summary>
        /// Упражнение 100 за 100
        /// </summary>
        Train100For100
    }
}
