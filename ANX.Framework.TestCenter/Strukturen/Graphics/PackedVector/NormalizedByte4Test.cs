#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using XNANormalizedByte4 = Microsoft.Xna.Framework.Graphics.PackedVector.NormalizedByte4;
using ANXNormalizedByte4 = ANX.Framework.Graphics.PackedVector.NormalizedByte4;

using XNAVector4 = Microsoft.Xna.Framework.Vector4;
using ANXVector4 = ANX.Framework.Vector4;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.TestCenter.Strukturen.Graphics.PackedVector
{
    [TestFixture]
    class NormalizedByte4Test
    {
        #region Testdata

        static object[] fourfloats =
        {
           new object[] { DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue },
           new object[] { DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue },
           new object[] { DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue },
           new object[] { DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue },
           new object[] { DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue, DataFactory.RandomValue },
        };

        #endregion

        [Test, TestCaseSource("fourfloats")]
        public void contructor1(float x, float y, float z, float w)
        {
            XNANormalizedByte4 xnaVal = new XNANormalizedByte4(x, y, z, w);
            ANXNormalizedByte4 anxVal = new ANXNormalizedByte4(x, y, z, w);

            AssertHelper.ConvertEqualsPackedVector(xnaVal, anxVal, "Constructor1");
        }

        [Test, TestCaseSource("fourfloats")]
        public void contructor2(float x, float y, float z, float w)
        {
            XNANormalizedByte4 xnaVal = new XNANormalizedByte4(new XNAVector4(x, y, z, w));
            ANXNormalizedByte4 anxVal = new ANXNormalizedByte4(new ANXVector4(x, y, z, w));

            AssertHelper.ConvertEqualsPackedVector(xnaVal, anxVal, "Constructor2");
        }

        [Test, TestCaseSource("fourfloats")]
        public void unpack1(float x, float y, float z, float w)
        {
            XNANormalizedByte4 xnaVal = new XNANormalizedByte4(x, y, z, w);
            ANXNormalizedByte4 anxVal = new ANXNormalizedByte4(x, y, z, w);

            AssertHelper.ConvertEquals(xnaVal.ToVector4(), anxVal.ToVector4(), "unpack1");
        }
    }
}
