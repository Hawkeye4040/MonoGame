﻿// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace Microsoft.Xna.Framework.Graphics.PackedVector
{
    public struct HalfVector2 : IPackedVector<uint>, IPackedVector, IEquatable<HalfVector2>
    {
        private uint packedValue;
        public HalfVector2(float x, float y)
        {
            packedValue = PackHelper(x, y);
        }

        public HalfVector2(Vector2 vector)
        {
            packedValue = PackHelper(vector.X, vector.Y);
        }

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            packedValue = PackHelper(vector.X, vector.Y);
        }

        private static uint PackHelper(float vectorX, float vectorY)
        {
            uint num2 = HalfTypeHelper.Convert(vectorX);
            uint num = (uint)(HalfTypeHelper.Convert(vectorY) << 0x10);
            return (num2 | num);
        }

        public Vector2 ToVector2()
        {
            Vector2 vector;
            vector.X = HalfTypeHelper.Convert((ushort)packedValue);
            vector.Y = HalfTypeHelper.Convert((ushort)(packedValue >> 0x10));
            return vector;
        }

        /// <summary>
        /// Gets the packed vector in Vector4 format.
        /// </summary>
        /// <returns>The packed vector in Vector4 format</returns>
        public Vector4 ToVector4()
        {
            Vector2 vector = ToVector2();
            return new Vector4(vector.X, vector.Y, 0f, 1f);
        }

        [CLSCompliant(false)]
        public uint PackedValue
        {
            get => packedValue;
            set => packedValue = value;
        }
        public override string ToString()
        {
            return ToVector2().ToString();
        }

        public override int GetHashCode()
        {
            return packedValue.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ((obj is HalfVector2) && Equals((HalfVector2)obj));
        }

        public bool Equals(HalfVector2 other)
        {
            return packedValue.Equals(other.packedValue);
        }

        public static bool operator ==(HalfVector2 a, HalfVector2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(HalfVector2 a, HalfVector2 b)
        {
            return !a.Equals(b);
        }
    }
}
