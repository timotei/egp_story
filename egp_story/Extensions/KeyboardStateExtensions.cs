/*
   Copyright (C) 2011 by Timotei Dolean <timotei21@gmail.com>

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2 of the License, or
   (at your option) any later version.
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY.

   See the COPYING file for more details.
*/
using Microsoft.Xna.Framework.Input;

namespace egp_story
{
	public static class KeyboardStateExtensions
	{
		private static KeyboardState _lastState;

		public static void UpdateState( this KeyboardState state )
		{
			_lastState = state;
		}

		public static bool IsKeyDown2( this KeyboardState currentState, Keys key )
		{
			return currentState.IsKeyDown( key ) && _lastState.IsKeyUp( key );
		}
	}
}
