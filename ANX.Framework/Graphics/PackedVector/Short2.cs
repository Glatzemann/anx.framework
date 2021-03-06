#region Using Statements
using System;
using ANX.Framework.NonXNA.Development;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics.PackedVector
{
    [PercentageComplete(100)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.Tested)]
    public struct Short2 : IPackedVector<uint>, IEquatable<Short2>, IPackedVector
    {
        private uint packedValue;

        [CLSCompliant(false)]
        public uint PackedValue
        {
            get { return packedValue; }
            set { packedValue = value; }
        }

        private const float max = 65535 >> 1;
        private const float min = -max - 1f;

        public Short2(float x, float y)
        {
            uint b1 = (uint)(((int)MathHelper.Clamp(x, min, max) & 65535) <<  0);
            uint b2 = (uint)(((int)MathHelper.Clamp(y, min, max) & 65535) << 16);

            this.packedValue = b1 | b2;
        }

        public Short2(Vector2 vector)
        {
            uint b1 = (uint)(((int)MathHelper.Clamp(vector.X, min, max) & 65535) <<  0);
            uint b2 = (uint)(((int)MathHelper.Clamp(vector.Y, min, max) & 65535) << 16);

            this.packedValue = b1 | b2;
        }

        public Vector2 ToVector2()
        {
            Vector2 vector;
            vector.X = (short)this.packedValue;
            vector.Y = (short)(this.packedValue >> 16);
            return vector;
        }

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            uint b1 = (uint)(((int)MathHelper.Clamp(vector.X, min, max) & 65535) <<  0);
            uint b2 = (uint)(((int)MathHelper.Clamp(vector.Y, min, max) & 65535) << 16);

            this.packedValue = b1 | b2;
        }

        Vector4 IPackedVector.ToVector4()
        {
            Vector2 val = this.ToVector2();
            return new Vector4(val.X, val.Y, 0f, 1f);
        }

        public override bool Equals(object obj)
        {
            return obj is Short2 && this == (Short2)obj;
        }

        public bool Equals(Short2 other)
        {
            return this.packedValue == other.packedValue;
        }

        public override string ToString()
        {
            return this.packedValue.ToString("X8");
        }

        public override int GetHashCode()
        {
            return this.packedValue.GetHashCode();
        }

        public static bool operator ==(Short2 lhs, Short2 rhs)
        {
            return lhs.packedValue == rhs.packedValue;
        }

        public static bool operator !=(Short2 lhs, Short2 rhs)
        {
            return lhs.packedValue != rhs.packedValue;
        }
    }
}
