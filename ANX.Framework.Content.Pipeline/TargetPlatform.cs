﻿#region Using Statements
using System;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline
{
    public enum TargetPlatform : byte
    {
        Windows =       (byte)'w',
        WindowsPhone =  (byte)'m',
        XBox360 =       (byte)'x',

        // ANX-Extensions
        Android =       (byte)'a',
        IOS =           (byte)'i',
        Linux =         (byte)'l',
        MacOs =         (byte)'o',
        PsVita =        (byte)'p',
        WindowsMetro =  (byte)'8',

    }

    public static class TargetPlatformExtension
    {
        public static string ToDisplayName(this TargetPlatform targetPlatform)
        {
            switch (targetPlatform)
            {
                case TargetPlatform.IOS:
                    return "iOS";
                case TargetPlatform.MacOs:
                    return "Mac OS";
                case TargetPlatform.PsVita:
                    return "PS Vita";
                case TargetPlatform.WindowsMetro:
                    return "Windows Metro";
                case TargetPlatform.WindowsPhone:
                    return "Windows Phone";
                case TargetPlatform.XBox360:
                    return "XBox 360";
                default:
                    return targetPlatform.ToString();
            }
        }
    }
}
