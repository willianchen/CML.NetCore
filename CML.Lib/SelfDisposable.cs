using System;

namespace CML.Lib
{
    public class SelfDisposable : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCode()
        {
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCode();
            }
            _isDisposed = true;
        }

        ~SelfDisposable()
        {
            Dispose(false);
        }
    }
}