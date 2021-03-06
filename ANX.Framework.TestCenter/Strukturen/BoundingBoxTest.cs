#region UsingStatements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

using XNABoundingBox = Microsoft.Xna.Framework.BoundingBox;
using XNAVector3 = Microsoft.Xna.Framework.Vector3;
using ANXBoundingBox = ANX.Framework.BoundingBox;
using ANXVector3 = ANX.Framework.Vector3;

using NUnit.Framework;

namespace ANX.Framework.TestCenter.Strukturen
{
    [TestFixture]
    class BoundingBoxTest
    {
        #region Helper
        static object[] sixfloats =
        {
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
        };

        static object[] ninefloats =
        {
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
        };

        static object[] tenfloats =
        {
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
        };

        static object[] twelvefloats =
        {
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
        };

        static object[] twentytwofloats =
        {
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),
                 DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),
                 DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),
                 DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),
                 DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
            new object[] {  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),
                 DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f),  DataFactory.RandomValueMinMax(0f, 100f) },
        };

        private void Swap(ref float a, ref float b)
        {
            float t = a;
            a = b;
            b = t;
        }

        private void Sort(ref float a, ref float b)
        {
            if (a > b)
            {
                Swap(ref a, ref b);
            }
        }

        #endregion

        #region Constructors
        [Test]
        public void constructor0()
        {
            XNABoundingBox xna = new XNABoundingBox();

            ANXBoundingBox anx = new ANXBoundingBox();

            AssertHelper.ConvertEquals(xna, anx, "constructor0");
        }

        [Test, TestCaseSource("sixfloats")]
        public void constructor1(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            if (xMin > xMax)
            {
                float x = xMin;
                xMin = xMax;
                xMax = x;
            }
            if (yMin > yMax)
            {
                float y = yMin;
                yMin = yMax;
                yMax = y;
            }
            if (zMin > zMax)
            {
                float z = zMin;
                zMin = zMax;
                zMax = z;
            }

            XNABoundingBox xna = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));

            ANXBoundingBox anx = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));

            AssertHelper.ConvertEquals(xna, anx, "constructor0");
        }
        #endregion

        #region Methods
        [Test, TestCaseSource("twelvefloats")]
        public void ContainsBoundingBox(
            float xMin1, float yMin1, float zMin1, float xMax1, float yMax1, float zMax1,
            float xMin2, float yMin2, float zMin2, float xMax2, float yMax2, float zMax2)
        {
            Sort(ref xMin1, ref xMax1);
            Sort(ref yMin1, ref yMax1);
            Sort(ref zMin1, ref zMax1);

            Sort(ref xMin2, ref xMax2);
            Sort(ref yMin2, ref yMax2);
            Sort(ref zMin2, ref zMax2);

            XNABoundingBox xnaBox1 = new XNABoundingBox(new XNAVector3(xMin1, yMin1, zMin1), new XNAVector3(xMax1, yMax1, zMax1));
            XNABoundingBox xnaBox2 = new XNABoundingBox(new XNAVector3(xMin2, yMin2, zMin2), new XNAVector3(xMax2, yMax2, zMax2));

            ANXBoundingBox anxBox1 = new ANXBoundingBox(new ANXVector3(xMin1, yMin1, zMin1), new ANXVector3(xMax1, yMax1, zMax1));
            ANXBoundingBox anxBox2 = new ANXBoundingBox(new ANXVector3(xMin2, yMin2, zMin2), new ANXVector3(xMax2, yMax2, zMax2));

            Microsoft.Xna.Framework.ContainmentType containsXNA = xnaBox1.Contains(xnaBox2);
            ANX.Framework.ContainmentType containsANX = anxBox1.Contains(anxBox2);

            if ((int)containsXNA == (int)containsANX)
                Assert.Pass("ContainsBoundingBox passed");
            else
                Assert.Fail(String.Format("ContainsBoundingBox failed: xna({0}) anx({1})", containsXNA.ToString(), containsANX.ToString()));
        }

        [Test, TestCaseSource("twentytwofloats")]
        public void ContainsBoundingFrustum(
            float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44,
            float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));
            Microsoft.Xna.Framework.Matrix xnaMatrix = new Microsoft.Xna.Framework.Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
            Microsoft.Xna.Framework.BoundingFrustum xnaFrustum = new Microsoft.Xna.Framework.BoundingFrustum(xnaMatrix);

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));
            ANX.Framework.Matrix anxMatrix = new ANX.Framework.Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
            ANX.Framework.BoundingFrustum anxFrustum = new ANX.Framework.BoundingFrustum(anxMatrix); 
            
            Microsoft.Xna.Framework.ContainmentType containsXNA = xnaBox.Contains(xnaFrustum);
            ANX.Framework.ContainmentType containsANX = anxBox.Contains(anxFrustum);

            if ((int)containsXNA == (int)containsANX)
                Assert.Pass("ContainsBoundingFrustum passed");
            else
                Assert.Fail(String.Format("ContainsBoundingFrustum failed: xna({0}) anx({1})", containsXNA.ToString(), containsANX.ToString()));
        }

        [Test, TestCaseSource("tenfloats")]
        public void ContainsBoundingSphere(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax, float xS, float yS, float zS, float rS)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));
            Microsoft.Xna.Framework.BoundingSphere xnaSphere = new Microsoft.Xna.Framework.BoundingSphere(new XNAVector3(xS, yS, zS), rS);

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));
            ANX.Framework.BoundingSphere anxSphere = new ANX.Framework.BoundingSphere(new ANXVector3(xS, yS, zS), rS);

            Microsoft.Xna.Framework.ContainmentType containsXNA = xnaBox.Contains(xnaSphere);
            ANX.Framework.ContainmentType containsANX = anxBox.Contains(anxSphere);

            if ((int)containsXNA == (int)containsANX)
                Assert.Pass("ContainsBoundingSphere passed");
            else
                Assert.Fail(String.Format("ContainsBoundingSphere failed: xna({0}) anx({1})", containsXNA.ToString(), containsANX.ToString()));
        }

        [Test, TestCaseSource("ninefloats")]
        public void ContainsPoint(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax, float xP, float yP, float zP)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));
            XNAVector3 xnaPoint = new XNAVector3(xP, yP, zP);

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));
            ANXVector3 anxPoint = new ANXVector3(xP, yP, zP);

            Microsoft.Xna.Framework.ContainmentType containsXNA = xnaBox.Contains(xnaPoint);
            ANX.Framework.ContainmentType containsANX = anxBox.Contains(anxPoint);

            if ((int)containsXNA == (int)containsANX)
                Assert.Pass("ContainsPoint passed");
            else
                Assert.Fail(String.Format("ContainsPoint failed: xna({0}) anx({1})", containsXNA.ToString(), containsANX.ToString()));
        }

        [Test, TestCaseSource("ninefloats")]
        public void CreateFromPointsStatic(
            float x1, float y1, float z1,
            float x2, float y2, float z2,
            float x3, float y3, float z3)
        {
            List<XNAVector3> pointsXNA = new List<XNAVector3>();
            pointsXNA.Add(new XNAVector3(x1, y1, z1));
            pointsXNA.Add(new XNAVector3(x2, y2, z2));
            pointsXNA.Add(new XNAVector3(x3, y3, z3));

            List<ANXVector3> pointsANX = new List<ANXVector3>();
            pointsANX.Add(new ANXVector3(x1, y1, z1));
            pointsANX.Add(new ANXVector3(x2, y2, z2));
            pointsANX.Add(new ANXVector3(x3, y3, z3));

            XNABoundingBox xna = XNABoundingBox.CreateFromPoints(pointsXNA);
            ANXBoundingBox anx = ANXBoundingBox.CreateFromPoints(pointsANX);

            AssertHelper.ConvertEquals(xna, anx, "CreateFromPointsStatic");
        }

        [Test, TestCaseSource("ninefloats")]
        public void CreateFromSphereStatic(
            float x, float y, float z, float radius,
            float a, float b, float c, float d, float e)
        {
            Microsoft.Xna.Framework.BoundingSphere xnaSphere = new Microsoft.Xna.Framework.BoundingSphere(
                new XNAVector3(x, y, z), radius);

            ANX.Framework.BoundingSphere anxSphere = new ANX.Framework.BoundingSphere(
                new ANXVector3(x, y, z), radius);

            XNABoundingBox xna = XNABoundingBox.CreateFromSphere(xnaSphere);
            ANXBoundingBox anx = ANXBoundingBox.CreateFromSphere(anxSphere);

            AssertHelper.ConvertEquals(xna, anx, "CreateFromSphereStatic");
        }

        [Test, TestCaseSource("twelvefloats")]
        public void CreateMergedStatic(
            float xMin1, float yMin1, float zMin1, float xMax1, float yMax1, float zMax1,
            float xMin2, float yMin2, float zMin2, float xMax2, float yMax2, float zMax2)
        {
            Sort(ref xMin1, ref xMax1);
            Sort(ref yMin1, ref yMax1);
            Sort(ref zMin1, ref zMax1);

            Sort(ref xMin2, ref xMax2);
            Sort(ref yMin2, ref yMax2);
            Sort(ref zMin2, ref zMax2);

            XNABoundingBox xnaBox1 = new XNABoundingBox(new XNAVector3(xMin1, yMin1, zMin1), new XNAVector3(xMax1, yMax1, zMax1));
            XNABoundingBox xnaBox2 = new XNABoundingBox(new XNAVector3(xMin2, yMin2, zMin2), new XNAVector3(xMax2, yMax2, zMax2));

            ANXBoundingBox anxBox1 = new ANXBoundingBox(new ANXVector3(xMin1, yMin1, zMin1), new ANXVector3(xMax1, yMax1, zMax1));
            ANXBoundingBox anxBox2 = new ANXBoundingBox(new ANXVector3(xMin2, yMin2, zMin2), new ANXVector3(xMax2, yMax2, zMax2));

            XNABoundingBox xna = XNABoundingBox.CreateMerged(xnaBox1, xnaBox2);
            ANXBoundingBox anx = ANXBoundingBox.CreateMerged(anxBox1, anxBox2);

            AssertHelper.ConvertEquals(xna, anx, "CreateMergedStatic");
        }

        [Test, TestCaseSource("sixfloats")]
        public void GetCorners(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));

            XNAVector3[] xna = xnaBox.GetCorners();
            ANXVector3[] anx = anxBox.GetCorners();

            AssertHelper.ConvertEquals(xna, anx, "GetCorners");
        }

        [Test, TestCaseSource("twelvefloats")]
        public void IntersectsBoundingBox(
            float xMin1, float yMin1, float zMin1, float xMax1, float yMax1, float zMax1,
            float xMin2, float yMin2, float zMin2, float xMax2, float yMax2, float zMax2)
        {
            Sort(ref xMin1, ref xMax1);
            Sort(ref yMin1, ref yMax1);
            Sort(ref zMin1, ref zMax1);

            Sort(ref xMin2, ref xMax2);
            Sort(ref yMin2, ref yMax2);
            Sort(ref zMin2, ref zMax2);

            XNABoundingBox xnaBox1 = new XNABoundingBox(new XNAVector3(xMin1, yMin1, zMin1), new XNAVector3(xMax1, yMax1, zMax1));
            XNABoundingBox xnaBox2 = new XNABoundingBox(new XNAVector3(xMin2, yMin2, zMin2), new XNAVector3(xMax2, yMax2, zMax2));

            ANXBoundingBox anxBox1 = new ANXBoundingBox(new ANXVector3(xMin1, yMin1, zMin1), new ANXVector3(xMax1, yMax1, zMax1));
            ANXBoundingBox anxBox2 = new ANXBoundingBox(new ANXVector3(xMin2, yMin2, zMin2), new ANXVector3(xMax2, yMax2, zMax2));

            bool xna = xnaBox1.Intersects(xnaBox2);
            bool anx = anxBox1.Intersects(anxBox2);

            AssertHelper.ConvertEquals(xna, anx, "IntersectsBoundingBox");
        }

        [Test, TestCaseSource("twentytwofloats")]
        public void IntersectsFrustum(
            float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44,
            float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));
            Microsoft.Xna.Framework.Matrix xnaMtrix = new Microsoft.Xna.Framework.Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
            Microsoft.Xna.Framework.BoundingFrustum xnaFrustum = new Microsoft.Xna.Framework.BoundingFrustum(xnaMtrix);

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));
            ANX.Framework.Matrix anxMatrix = new ANX.Framework.Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
            ANX.Framework.BoundingFrustum anxFrustum = new ANX.Framework.BoundingFrustum(anxMatrix);

            bool xna = xnaBox.Intersects(xnaFrustum);
            bool anx = anxBox.Intersects(anxFrustum);

            AssertHelper.ConvertEquals(xna, anx, "IntersectsFrustum");
        }

        [Test, TestCaseSource("tenfloats")]
        public void IntersectsBoundingSphere(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax, float xS, float yS, float zS, float rS)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));
            Microsoft.Xna.Framework.BoundingSphere xnaSphere = new Microsoft.Xna.Framework.BoundingSphere(new XNAVector3(xS, yS, zS), rS);

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));
            ANX.Framework.BoundingSphere anxSphere = new ANX.Framework.BoundingSphere(new ANXVector3(xS, yS, zS), rS);

            bool xna = xnaBox.Intersects(xnaSphere);
            bool anx = anxBox.Intersects(anxSphere);

            AssertHelper.ConvertEquals(xna, anx, "IntersectsBoundingSphere");
        }

        [Test, TestCaseSource("tenfloats")]
        public void IntersectsPlane(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax, float xP, float yP, float zP, float dP)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));
            Microsoft.Xna.Framework.Plane xnaPlane = new Microsoft.Xna.Framework.Plane(xP, yP, zP, dP);

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));
            ANX.Framework.Plane anxPlane = new ANX.Framework.Plane(xP, yP, zP, dP);

            Microsoft.Xna.Framework.PlaneIntersectionType xna = xnaBox.Intersects(xnaPlane);
            ANX.Framework.PlaneIntersectionType anx = anxBox.Intersects(anxPlane);

            if ((int)xna == (int)anx)
                Assert.Pass("IntersectsPlane passed");
            else
                Assert.Fail(String.Format("IntersectsPlane failed: xna({0}) anx({1})", xna.ToString(), anx.ToString()));
        }

        [Test, TestCaseSource("twelvefloats")]
        public void IntersectsRay(
            float xMin, float yMin, float zMin, float xMax, float yMax, float zMax,
            float xRay, float yRay, float zRay, float xDir, float yDir, float zDir)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));
            Microsoft.Xna.Framework.Ray xnaRay = new Microsoft.Xna.Framework.Ray(new XNAVector3(xRay, yRay, zRay), new XNAVector3(xDir, yDir, zDir));

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));
            ANX.Framework.Ray anxRay = new ANX.Framework.Ray(new ANXVector3(xRay, yRay, zRay), new ANXVector3(xDir, yDir, zDir));

            float? xna = xnaBox.Intersects(xnaRay);
            float? anx = anxBox.Intersects(anxRay);

            AssertHelper.ConvertEquals(xna, anx, "IntersectsRay");
        }
        #endregion

        #region Properties
        [Test, TestCaseSource("sixfloats")]
        public void Min(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));

            AssertHelper.ConvertEquals(xnaBox.Min, anxBox.Min, "Min");
        }

        [Test, TestCaseSource("sixfloats")]
        public void Max(float xMin, float yMin, float zMin, float xMax, float yMax, float zMax)
        {
            Sort(ref xMin, ref xMax);
            Sort(ref yMin, ref yMax);
            Sort(ref zMin, ref zMax);

            XNABoundingBox xnaBox = new XNABoundingBox(new XNAVector3(xMin, yMin, zMin), new XNAVector3(xMax, yMax, zMax));

            ANXBoundingBox anxBox = new ANXBoundingBox(new ANXVector3(xMin, yMin, zMin), new ANXVector3(xMax, yMax, zMax));

            AssertHelper.ConvertEquals(xnaBox.Max, anxBox.Max, "Max");
        }
        #endregion

        #region Operators
        [Test, TestCaseSource("twelvefloats")]
        public void EqualsOperator(
            float xMin1, float yMin1, float zMin1, float xMax1, float yMax1, float zMax1,
            float xMin2, float yMin2, float zMin2, float xMax2, float yMax2, float zMax2)
        {
            Sort(ref xMin1, ref xMax1);
            Sort(ref yMin1, ref yMax1);
            Sort(ref zMin1, ref zMax1);

            Sort(ref xMin2, ref xMax2);
            Sort(ref yMin2, ref yMax2);
            Sort(ref zMin2, ref zMax2);

            XNABoundingBox xnaBox1 = new XNABoundingBox(new XNAVector3(xMin1, yMin1, zMin1), new XNAVector3(xMax1, yMax1, zMax1));
            XNABoundingBox xnaBox2 = new XNABoundingBox(new XNAVector3(xMin2, yMin2, zMin2), new XNAVector3(xMax2, yMax2, zMax2));

            ANXBoundingBox anxBox1 = new ANXBoundingBox(new ANXVector3(xMin1, yMin1, zMin1), new ANXVector3(xMax1, yMax1, zMax1));
            ANXBoundingBox anxBox2 = new ANXBoundingBox(new ANXVector3(xMin2, yMin2, zMin2), new ANXVector3(xMax2, yMax2, zMax2));

            AssertHelper.ConvertEquals(xnaBox1 == xnaBox2, anxBox1 == anxBox2, "EqualsOperator");
        }

        [Test, TestCaseSource("twelvefloats")]
        public void UnequalsOperator(
            float xMin1, float yMin1, float zMin1, float xMax1, float yMax1, float zMax1,
            float xMin2, float yMin2, float zMin2, float xMax2, float yMax2, float zMax2)
        {
            Sort(ref xMin1, ref xMax1);
            Sort(ref yMin1, ref yMax1);
            Sort(ref zMin1, ref zMax1);

            Sort(ref xMin2, ref xMax2);
            Sort(ref yMin2, ref yMax2);
            Sort(ref zMin2, ref zMax2);

            XNABoundingBox xnaBox1 = new XNABoundingBox(new XNAVector3(xMin1, yMin1, zMin1), new XNAVector3(xMax1, yMax1, zMax1));
            XNABoundingBox xnaBox2 = new XNABoundingBox(new XNAVector3(xMin2, yMin2, zMin2), new XNAVector3(xMax2, yMax2, zMax2));

            ANXBoundingBox anxBox1 = new ANXBoundingBox(new ANXVector3(xMin1, yMin1, zMin1), new ANXVector3(xMax1, yMax1, zMax1));
            ANXBoundingBox anxBox2 = new ANXBoundingBox(new ANXVector3(xMin2, yMin2, zMin2), new ANXVector3(xMax2, yMax2, zMax2));

            AssertHelper.ConvertEquals(xnaBox1 != xnaBox2, anxBox1 != anxBox2, "UnequalsOperator");
        }
        #endregion
    }
}
