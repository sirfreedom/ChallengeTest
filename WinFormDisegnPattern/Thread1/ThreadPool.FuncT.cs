﻿using System;

namespace WinFormDisegnPattern.Thread1
{
    public partial class ThreadPool
    {
        /// <summary>
        ///     Enqueues the work item. Returns a work-item-state-struct as a handle to the operation that is just about, or
        ///     queued, to be executed.
        ///     <para>Information on the returned struct... </para>
        ///     <para>
        ///         Call the result property on this struct to trigger a lock, thus blocking your current thread until the function
        ///         has executed.
        ///     </para>
        ///     <para>
        ///         Call Dispose on that returned item to automatically reuse the data-structure behind each work-item in order to
        ///         avoid
        ///         garbage-collector-cycles.
        ///     </para>
        ///     <para>
        ///         Use its <c>IsCompleted</c>-Property to verify within a monitor if your method has finished executing. The
        ///         <c>IsCompleted</c>-Property actually triggers a WaitOne(1) on a
        ///         ManualResetEvent internally thus returning almost instantly.
        ///     </para>
        /// </summary>
        /// <typeparam name="V">The type of the result.</typeparam>
        /// <param name="workerFunction">The worker function.</param>
        /// <param name="asyncCallback">The async callback.</param>
        /// <returns>
        ///     Returns a work-item-state-struct as a handle to the operation that is just about, or queued, to be executed.
        /// </returns>
        public IWorkItemState<V> EnqueueWorkItem<V>(Func<V> workerFunction, CallbackFunction asyncCallback = null)
        {
            var workItem = GetWorkItem(asyncCallback);
            workItem.DelegateInputParameters = new object[] {};
            workItem.Delegate = delegateInputParameters => { return workerFunction.Invoke(); };

            var workItemState = new WorkItemState<V>(workItem.WorkItemStateTypeless);
            EnqueueWorkItemInternal(workItem);
            return workItemState;
        }

        /// <summary>
        ///     Enqueues the work item. Returns a work-item-state-struct as a handle to the operation that is just about, or
        ///     queued, to be executed.
        ///     <para>Information on the returned struct... </para>
        ///     <para>
        ///         Call the result property on this struct to trigger a lock, thus blocking your current thread until the function
        ///         has executed.
        ///     </para>
        ///     <para>
        ///         Call Dispose on that returned item to automatically reuse the data-structure behind each work-item in order to
        ///         avoid
        ///         garbage-collector-cycles.
        ///     </para>
        ///     <para>
        ///         Use its <c>IsCompleted</c>-Property to verify within a monitor if your method has finished executing. The
        ///         <c>IsCompleted</c>-Property actually triggers a WaitOne(1) on a
        ///         ManualResetEvent internally thus returning almost instantly.
        ///     </para>
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="V">The type of the result.</typeparam>
        /// <param name="workerFunction">The worker function.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="asyncCallback">The async callback.</param>
        /// <returns>
        ///     Returns a work-item-state-struct as a handle to the operation that is just about, or queued, to be executed.
        /// </returns>
        public IWorkItemState<V> EnqueueWorkItem<T1, V>(Func<T1, V> workerFunction, T1 arg1,
            CallbackFunction asyncCallback = null)
        {
            var workItem = GetWorkItem(asyncCallback);

            workItem.DelegateInputParameters = new object[] {arg1};
            workItem.Delegate = delegateInputParameters => workerFunction.Invoke(arg1);

            var workItemState = new WorkItemState<V>(workItem.WorkItemStateTypeless);
            EnqueueWorkItemInternal(workItem);
            return workItemState;
        }

