namespace MnemoTrainerLibrary.Train
{
    /// <summary>
    /// Статус машины
    /// </summary>
    public enum MachineStatus
    {
        /// <summary>
        /// Не работает
        /// </summary>
        NotStarted,

        /// <summary>
        /// Отображение вопроса
        /// </summary>
        ShowingQuestion,

        /// <summary>
        /// Ожидание ответа
        /// </summary>
        WaitingAnswer,

        /// <summary>
        /// Проверка ответа по таймеру
        /// </summary>
        AutoCheckingAnswer,

        /// <summary>
        /// Пауза
        /// </summary>
        Pause,

        /// <summary>
        /// Отображение ошибки
        /// </summary>
        ShowingError,

        /// <summary>
        /// Автоотображение
        /// </summary>
        AutoShowing
    }
}
