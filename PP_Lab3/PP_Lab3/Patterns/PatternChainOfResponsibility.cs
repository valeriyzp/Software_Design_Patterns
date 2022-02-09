using System;

namespace PP_Lab3.Patterns
{
    public interface IHandler
    {
        public void setNext(IHandler handler);
        public void handle(string request);
    }

    public abstract class BaseHandler : IHandler
    {
        private IHandler _Next { get; set; }

        public void setNext(IHandler handler)
        {
            _Next = handler;
        }

        public virtual void handle(string request)
        {
            if (_Next != null)
                _Next.handle(request);
        }
    }

    public class ErrorHandler : BaseHandler
    {
        public override void handle(string request)
        {
            Console.WriteLine($"Error handler received: {request}");
            base.handle(request);
        }
    }

    public class ValidationHandler : BaseHandler
    {
        public override void handle(string request)
        {
            Console.WriteLine($"Validation handler received: {request}");
            base.handle(request);
        }
    }
}