        /// <summary>
        ///     Enqueues the work item. Returns a work-item-state-struct as a handle to the operation that is just about, or
        ///     queued, to be executed.
        ///     <para>Information on the returned struct... </para>
        ///     <para>
        ///         Call the result property on this struct to trigger a lock, thus blocking your current thread until the function
        ///         has executed.
        ///     </para>
        ///     <para>
        ///         Call Dispose on that returned item to automatically reuse the data-structure behind each work-item in order to
        ///         avoid
        ///         garbage-collector-cycles.
        ///     </para>
        ///     <para>
        ///         Use its <c>IsCompleted</c>-Property to verify within a monitor if your method has finished executing. The
        ///         <c>IsCompleted</c>-Property actually triggers a WaitOne(1) on a
        ///         ManualResetEvent internally thus returning almost instantly.
        ///     </para>
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <typeparam name="V">The type of the result.</typeparam>
        /// <param name="workerFunction">The worker function.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <param name="asyncCallback">The async callback.</param>
        /// <returns>
        ///     Returns a work-item-state-struct as a handle to the operation that is just about, or queued, to be executed.
        /// </returns>
        public IWorkItemState<V> EnqueueWorkItem<T1, T2, V>(Func<T1, T2, V> workerFunction, T1 arg1, T2 arg2,
            CallbackFunction asyncCallback = null)
        {
            var workItem = GetWorkItem(asyncCallback);
            workItem.DelegateInputParameters = new object[] {arg1, arg2};
            workItem.Delegate = delegateInputParameters => workerFunction.Invoke(arg1, arg2);

            var workItemState = new WorkItemState<V>(workItem.WorkItemStateTypeless);
            EnqueueWorkItemInternal(workItem);
            return workItemState;
        }

        /// <summary>
        ///     Enqueues the work item. Returns a work-item-state-struct as a handle to the operation that is just about, or
        ///     queued, to be executed.
        ///     <para>Information on the returned struct... </para>
        ///     <para>
        ///         Call the result property on this struct to trigger a lock, thus blocking your current thread until the function
        ///         has executed.
        ///     </para>
        ///     <para>
        ///         Call Dispose on that returned item to automatically reuse the data-structure behind each work-item in order to
        ///         avoid
        ///         garbage-collector-cycles.
        ///     </para>
        ///     <para>
        ///         Use its <c>IsCompleted</c>-Property to verify within a monitor if your method has finished executing. The
        ///         <c>IsCompleted</c>-Property actually triggers a WaitOne(1) on a
        ///         ManualResetEvent internally thus returning almost instantly.
        ///     </para>
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <typeparam name="T3">The type of the 3.</typeparam>
        /// <typeparam name="V">The type of the result.</typeparam>
        /// <param name="workerFunction">The worker function.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <param name="arg3">The arg3.</param>
        /// <param name="asyncCallback">The async callback.</param>
        /// <returns>
        ///     Returns a work-item-state-struct as a handle to the operation that is just about, or queued, to be executed.
        /// </returns>
        public IWorkItemState<V> EnqueueWorkItem<T1, T2, T3, V>(Func<T1, T2, T3, V> workerFunction, T1 arg1, T2 arg2,
            T3 arg3,
            CallbackFunction asyncCallback = null)
        {
            var workItem = GetWorkItem(asyncCallback);
            workItem.DelegateInputParameters = new object[] {arg1, arg2, arg3};
            workItem.Delegate = delegateInputParameters => workerFunction.Invoke(arg1, arg2, arg3);

            var workItemState = new WorkItemState<V>(workItem.WorkItemStateTypeless);
            EnqueueWorkItemInternal(workItem);
            return workItemState;
        }

