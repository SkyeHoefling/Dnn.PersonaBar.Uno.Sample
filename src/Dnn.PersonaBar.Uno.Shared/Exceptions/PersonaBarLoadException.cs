using System;

namespace Dnn.PersonaBar.Uno.Exceptions
{
    public class PersonaBarLoadException : Exception
    {
        public PersonaBarLoadException()
            : base("Failed to connect to the DNN persona bar! Ensure you are using the Persona Bar to render this page.") { }
    }
}
