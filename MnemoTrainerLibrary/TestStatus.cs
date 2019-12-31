
namespace MnemoTrainerLibrary
{
    public enum TestStatus
    {
        /// <summary>
        /// Тест в процессе.
        /// </summary>
        IsGoing,

        /// <summary>
        /// Не начат.
        /// </summary>
        NotStarted,

        /// <summary>
        /// Тест в процессе проверки.
        /// </summary>
        IsChecking,

        /// <summary>
        /// Закончен.
        /// </summary>
        Finished,

        /// <summary>
        /// Отображение ошибки
        /// </summary>
        isError,

        /// <summary>
        /// Автоматическое отображение вопросов
        /// </summary>
        isAutoShowing
    }
}
