using System;

namespace GM.ApplicationCore.Entities.Govbodies
{
    public class GovbodyNotFoundException : Exception
    {
        public GovbodyNotFoundException(int govbodyId) : base($"No govbody found with id {govbodyId}")
        {
        }

        protected GovbodyNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public GovbodyNotFoundException(string message) : base(message)
        {
        }

        public GovbodyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
