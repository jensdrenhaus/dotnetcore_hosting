using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PhyNetFlow.OMNeT
{
    /// <inheritdoc />
    /// <summary>
    /// A <see cref="T:System.Threading.SynchronizationContext" /> that will tasks batch-wise.
    /// </summary>
    public class BulkExecutingSynchronizationContext : SynchronizationContext
    {
        private readonly BlockingCollection<Task> _tasks = new BlockingCollection<Task>();

        /// <summary>
        /// At first, tasks need to be executed immediately, to set up an ActorSystem.
        /// </summary>
        private bool _shouldExecuteImmediately = true;

        public BulkExecutingSynchronizationContext()
        {
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            if (_shouldExecuteImmediately)
            {
                base.Post(d, state);
            }
            else
            {
                _tasks.Add(new Task(() => d(state)));
            }
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            if (_shouldExecuteImmediately)
            {
                base.Post(d, state);
            }
            else
            {
                _tasks.Add(new Task(() => d(state)));
            }
        }

        /// <summary>
        /// After calling this, all work to be done will be queued, until manually told to execute the tasks.
        /// </summary>
        public void EnterControlledExecutionMode()
        {
            _shouldExecuteImmediately = false;
        }

        public void ExitControlledExecutionMode()
        {
            _shouldExecuteImmediately = true;
            ExecuteAll();
        }

        public void ExecuteAll()
        {
            while (_tasks.TryTake(out var task))
            {
                task.RunSynchronously();
            }
        }

        public override SynchronizationContext CreateCopy()
        {
            return new BulkExecutingSynchronizationContext();
        }

        public IEnumerable<Task> Queue
        {
            get
            {
                if (_tasks.TryTake(out var t))
                {
                    yield return t;
                }
            }
        }
    }
}