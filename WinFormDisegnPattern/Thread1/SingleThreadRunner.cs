using System.Threading;

namespace WinFormDisegnPattern.Thread1
{
    /// <summary>
    ///     This is a frame for a single thread to run the defined payload.
    /// </summary>
    public class SingleThreadRunner
    {
        private bool signalClose;
        private bool signalWork;

        private WorkItem currentWorkItem;

        public ThreadPool ThreadPool { get; set; }
        public Thread Thread { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SingleThreadRunner" /> class.
        /// </summary>
        public SingleThreadRunner()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SingleThreadRunner" /> class.
        /// </summary>
        /// <param name="threadPool">The thread pool.</param>
        public SingleThreadRunner(ThreadPool threadPool)
        {
            ThreadPool = threadPool;
        }

        /// <summary>
        ///     Does the work reacting on and setting various signals.
        /// </summary>
        public void DoWork()
        {
            var spinWait = new SpinWait();
            while (!signalClose)
            {
                if (signalWork)
                {
                    while (currentWorkItem != null && !signalClose)
                    {
                        // Start the payload.
                        currentWorkItem.Result = currentWorkItem.Delegate(currentWorkItem.DelegateInputParameters);

                        // Set the work item to completed.
                        currentWorkItem.IsCompleted = true;

                        // Call the async callback - method, if available.
                        if (currentWorkItem.AsyncCallback != null)
                        {
                            currentWorkItem.AsyncCallback.Invoke();
                        }

                        // Dequeue the next work item.
                        if (ThreadPool.IsDisposeDoneWorkItemsAutomatically)
                        {
                            // Return the work item automatically for reuse, if preferred.
                            currentWorkItem = ThreadPool.DequeueWorkItemInternal(this, signalWork, currentWorkItem);
                        }
                        else
                        {
                            currentWorkItem = ThreadPool.DequeueWorkItemInternal(this, signalWork);
                        }
                    }
                    // The worker has no more work or is paused.
                    signalWork = false;
                }
                else
                {
                    spinWait.SpinOnce();
                }
            }
            // The thread is dead.
            signalClose = false;
        }

        /// <summary>
        ///     Signals this instance to immediately start doing some work.
        /// </summary>
        public void SignalWork(WorkItem workItemToProcess)
        {
            // Wait for the main loop to be not busy before changing the current workItem.
            var spinWait = new SpinWait();
            while (signalWork)
            {
                spinWait.SpinOnce();
                Thread.MemoryBarrier();
            }
            Interlocked.Exchange(ref currentWorkItem, workItemToProcess);
            signalWork = true;
            Thread.MemoryBarrier();
        }

        /// <summary>
        ///     Signals the workers to close.
        /// </summary>
        public void SignalShutDown()
        {
            signalClose = true;
        }

        /// <summary>
        ///     Signals the workers to pause.
        /// </summary>
        public void SignalPause()
        {
            Thread.MemoryBarrier();
            signalWork = false;
            Thread.MemoryBarrier();
        }

        /// <summary>
        ///     Signals the workers to resume.
        /// </summary>
        public void SignalResume()
        {
            Thread.MemoryBarrier();
            signalWork = true;
            Thread.MemoryBarrier();
        }

        /// <summary>
        ///     Aborts this instance.
        /// </summary>
        public void Abort()
        {
 
        }
    }
}