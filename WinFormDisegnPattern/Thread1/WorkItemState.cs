

namespace WinFormDisegnPattern.Thread1
{
    /// <summary>
    ///     This is an implementation of the <c>IWorkItemStateTypeless</c> interface.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    public struct WorkItemState<T> : IWorkItemState<T>
    {
        private bool disposed;
        private readonly WorkItemStateTypeless workItemStateTypeless;

        /// <summary>
        ///     Gets a value indicating whether this instance is completed gracefully.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is completed gracefully; otherwise, <c>false</c>.
        /// </value>
        public bool IsStopped => workItemStateTypeless.IsStopped;

        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public T Result => (T) workItemStateTypeless.Result;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorkItemState{TResult}" /> class.
        /// </summary>
        /// <param name="workItemStateTypeless">State of the work item.</param>
        public WorkItemState(WorkItemStateTypeless workItemStateTypeless)
        {
            this.workItemStateTypeless = workItemStateTypeless;
            disposed = false;
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and
        ///     unmanaged resources; <c>false</c> to release only unmanaged
        ///     resources.
        /// </param>
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    workItemStateTypeless.WorkItem.SingleThreadRunner.ThreadPool.ReturnWorkItem(
                        workItemStateTypeless.WorkItem);
                }
                disposed = true;
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing,
        ///     releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }

    /// <summary>
    ///     This is an implementation of the <c>IWorkItemStateTypeless</c> interface.
    /// </summary>
    public struct WorkItemState : IWorkItemState
    {
        private bool disposed;
        private readonly WorkItemStateTypeless workItemStateTypeless;

        /// <summary>
        ///     Gets a value indicating whether this instance is completed gracefully.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is completed gracefully; otherwise, <c>false</c>.
        /// </value>
        public bool IsStopped => workItemStateTypeless.IsStopped;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorkItemState{TResult}" /> class.
        /// </summary>
        /// <param name="workItemStateTypeless">State of the work item.</param>
        public WorkItemState(WorkItemStateTypeless workItemStateTypeless)
        {
            this.workItemStateTypeless = workItemStateTypeless;
            disposed = false;
        }

        /// <summary>
        ///     Is a blocking operation.
        ///     Waits for the work item to finish.
        /// </summary>
        /// <value>The result.</value>
        public void Result()
        {
#pragma warning disable 168
            var o = workItemStateTypeless.Result;
#pragma warning restore 168
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and
        ///     unmanaged resources; <c>false</c> to release only unmanaged
        ///     resources.
        /// </param>
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    workItemStateTypeless.WorkItem.SingleThreadRunner.ThreadPool.ReturnWorkItem(
                        workItemStateTypeless.WorkItem);
                }
                disposed = true;
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing,
        ///     releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}