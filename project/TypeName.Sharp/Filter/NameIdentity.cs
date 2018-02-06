using System;

namespace TypeName.Filter
{
    internal struct NameIdentity : IEquatable<NameIdentity>
    {
        public readonly string Name;
        public readonly int Generic;

        public NameIdentity(string name, int generic)
        {
            Name = name;
            Generic = generic;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ Generic;
            }
        }

        public bool Equals(NameIdentity other)
        {
            return string.Equals(Name, other.Name) && Generic == other.Generic;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is NameIdentity && Equals((NameIdentity) obj);
        }
    }
}