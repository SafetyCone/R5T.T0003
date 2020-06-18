using System;


namespace R5T.T0003
{
    /// <summary>
    /// A class that tracks whether its 
    /// </summary>
    public sealed class Settable<T> : IEquatable<Settable<T>>
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

        public static bool operator ==(Settable<T> a, Settable<T> b)
        {
            if(a is null)
            {
                var output = b is null;
                return output;
            }
            else
            {
                var output = a.Equals(b);
                return output;
            }
        }

        public static bool operator !=(Settable<T> a, Settable<T> b)
        {
            var output = !(a == b);
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

        public bool Equals(Settable<T> other)
        {
            if(other == null) // Skip exact type check since Settable is sealed, so no need to handle descendent types.
            {
                return false;
            }

            var isEqual = this.Equals_Value(other);
            return isEqual;
        }

        private bool Equals_Value(Settable<T> other)
        {
            // First compare whether the settables are both set.
            var isSetIsEqual = this.IsSet == other.IsSet;
            if(!isSetIsEqual)
            {
                return false;
            }

            var isEqual = this.Value.Equals(other.Value);
            return isEqual;
        }

        public override bool Equals(object obj)
        {
            var objAsSettable = obj as Settable<T>;

            var isEqual = this.Equals(objAsSettable);
            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Value.GetHashCode();
            return hashCode;
        }
    }
}
