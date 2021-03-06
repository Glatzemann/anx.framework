#region Using Statements
using System;
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
	class CurveTest
    {
        #region TestCase
	    private static object[] inoutsame =
	    {
	        new object[]
	        {
	            XNACurveTangent.Flat, ANXCurveTangent.Flat,
	            1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Linear, ANXCurveTangent.Linear,
	            1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Smooth, ANXCurveTangent.Smooth,
	            1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        }
	    };

	    private static object[] inoutsameErr =
	    {
	        new object[]
	        {
	            XNACurveTangent.Linear, ANXCurveTangent.Linear,
	            1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveTangent.Smooth, ANXCurveTangent.Smooth,
	            1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 10
	        }
	    };

	    private static object[] inoutnotsame =
	    {
	        new object[]
	        {
	            XNACurveTangent.Flat, ANXCurveTangent.Flat, XNACurveTangent.Flat, ANXCurveTangent.Flat,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Flat, ANXCurveTangent.Flat, XNACurveTangent.Linear, ANXCurveTangent.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Flat, ANXCurveTangent.Flat, XNACurveTangent.Smooth, ANXCurveTangent.Smooth,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Linear, ANXCurveTangent.Linear, XNACurveTangent.Flat, ANXCurveTangent.Flat,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Linear, ANXCurveTangent.Linear, XNACurveTangent.Linear, ANXCurveTangent.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Linear, ANXCurveTangent.Linear, XNACurveTangent.Smooth, ANXCurveTangent.Smooth,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Smooth, ANXCurveTangent.Smooth, XNACurveTangent.Flat, ANXCurveTangent.Flat,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Smooth, ANXCurveTangent.Smooth, XNACurveTangent.Linear, ANXCurveTangent.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        },
	        new object[]
	        {
	            XNACurveTangent.Smooth, ANXCurveTangent.Smooth, XNACurveTangent.Smooth, ANXCurveTangent.Smooth,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f
	        }
	    };

	    private static object[] Evaluatesamples =
	    {
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Constant, XNACurveLoopType.Constant, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Cycle, XNACurveLoopType.Constant, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Constant,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Linear, XNACurveLoopType.Constant, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Oscillate, XNACurveLoopType.Constant,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Constant, XNACurveLoopType.Cycle, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Cycle, XNACurveLoopType.Cycle, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Cycle, ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Linear, XNACurveLoopType.Cycle, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Oscillate, XNACurveLoopType.Cycle, ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Constant, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Cycle, XNACurveLoopType.CycleOffset, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.CycleOffset, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Linear, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Oscillate, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Constant, XNACurveLoopType.Linear, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Cycle, XNACurveLoopType.Linear, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Linear,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Linear, XNACurveLoopType.Linear, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Oscillate, XNACurveLoopType.Linear, ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Constant, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Cycle, XNACurveLoopType.Oscillate, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Linear, XNACurveLoopType.Oscillate, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Oscillate, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, -1
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Constant, XNACurveLoopType.Constant, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Cycle, XNACurveLoopType.Constant, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Constant,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Linear, XNACurveLoopType.Constant, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Oscillate, XNACurveLoopType.Constant,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Constant, XNACurveLoopType.Cycle, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Cycle, XNACurveLoopType.Cycle, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Cycle, ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Linear, XNACurveLoopType.Cycle, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Oscillate, XNACurveLoopType.Cycle, ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Constant, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Cycle, XNACurveLoopType.CycleOffset, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.CycleOffset, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Linear, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Oscillate, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Constant, XNACurveLoopType.Linear, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Cycle, XNACurveLoopType.Linear, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Linear,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Linear, XNACurveLoopType.Linear, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Oscillate, XNACurveLoopType.Linear, ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Constant, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Cycle, XNACurveLoopType.Oscillate, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Linear, XNACurveLoopType.Oscillate, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Oscillate, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f, 20
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Constant, XNACurveLoopType.Constant, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Cycle, XNACurveLoopType.Constant, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Constant,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Linear, XNACurveLoopType.Constant, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Constant, ANXCurveLoopType.Oscillate, XNACurveLoopType.Constant,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Constant, XNACurveLoopType.Cycle, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Cycle, XNACurveLoopType.Cycle, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Cycle, ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Linear, XNACurveLoopType.Cycle, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Cycle, ANXCurveLoopType.Oscillate, XNACurveLoopType.Cycle, ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Constant, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Cycle, XNACurveLoopType.CycleOffset, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.CycleOffset, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Linear, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.CycleOffset, ANXCurveLoopType.Oscillate, XNACurveLoopType.CycleOffset,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Constant, XNACurveLoopType.Linear, ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Cycle, XNACurveLoopType.Linear, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Linear,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Linear, XNACurveLoopType.Linear, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Linear, ANXCurveLoopType.Oscillate, XNACurveLoopType.Linear, ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Constant, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.Constant,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Cycle, XNACurveLoopType.Oscillate, ANXCurveLoopType.Cycle,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.CycleOffset, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.CycleOffset,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Linear, XNACurveLoopType.Oscillate, ANXCurveLoopType.Linear,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	        new object[]
	        {
	            XNACurveLoopType.Oscillate, ANXCurveLoopType.Oscillate, XNACurveLoopType.Oscillate,
                ANXCurveLoopType.Oscillate,
                1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f, 16f,
                DataFactory.RandomValueMinMax(float.Epsilon, 1000)
	        },
	    };
        #endregion

        [TestCaseSource("inoutsame")]
		public void Curve(XNACurveTangent xnainout, ANXCurveTangent anxinout, float f1, float f2, float f3, float f4,
            float f5, float f6, float f7, float f8, float f9, float f10, float f11, float f12, float f13, float f14,
            float f15, float f16)
		{
			XNACurve xna = new XNACurve();
			ANXCurve anx = new ANXCurve();

			xna.Keys.Add(new XNACurveKey(f1, f2));
            xna.Keys.Add(new XNACurveKey(f3, f4));
            xna.Keys.Add(new XNACurveKey(f5, f6));
            xna.Keys.Add(new XNACurveKey(f7, f8));
            xna.Keys.Add(new XNACurveKey(f9, f10));
            xna.Keys.Add(new XNACurveKey(f11, f12));
            xna.Keys.Add(new XNACurveKey(f13, f14));
            xna.Keys.Add(new XNACurveKey(f15, f16));

			anx.Keys.Add(new ANXCurveKey(f1, f2));
            anx.Keys.Add(new ANXCurveKey(f3, f4));
            anx.Keys.Add(new ANXCurveKey(f5, f6));
            anx.Keys.Add(new ANXCurveKey(f7, f8));
            anx.Keys.Add(new ANXCurveKey(f9, f10));
            anx.Keys.Add(new ANXCurveKey(f11, f12));
            anx.Keys.Add(new ANXCurveKey(f13, f14));
            anx.Keys.Add(new ANXCurveKey(f15, f16));

			AssertHelper.ConvertEquals(xna, anx, "Curve");
		}

		[TestCaseSource("inoutsame")]
		public void Clone(XNACurveTangent xnainout, ANXCurveTangent anxinout, float f1, float f2, float f3, float f4,
            float f5, float f6, float f7, float f8, float f9, float f10, float f11, float f12, float f13, float f14,
            float f15, float f16)
		{
			XNACurve xna = new XNACurve();
			ANXCurve anx = new ANXCurve();

			xna.Keys.Add(new XNACurveKey(f1, f2));
			xna.Keys.Add(new XNACurveKey(f3, f4));
			xna.Keys.Add(new XNACurveKey(f5, f6));
			xna.Keys.Add(new XNACurveKey(f7, f8));
			xna.Keys.Add(new XNACurveKey(f9, f10));
			xna.Keys.Add(new XNACurveKey(f11, f12));
			xna.Keys.Add(new XNACurveKey(f13, f14));
			xna.Keys.Add(new XNACurveKey(f15, f16));

			anx.Keys.Add(new ANXCurveKey(f1, f2));
			anx.Keys.Add(new ANXCurveKey(f3, f4));
			anx.Keys.Add(new ANXCurveKey(f5, f6));
			anx.Keys.Add(new ANXCurveKey(f7, f8));
			anx.Keys.Add(new ANXCurveKey(f9, f10));
			anx.Keys.Add(new ANXCurveKey(f11, f12));
			anx.Keys.Add(new ANXCurveKey(f13, f14));
			anx.Keys.Add(new ANXCurveKey(f15, f16));

			XNACurve xna2 = xna.Clone();
			ANXCurve anx2 = anx.Clone();

			AssertHelper.ConvertEquals(xna, xna2, anx, anx2, "Clone");
		}

		[TestCaseSource("inoutsame")]
		public void ComputeTangents(XNACurveTangent xnainout, ANXCurveTangent anxinout, float f1, float f2, float f3, float f4,
            float f5, float f6, float f7, float f8, float f9, float f10, float f11, float f12, float f13, float f14, float f15,
            float f16)
		{
			XNACurve xna = new XNACurve();
			ANXCurve anx = new ANXCurve();

			xna.Keys.Add(new XNACurveKey(f1, f2));
			xna.Keys.Add(new XNACurveKey(f3, f4));
			xna.Keys.Add(new XNACurveKey(f5, f6));
			xna.Keys.Add(new XNACurveKey(f7, f8));
			xna.Keys.Add(new XNACurveKey(f9, f10));
			xna.Keys.Add(new XNACurveKey(f11, f12));
			xna.Keys.Add(new XNACurveKey(f13, f14));
			xna.Keys.Add(new XNACurveKey(f15, f16));

			anx.Keys.Add(new ANXCurveKey(f1, f2));
			anx.Keys.Add(new ANXCurveKey(f3, f4));
			anx.Keys.Add(new ANXCurveKey(f5, f6));
			anx.Keys.Add(new ANXCurveKey(f7, f8));
			anx.Keys.Add(new ANXCurveKey(f9, f10));
			anx.Keys.Add(new ANXCurveKey(f11, f12));
			anx.Keys.Add(new ANXCurveKey(f13, f14));
			anx.Keys.Add(new ANXCurveKey(f15, f16));

			xna.ComputeTangents(xnainout);
			anx.ComputeTangents(anxinout);

			AssertHelper.ConvertEquals(xna, anx, "ComputeTangents");
		}
 
 		[TestCaseSource("inoutsameErr")]
		public void ComputeTangent(XNACurveTangent xnainout, ANXCurveTangent anxinout, float f1, float f2, float f3, float f4,
            float f5, float f6, float f7, float f8, float f9, float f10, float f11, float f12, float f13, float f14, float f15,
            float f16,int pos)
		{
			XNACurve xna = new XNACurve();
			ANXCurve anx = new ANXCurve();

			xna.Keys.Add(new XNACurveKey(f1, f2));
			xna.Keys.Add(new XNACurveKey(f3, f4));
			xna.Keys.Add(new XNACurveKey(f5, f6));
			xna.Keys.Add(new XNACurveKey(f7, f8));
			xna.Keys.Add(new XNACurveKey(f9, f10));
			xna.Keys.Add(new XNACurveKey(f11, f12));
			xna.Keys.Add(new XNACurveKey(f13, f14));
			xna.Keys.Add(new XNACurveKey(f15, f16));

			anx.Keys.Add(new ANXCurveKey(f1, f2));
			anx.Keys.Add(new ANXCurveKey(f3, f4));
			anx.Keys.Add(new ANXCurveKey(f5, f6));
			anx.Keys.Add(new ANXCurveKey(f7, f8));
			anx.Keys.Add(new ANXCurveKey(f9, f10));
			anx.Keys.Add(new ANXCurveKey(f11, f12));
			anx.Keys.Add(new ANXCurveKey(f13, f14));
			anx.Keys.Add(new ANXCurveKey(f15, f16));

			xna.ComputeTangents(xnainout);
			anx.ComputeTangents(anxinout);

            TestDelegate xnaDelegate = delegate { xna.ComputeTangent(pos, xnainout); };
            TestDelegate anxDelegate = delegate { anx.ComputeTangent(pos, anxinout); };

            AssertHelper.ConvertEquals(Assert.Throws<ArgumentOutOfRangeException>(xnaDelegate),
                Assert.Throws<ArgumentOutOfRangeException>(anxDelegate), "ComputeTangentE");
        }

        [TestCaseSource("inoutsameErr")]
        public void ComputeTangent2(XNACurveTangent xnainout, ANXCurveTangent anxinout, float f1, float f2, float f3, float f4,
            float f5, float f6, float f7, float f8, float f9, float f10, float f11, float f12, float f13, float f14, float f15,
            float f16, int pos)
        {
            XNACurve xna = new XNACurve();
            ANXCurve anx = new ANXCurve();

            xna.Keys.Add(new XNACurveKey(f1, f2));
            xna.Keys.Add(new XNACurveKey(f3, f4));
            xna.Keys.Add(new XNACurveKey(f5, f6));
            xna.Keys.Add(new XNACurveKey(f7, f8));
            xna.Keys.Add(new XNACurveKey(f9, f10));
            xna.Keys.Add(new XNACurveKey(f11, f12));
            xna.Keys.Add(new XNACurveKey(f13, f14));
            xna.Keys.Add(new XNACurveKey(f15, f16));

            anx.Keys.Add(new ANXCurveKey(f1, f2));
            anx.Keys.Add(new ANXCurveKey(f3, f4));
            anx.Keys.Add(new ANXCurveKey(f5, f6));
            anx.Keys.Add(new ANXCurveKey(f7, f8));
            anx.Keys.Add(new ANXCurveKey(f9, f10));
            anx.Keys.Add(new ANXCurveKey(f11, f12));
            anx.Keys.Add(new ANXCurveKey(f13, f14));
            anx.Keys.Add(new ANXCurveKey(f15, f16));

            xna.ComputeTangents(xnainout);
            anx.ComputeTangents(anxinout);

            TestDelegate xnaDelegate = delegate { xna.ComputeTangent(pos, xnainout, xnainout); };
            TestDelegate anxDelegate = delegate { anx.ComputeTangent(pos, anxinout, anxinout); };

            AssertHelper.ConvertEquals(Assert.Throws<ArgumentOutOfRangeException>(xnaDelegate),
                Assert.Throws<ArgumentOutOfRangeException>(anxDelegate), "ComputeTangentE2");
        }
        
        [TestCaseSource("inoutnotsame")]
        public void ComputeTangents(XNACurveTangent xnain, ANXCurveTangent anxin, XNACurveTangent xnaout,
            ANXCurveTangent anxout, float f1, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9,
            float f10, float f11, float f12, float f13, float f14, float f15, float f16)
        {
            XNACurve xna = new XNACurve();
            ANXCurve anx = new ANXCurve();

            xna.Keys.Add(new XNACurveKey(f1, f2));
            xna.Keys.Add(new XNACurveKey(f3, f4));
            xna.Keys.Add(new XNACurveKey(f5, f6));
            xna.Keys.Add(new XNACurveKey(f7, f8));
            xna.Keys.Add(new XNACurveKey(f9, f10));
            xna.Keys.Add(new XNACurveKey(f11, f12));
            xna.Keys.Add(new XNACurveKey(f13, f14));
            xna.Keys.Add(new XNACurveKey(f15, f16));

            anx.Keys.Add(new ANXCurveKey(f1, f2));
            anx.Keys.Add(new ANXCurveKey(f3, f4));
            anx.Keys.Add(new ANXCurveKey(f5, f6));
            anx.Keys.Add(new ANXCurveKey(f7, f8));
            anx.Keys.Add(new ANXCurveKey(f9, f10));
            anx.Keys.Add(new ANXCurveKey(f11, f12));
            anx.Keys.Add(new ANXCurveKey(f13, f14));
            anx.Keys.Add(new ANXCurveKey(f15, f16));

            xna.ComputeTangents(xnain,xnaout);
            anx.ComputeTangents(anxin,anxout);

            AssertHelper.ConvertEquals(xna, anx, "ComputeTangents2");
        }
 
        [TestCaseSource("Evaluatesamples")]
        public void EvaluateFlat(XNACurveLoopType xnapre, XNACurveLoopType xnapost, ANXCurveLoopType anxpre,
            ANXCurveLoopType anxpost, float f1, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9,
            float f10, float f11, float f12, float f13, float f14, float f15, float f16, float pos)
        {
            XNACurve xna = new XNACurve { PreLoop = xnapre, PostLoop = xnapost };
            ANXCurve anx = new ANXCurve { PreLoop = anxpre, PostLoop = anxpost };

            xna.ComputeTangents(XNACurveTangent.Flat);
            anx.ComputeTangents(ANXCurveTangent.Flat);

            xna.Keys.Add(new XNACurveKey(f1, f2));
            xna.Keys.Add(new XNACurveKey(f3, f4));
            xna.Keys.Add(new XNACurveKey(f5, f6));
            xna.Keys.Add(new XNACurveKey(f7, f8));
            xna.Keys.Add(new XNACurveKey(f9, f10));
            xna.Keys.Add(new XNACurveKey(f11, f12));
            xna.Keys.Add(new XNACurveKey(f13, f14));
            xna.Keys.Add(new XNACurveKey(f15, f16));

            anx.Keys.Add(new ANXCurveKey(f1, f2));
            anx.Keys.Add(new ANXCurveKey(f3, f4));
            anx.Keys.Add(new ANXCurveKey(f5, f6));
            anx.Keys.Add(new ANXCurveKey(f7, f8));
            anx.Keys.Add(new ANXCurveKey(f9, f10));
            anx.Keys.Add(new ANXCurveKey(f11, f12));
            anx.Keys.Add(new ANXCurveKey(f13, f14));
            anx.Keys.Add(new ANXCurveKey(f15, f16));

            AssertHelper.ConvertEquals(xna.Evaluate(pos), anx.Evaluate(pos), "Evaluate");
        }

        [TestCaseSource("Evaluatesamples")]
        public void EvaluateLinear(XNACurveLoopType xnapre, XNACurveLoopType xnapost, ANXCurveLoopType anxpre,
            ANXCurveLoopType anxpost, float f1, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9,
            float f10, float f11, float f12, float f13, float f14, float f15, float f16, float pos)
        {
            XNACurve xna = new XNACurve { PreLoop = xnapre, PostLoop = xnapost };
            ANXCurve anx = new ANXCurve { PreLoop = anxpre, PostLoop = anxpost };

            xna.ComputeTangents(XNACurveTangent.Linear);
            anx.ComputeTangents(ANXCurveTangent.Linear);

            xna.Keys.Add(new XNACurveKey(f1, f2));
            xna.Keys.Add(new XNACurveKey(f3, f4));
            xna.Keys.Add(new XNACurveKey(f5, f6));
            xna.Keys.Add(new XNACurveKey(f7, f8));
            xna.Keys.Add(new XNACurveKey(f9, f10));
            xna.Keys.Add(new XNACurveKey(f11, f12));
            xna.Keys.Add(new XNACurveKey(f13, f14));
            xna.Keys.Add(new XNACurveKey(f15, f16));

            anx.Keys.Add(new ANXCurveKey(f1, f2));
            anx.Keys.Add(new ANXCurveKey(f3, f4));
            anx.Keys.Add(new ANXCurveKey(f5, f6));
            anx.Keys.Add(new ANXCurveKey(f7, f8));
            anx.Keys.Add(new ANXCurveKey(f9, f10));
            anx.Keys.Add(new ANXCurveKey(f11, f12));
            anx.Keys.Add(new ANXCurveKey(f13, f14));
            anx.Keys.Add(new ANXCurveKey(f15, f16));

            AssertHelper.ConvertEquals(xna.Evaluate(pos), anx.Evaluate(pos), "Evaluate");
        }

        [TestCaseSource("Evaluatesamples")]
        public void EvaluateSmooth(XNACurveLoopType xnapre, XNACurveLoopType xnapost, ANXCurveLoopType anxpre,
            ANXCurveLoopType anxpost, float f1, float f2, float f3, float f4, float f5, float f6, float f7, float f8, float f9,
            float f10, float f11, float f12, float f13, float f14, float f15, float f16, float pos)
        {
            XNACurve xna = new XNACurve {PreLoop = xnapre, PostLoop = xnapost};
            ANXCurve anx = new ANXCurve {PreLoop = anxpre, PostLoop = anxpost};

            xna.ComputeTangents(XNACurveTangent.Smooth);
            anx.ComputeTangents(ANXCurveTangent.Smooth);

            xna.Keys.Add(new XNACurveKey(f1, f2));
            xna.Keys.Add(new XNACurveKey(f3, f4));
            xna.Keys.Add(new XNACurveKey(f5, f6));
            xna.Keys.Add(new XNACurveKey(f7, f8));
            xna.Keys.Add(new XNACurveKey(f9, f10));
            xna.Keys.Add(new XNACurveKey(f11, f12));
            xna.Keys.Add(new XNACurveKey(f13, f14));
            xna.Keys.Add(new XNACurveKey(f15, f16));

            anx.Keys.Add(new ANXCurveKey(f1, f2));
            anx.Keys.Add(new ANXCurveKey(f3, f4));
            anx.Keys.Add(new ANXCurveKey(f5, f6));
            anx.Keys.Add(new ANXCurveKey(f7, f8));
            anx.Keys.Add(new ANXCurveKey(f9, f10));
            anx.Keys.Add(new ANXCurveKey(f11, f12));
            anx.Keys.Add(new ANXCurveKey(f13, f14));
            anx.Keys.Add(new ANXCurveKey(f15, f16));

            AssertHelper.ConvertEquals(xna.Evaluate(pos), anx.Evaluate(pos), "Evaluate");
        }
    }
}
#if OLD_TEST_DATA
	    private static object[] inoutsame =
	        {
	            //new object[] {XNACurveTangent.Flat,ANXCurveTangent.Flat    , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
	            //new object[] {XNACurveTangent.Linear,ANXCurveTangent.Linear, DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
	            //new object[] {XNACurveTangent.Smooth,ANXCurveTangent.Smooth, DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
	        };

        static object[] inoutnotsame =
		{
		//	new object[] {XNACurveTangent.Flat,ANXCurveTangent.Flat ,XNACurveTangent.Flat,ANXCurveTangent.Flat       , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
		//	new object[] {XNACurveTangent.Flat,ANXCurveTangent.Flat ,XNACurveTangent.Linear,ANXCurveTangent.Linear   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
		//	new object[] {XNACurveTangent.Flat,ANXCurveTangent.Flat ,XNACurveTangent.Smooth,ANXCurveTangent.Smooth   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000) },
		//	new object[] {XNACurveTangent.Linear,ANXCurveTangent.Linear,XNACurveTangent.Flat,ANXCurveTangent.Flat       , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
		//	new object[] {XNACurveTangent.Linear,ANXCurveTangent.Linear,XNACurveTangent.Linear,ANXCurveTangent.Linear   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
		//	new object[] {XNACurveTangent.Linear,ANXCurveTangent.Linear,XNACurveTangent.Smooth,ANXCurveTangent.Smooth   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
		//	new object[] {XNACurveTangent.Smooth,ANXCurveTangent.Smooth,XNACurveTangent.Flat,ANXCurveTangent.Flat       , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
		//	new object[] {XNACurveTangent.Smooth,ANXCurveTangent.Smooth,XNACurveTangent.Linear,ANXCurveTangent.Linear   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
		//	new object[] {XNACurveTangent.Smooth,ANXCurveTangent.Smooth,XNACurveTangent.Smooth,ANXCurveTangent.Smooth   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
		};

        static object[] Evaluatesamples =
		{
		/*	new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Constant      , XNACurveLoopType.Constant    , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Cycle         , XNACurveLoopType.Constant    , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Constant    , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Linear        , XNACurveLoopType.Constant    , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Constant    , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Constant      , XNACurveLoopType.Cycle       , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Cycle         , XNACurveLoopType.Cycle       , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Cycle       , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Linear        , XNACurveLoopType.Cycle       , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Cycle       , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Constant      , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Cycle         , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.CycleOffset , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Linear        , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Oscillate     , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Constant      , XNACurveLoopType.Linear      , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Cycle         , XNACurveLoopType.Linear      , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Linear      , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Linear        , XNACurveLoopType.Linear      , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Linear      , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Constant      , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Cycle         , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Oscillate   , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Linear        , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),-1 },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Constant      , XNACurveLoopType.Constant    , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Cycle         , XNACurveLoopType.Constant    , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Constant    , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Linear        , XNACurveLoopType.Constant    , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Constant    , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Constant      , XNACurveLoopType.Cycle       , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Cycle         , XNACurveLoopType.Cycle       , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Cycle       , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Linear        , XNACurveLoopType.Cycle       , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Cycle       , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Constant      , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Cycle         , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.CycleOffset , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Linear        , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Oscillate     , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Constant      , XNACurveLoopType.Linear      , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Cycle         , XNACurveLoopType.Linear      , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Linear      , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Linear        , XNACurveLoopType.Linear      , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Linear      , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Constant      , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Cycle         , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Oscillate   , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Linear        , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(1001, 1005) },
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Constant      , XNACurveLoopType.Constant    , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Cycle         , XNACurveLoopType.Constant    , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Constant    , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Linear        , XNACurveLoopType.Constant    , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Constant     , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Constant    , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Constant      , XNACurveLoopType.Cycle       , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Cycle         , XNACurveLoopType.Cycle       , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Cycle       , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Linear        , XNACurveLoopType.Cycle       , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Cycle        , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Cycle       , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Constant      , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Cycle         , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.CycleOffset , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Linear        , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.CycleOffset  , ANXCurveLoopType.Oscillate     , XNACurveLoopType.CycleOffset , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Constant      , XNACurveLoopType.Linear      , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Cycle         , XNACurveLoopType.Linear      , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Linear      , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Linear        , XNACurveLoopType.Linear      , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Linear       , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Linear      , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Constant      , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Constant      , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Cycle         , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Cycle         , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.CycleOffset   , XNACurveLoopType.Oscillate   , ANXCurveLoopType.CycleOffset   , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Linear        , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Linear        , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
			new object[] {XNACurveLoopType.Oscillate    , ANXCurveLoopType.Oscillate     , XNACurveLoopType.Oscillate   , ANXCurveLoopType.Oscillate     , DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000), DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),  DataFactory.RandomValueMinMax(float.Epsilon, 1000),DataFactory.RandomValueMinMax(float.Epsilon, 1000)},
      */
		};
#endif