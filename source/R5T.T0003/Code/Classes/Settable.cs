using System;


namespace R5T.T0003
{
    /// <summary>
    /// A class that tracks whether its 
    /// </summary>
    public sealed class Settable<T>
    {
        #region Static

        public static Settable<T> New(T value, bool isSet)
        {
            var output = new Settable<T>
            {
                zValue = value,
                IsSet = isSet
            };

            return output;
        }

        #endregion


        public static implicit operator Settable<T>(T value) => new Settable<T>(value);


        private T zValue;
        public T Value
        {
            get
            {
                return this.zValue;
            }
            set
            {
                this.zValue = value;

                this.IsSet = true;
            }
        }
        public bool IsSet { get; private set; }


        /// <summary>
        /// Constructor with unset value.
        /// </summary>
        public Settable()
        {
            this.zValue = default;
        }

        /// <summary>
        /// Allows setting the value at construction.
        /// </summary>
        public Settable(T value)
        {
            this.Value = value; // Will be set.
        }

        public void Unset()
        {
            this.zValue = default;

            this.IsSet = false;
        }

        public override string ToString()
        {
            var representation = $"{this.Value} ({(this.IsSet ? "set" : "unset")})";
            return representation;
        }
    }
}
