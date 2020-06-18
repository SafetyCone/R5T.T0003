using System;


namespace R5T.T0003
{
    public static class SettableExtensions
    {
        public static void CloneFrom<T>(this Settable<T> settable, Settable<T> other)
        {
            if(other.IsSet)
            {
                settable.Value = other.Value;
            }
            else
            {
                settable.Unset();
            }
        }
    }
}
