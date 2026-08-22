namespace NicoPasino.Core.Errores
{
    public class DataException : Exception
    {
        public DataException(string message) : base(message) { }
        public DataException(string message, int[] affectedIds) : base(message) { AffectedIds = affectedIds; }
        public int[] AffectedIds { get; set; } = [];
    }
}
