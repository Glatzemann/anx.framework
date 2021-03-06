#region Using Statements
using System;
using System.IO;
using ANX.Framework.NonXNA;
using NUnit.Framework;
#endregion // Using Statements

using XNACurve = Microsoft.Xna.Framework.Curve;
using ANXCurve = ANX.Framework.Curve;

using XNACurveKey = Microsoft.Xna.Framework.CurveKey;
using ANXCurveKey = ANX.Framework.CurveKey;

using XNACurveLoopType = Microsoft.Xna.Framework.CurveLoopType;
using ANXCurveLoopType = ANX.Framework.CurveLoopType;

using XNACurveKeyCollection = Microsoft.Xna.Framework.CurveKeyCollection;
using ANXCurveKeyCollection = ANX.Framework.CurveKeyCollection;

using XNACurveTangent = Microsoft.Xna.Framework.CurveTangent;
using ANXCurveTangent = ANX.Framework.CurveTangent;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.TestCenter.Strukturen
{
    [TestFixture]
    public class CurveKeyCollectionTest
    {
        #region Testdata
        static object[] sixteenfloats =
        {
            new object[] {  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
            new object[] {  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
            new object[] {  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
            new object[] {  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
            new object[] {  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
 			new object[] {1f,  2f, 3f,  4f,5f,  6f,   3f,  8f,  9f,  10f,  11f,  12f,  13f,  14f,  15f,  16f,},
       };
        static object[] sixteenfloats2 =
        {
 			new object[] {1f,  1f, 3f,  4f,  5f,  6f, 7f,  8f,  9f,  10f,  11f,  12f,  13f,  14f,  15f,  16f,},
 			new object[] {2f,  1f, 3f,  4f,  5f,  6f, 7f,  8f,  9f,  10f,  11f,  12f,  13f,  14f,  15f,  16f,},
 			new object[] {1f,  2f, 3f,  4f,  5f,  6f, 7f,  8f,  9f,  10f,  11f,  12f,  13f,  14f,  15f,  16f,},
       };

        #endregion

        [TestCaseSource("sixteenfloats")]
        public void add(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a1, a2));
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a1, a2));
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));

            AssertHelper.ConvertEquals(xna, anx, "add");
        }
 
        [Test]
        public void adde()
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();

            AssertHelper.ConvertEquals(Assert.Throws<ArgumentNullException>(() => xna.Add(null)),
                Assert.Throws<ArgumentNullException>(() => anx.Add(null)), "adde");
        }
        
        //[TestCaseSource("sixteenfloats")]
        //public void add2(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10, float a11, float a12, float a13, float a14, float a15, float a16)
        //{
        //    XNACurveKeyCollection xna = new XNACurveKeyCollection();
        //    xna.Add(new XNACurveKey(a1, a2));
        //    xna.Add(new XNACurveKey(a3, a4));
        //    xna.Add(new XNACurveKey(a5, a6));
        //    xna.Add(new XNACurveKey(a7, a8));
        //    xna.Add(new XNACurveKey(a9, a10));
        //    xna.Add(new XNACurveKey(a11, a12));
        //    xna.Add(new XNACurveKey(a13, a14));
        //    xna.Add(new XNACurveKey(a15, a16));
        //    XNACurveKeyCollection xna2 = new XNACurveKeyCollection();
        //    xna2.Add(new XNACurveKey(a5, a6));
        //    xna2.Add(new XNACurveKey(a7, a8));
        //    xna2.Add(new XNACurveKey(a9, a10));
        //    xna2.Add(new XNACurveKey(a11, a12));
        //    xna2.Add(new XNACurveKey(a13, a14));
        //    xna2.Add(new XNACurveKey(a15, a16));
        //    xna2.Add(new XNACurveKey(a1, a2));
        //    xna2.Add(new XNACurveKey(a3, a4));

        //    ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
        //    anx.Add(new ANXCurveKey(a1, a2));
        //    anx.Add(new ANXCurveKey(a3, a4));
        //    anx.Add(new ANXCurveKey(a5, a6));
        //    anx.Add(new ANXCurveKey(a7, a8));
        //    anx.Add(new ANXCurveKey(a9, a10));
        //    anx.Add(new ANXCurveKey(a11, a12));
        //    anx.Add(new ANXCurveKey(a13, a14));
        //    anx.Add(new ANXCurveKey(a15, a16));
        //    ANXCurveKeyCollection anx2 = new ANXCurveKeyCollection();
        //    anx2.Add(new ANXCurveKey(a5, a6));
        //    anx2.Add(new ANXCurveKey(a7, a8));
        //    anx2.Add(new ANXCurveKey(a9, a10));
        //    anx2.Add(new ANXCurveKey(a11, a12));
        //    anx2.Add(new ANXCurveKey(a13, a14));
        //    anx2.Add(new ANXCurveKey(a15, a16));
        //    anx2.Add(new ANXCurveKey(a1, a2));
        //    anx2.Add(new ANXCurveKey(a3, a4));

        //    for (int i = 0; i < xna.Count; i++)
        //    {
        //        if (!(xna[i]==xna2[i]))
        //        {
        //            Assert.Fail();
        //        }
        //    }

        //    AssertHelper.ConvertEquals(xna, anx, "add2");
        //}

        [Test]
        public void Constructor()
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();

            AssertHelper.ConvertEquals(xna, anx, "Constructor");
        }

        [TestCaseSource("sixteenfloats")]
        public void Clear(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a1, a2));
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));
            xna.Clear();

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a1, a2));
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));
            anx.Clear();

            AssertHelper.ConvertEquals(xna, anx, "Clear");
        }

        [TestCaseSource("sixteenfloats")]
        public void Clone(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a1, a2));
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));
            XNACurveKeyCollection xna2 = xna.Clone();

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a1, a2));
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));
            ANXCurveKeyCollection anx2 = anx.Clone();

            for (int index = 0; index < xna.Count; index++)
            {
                if (xna[index] != xna2[index])
                {
                    Assert.Fail();
                }
            }

            AssertHelper.ConvertEquals(xna, anx2, "Clone");
        }

        [TestCaseSource("sixteenfloats")]
        public void Contains(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9,
            float a10, float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a1, a2));
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a1, a2));
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));

            AssertHelper.ConvertEquals(xna.Contains(new XNACurveKey(a1, a2)), anx.Contains(new ANXCurveKey(a1, a2)),
                "Contains");
        }

        [TestCaseSource("sixteenfloats")]
        public void CopyTo(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a1, a2));
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));
            XNACurveKey[] xnaa = new XNACurveKey[xna.Count];
            xna.CopyTo(xnaa, 0);

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a1, a2));
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));
            ANXCurveKey[] anxa = new ANXCurveKey[anx.Count];
            anx.CopyTo(anxa, 0);

            AssertHelper.ConvertEquals(xnaa, anxa, "CopyTo");
        }

        [Test]
        public void IsReadOnly()
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();

            AssertHelper.ConvertEquals(xna.IsReadOnly, anx.IsReadOnly, "IsReadOnly");
        }

        [TestCaseSource("sixteenfloats")]
        public void Remove(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9, float a10,
            float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a1, a2));
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a1, a2));
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));

            AssertHelper.ConvertEquals(xna.Remove(new XNACurveKey(a1, a2)), anx.Remove(new ANXCurveKey(a1, a2)), "Remove");
        }

        [TestCaseSource("sixteenfloats")]
        public void RemoveAt(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9,
            float a10, float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a1, a2));
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));
            xna.RemoveAt(0);

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a1, a2));
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));
            anx.RemoveAt(0);

            AssertHelper.ConvertEquals(xna, anx, "RemoveAt");
        }

        [TestCaseSource("sixteenfloats")]
        public void IndexOf(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9,
            float a10, float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));
            xna[0] = new XNACurveKey(a1, a2);

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));
            anx[0] = new ANXCurveKey(a1, a2);

            AssertHelper.ConvertEquals(xna.IndexOf(new XNACurveKey(a1, a2)), anx.IndexOf(new ANXCurveKey(a1, a2)), "IndexOf");
        }

        [TestCaseSource("sixteenfloats")]
        public void GetEnumerator(float a1, float a2, float a3, float a4, float a5, float a6, float a7, float a8, float a9,
            float a10, float a11, float a12, float a13, float a14, float a15, float a16)
        {
            XNACurveKeyCollection xna = new XNACurveKeyCollection();
            xna.Add(new XNACurveKey(a3, a4));
            xna.Add(new XNACurveKey(a5, a6));
            xna.Add(new XNACurveKey(a7, a8));
            xna.Add(new XNACurveKey(a9, a10));
            xna.Add(new XNACurveKey(a11, a12));
            xna.Add(new XNACurveKey(a13, a14));
            xna.Add(new XNACurveKey(a15, a16));
            xna[0] = new XNACurveKey(a1, a2);

            ANXCurveKeyCollection anx = new ANXCurveKeyCollection();
            anx.Add(new ANXCurveKey(a3, a4));
            anx.Add(new ANXCurveKey(a5, a6));
            anx.Add(new ANXCurveKey(a7, a8));
            anx.Add(new ANXCurveKey(a9, a10));
            anx.Add(new ANXCurveKey(a11, a12));
            anx.Add(new ANXCurveKey(a13, a14));
            anx.Add(new ANXCurveKey(a15, a16));
            anx[0] = new ANXCurveKey(a1, a2);
            
            AssertHelper.ConvertEquals(xna, anx, "GetEnumerator");
        }
    }
}
