using System;


namespace WinFormDisegnPattern.Thread1
{
    /// <summary>
    ///     This is an interface for a thread-workItem.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    public interface IWorkItemState<out T> : IDisposable
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is completed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is completed; otherwise, <c>false</c>.
        /// </value>
        bool IsStopped { get; }

        /// <summary>
        ///     Is a blocking operation.
        ///     Gets the result.
        /// </summary>
        /// <value>The result.</value>
        T Result { get; }
    }

    /// <summary>
    ///     This is an interface for a thread-workItem.
    /// </summary>
    public interface IWorkItemState : IDisposable
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is completed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is completed; otherwise, <c>false</c>.
        /// </value>
        bool IsStopped { get; }

        /// <summary>
        ///     Is a blocking operation.
        ///     Waits for the work item to finish.
        /// </summary>
        /// <value>The result.</value>
        void Result();
    }
}