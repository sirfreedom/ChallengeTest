using System.Threading;

namespace WinFormDisegnPattern.Thread1
{
    /// <summary>
    ///     This is a wrapper-class for a work item.
    /// </summary>
    public class WorkItem
    {
        private object result;

        public bool IsCompleted { get; set; }
        internal ThreadPool.WorkItemCallback Delegate { get; set; }
        public object DelegateInputParameters { get; set; }
        public WorkItemStateTypeless WorkItemStateTypeless { get; set; }
        public SingleThreadRunner SingleThreadRunner { get; set; }

        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public object Result
        {
            get
            {
                // SpinWait for the workItem to finish.
                var spinWait = new SpinWait();
                while (!IsCompleted)
                {
                    spinWait.SpinOnce();
                    Thread.MemoryBarrier();
                }
                return result;
            }
            set { result = value; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorkItem" /> class.
        /// </summary>
        internal WorkItem()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorkItem" /> class.
        /// </summary>
        internal WorkItem(ThreadPool.WorkItemCallback functionDelegate, object delegateInputParameters)
        {
            Delegate = functionDelegate;
            DelegateInputParameters = delegateInputParameters;
            WorkItemStateTypeless = new WorkItemStateTypeless(this);
        }

        /// <summary>
        ///     Gets or sets the async callback.
        /// </summary>
        /// <value>The async callback.</value>
        public ThreadPool.CallbackFunction AsyncCallback { get; set; }
    }
}