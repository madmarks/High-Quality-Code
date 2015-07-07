namespace Kitchen
{
    /// <summary>
    /// Represents a vegetable.
    /// </summary>
    internal abstract class Vegetable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="Kitchen.Vegetable"/> is rotten.
        /// </summary>
        public bool IsRotten { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="Kitchen.Vegetable"/> is peeled.
        /// </summary>
        public bool IsPeeled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="Kitchen.Vegetable"/> is cut.
        /// </summary>
        public bool IsCut { get; set; }

        /// <summary>
        /// Returns this type's name.
        /// </summary>
        /// <returns>The name of the type converted to lowercase.</returns>
        public override string ToString()
        {
            return this.GetType().Name.ToLower();
        }
    }
}
