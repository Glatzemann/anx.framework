using System;
using ANX.Framework;
using ANX.Framework.Input;
using ANX.Framework.NonXNA;
using Input = OpenTK.Input;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.InputDevices.OpenTK
{
    public class GamePad : IGamePad
    {
        public GamePadCapabilities GetCapabilities(PlayerIndex playerIndex)
        {
            throw new NotImplementedException();
        }

        public GamePadState GetState(PlayerIndex playerIndex)
        {
            return Input.GamePad.GetState((int)playerIndex).ToAnx();
        }

        public GamePadState GetState(PlayerIndex playerIndex, GamePadDeadZone deadZoneMode)
        {
            throw new NotImplementedException();
        }

        public bool SetVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            return Input.GamePad.SetVibration((int)playerIndex, leftMotor, rightMotor);
        }
    }
}
