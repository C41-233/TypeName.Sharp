namespace TypeName.Container
{
    public sealed class NullableName
    {

        internal static readonly NullableName True = new NullableName(true);
        internal static readonly NullableName False = new NullableName(false);

        public bool IsNullable { get; }

        private NullableName(bool isNullable)
        {
            this.IsNullable = isNullable;
        }

        public override string ToString()
        {
            return IsNullable ? "?" : "";
        }

    }

}
