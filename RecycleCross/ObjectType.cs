namespace RecycleCross
{
    /// <summary>
    /// Possible classifications of a scanned object.
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// Item that goes in the Compost bin.
        /// </summary>
        Compost,

        /// <summary>
        /// Item that goes in the Blue Bin.
        /// </summary>
        Blue,

        /// <summary>
        /// Item that goes in the Grey Bin.
        /// </summary>
        Grey,

        /// <summary>
        /// Item that was not recognised for any bin.
        /// </summary>
        Error,
    }
}