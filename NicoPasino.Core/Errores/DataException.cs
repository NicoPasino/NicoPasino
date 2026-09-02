namespace NicoPasino.Core.Errores
{
    public class DataException : Exception
    {
        public DataException(string message) : base(message) { }
        public DataException(string message, int[] affectedIds) : base(message) { AffectedIds = affectedIds; }
        public int[] AffectedIds { get; set; } = [];
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class UpdateException : Exception
    {
        public UpdateException(string message) : base(message) { }
    }
}
