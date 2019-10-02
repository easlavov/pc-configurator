namespace PCConfigurator.Application.Exceptions
{
    using System;

    public class ComponentInUseException : ApplicationException
    {
        private const string ErrorMessage = "The component is in use by an existing configuration!";

        public override string Message => ErrorMessage;
    }
}