        /// <summary>
        ///     Enqueues the work item. Returns a work-item-state-struct as a handle to the operation that is just about, or
        ///     queued, to be executed.
        ///     <para>Information on the returned struct... </para>
        ///     <para>
        ///         Call the result property on this struct to trigger a lock, thus blocking your current thread until the function
        ///         has executed.
        ///     </para>
        ///     <para>
        ///         Call Dispose on that returned item to automatically reuse the data-structure behind each work-item in order to
        ///         avoid
        ///         garbage-collector-cycles.
        ///     </para>
        ///     <para>
        ///         Use its <c>IsCompleted</c>-Property to verify within a monitor if your method has finished executing. The
        ///         <c>IsCompleted</c>-Property actually triggers a WaitOne(1) on a
        ///         ManualResetEvent internally thus returning almost instantly.
        ///     </para>
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <typeparam name="T3">The type of the 3.</typeparam>
        /// <typeparam name="T4">The type of the 4.</typeparam>
        /// <typeparam name="V">The type of the result.</typeparam>
        /// <param name="workerFunction">The worker function.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <param name="arg3">The arg3.</param>
        /// <param name="arg4">The arg4.</param>
        /// <param name="asyncCallback">The async callback.</param>
        /// <returns>
        ///     Returns a work-item-state-struct as a handle to the operation that is just about, or queued, to be executed.
        /// </returns>
        public IWorkItemState<V> EnqueueWorkItem<T1, T2, T3, T4, V>(Func<T1, T2, T3, T4, V> workerFunction, T1 arg1,
            T2 arg2,
            T3 arg3, T4 arg4, CallbackFunction asyncCallback = null)
        {
            var workItem = GetWorkItem(asyncCallback);
            workItem.DelegateInputParameters = new object[] {arg1, arg2, arg3, arg4};
            workItem.Delegate = delegateInputParameters => workerFunction.Invoke(arg1, arg2, arg3, arg4);

            var workItemState = new WorkItemState<V>(workItem.WorkItemStateTypeless);
            EnqueueWorkItemInternal(workItem);
            return workItemState;
        }

        /// <summary>
        ///     Enqueues the work item. Returns a work-item-state-struct as a handle to the operation that is just about, or
        ///     queued, to be executed.
        ///     <para>Information on the returned struct... </para>
        ///     <para>
        ///         Call the result property on this struct to trigger a lock, thus blocking your current thread until the function
        ///         has executed.
        ///     </para>
        ///     <para>
        ///         Call Dispose on that returned item to automatically reuse the data-structure behind each work-item in order to
        ///         avoid
        ///         garbage-collector-cycles.
        ///     </para>
        ///     <para>
        ///         Use its <c>IsCompleted</c>-Property to verify within a monitor if your method has finished executing. The
        ///         <c>IsCompleted</c>-Property actually triggers a WaitOne(1) on a
        ///         ManualResetEvent internally thus returning almost instantly.
        ///     </para>
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <typeparam name="T3">The type of the 3.</typeparam>
        /// <typeparam name="T4">The type of the 4.</typeparam>
        /// <typeparam name="T5">The type of the 5.</typeparam>
        /// <typeparam name="V">The type of the result.</typeparam>
        /// <param name="workerFunction">The worker function.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <param name="arg3">The arg3.</param>
        /// <param name="arg4">The arg4.</param>
        /// <param name="arg5">The arg5.</param>
        /// <param name="asyncCallback">The async callback.</param>
        /// <returns>
        ///     Returns a work-item-state-struct as a handle to the operation that is just about, or queued, to be executed.
        /// </returns>
        public IWorkItemState<V> EnqueueWorkItem<T1, T2, T3, T4, T5, V>(Func<T1, T2, T3, T4, T5, V> workerFunction,
            T1 arg1,
            T2 arg2, T3 arg3, T4 arg4, T5 arg5, CallbackFunction asyncCallback = null)
        {
            var workItem = GetWorkItem(asyncCallback);
            workItem.DelegateInputParameters = new object[] {arg1, arg2, arg3, arg4, arg5};
            workItem.Delegate = delegateInputParameters => workerFunction.Invoke(arg1, arg2, arg3, arg4, arg5);

            var workItemState = new WorkItemState<V>(workItem.WorkItemStateTypeless);
            EnqueueWorkItemInternal(workItem);
            return workItemState;
        }
    }
}