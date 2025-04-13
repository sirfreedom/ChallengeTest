

namespace WinFormDisegnPattern.Thread1
{
    /// <summary>
    ///     The state and the remote control for a work item.
    /// </summary>
    public class WorkItemStateTypeless : IWorkItemStateTypeless
    {
        public WorkItem WorkItem { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is completed gracefully.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is completed gracefully; otherwise, <c>false</c>.
        /// </value>
        public bool IsStopped => WorkItem.IsCompleted;

        /// <summary>
        ///     Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public object Result => WorkItem.Result;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorkItemStateTypeless" /> class.
        /// </summary>
        /// <param name="workItem">The work item.</param>
        public WorkItemStateTypeless(WorkItem workItem)
        {
            WorkItem = workItem;
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing,
        ///     releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}