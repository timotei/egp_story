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
using Microsoft.Xna.Framework;

namespace egp_story
{
	public enum CardinalDirection
	{
		NORTH = 1,
		SOUTH = 2,
		WEST = 4,
		EAST = 8
	}

	public static class CardinalDirectionExtensions
	{
		public static Vector2 ToVelocity( this CardinalDirection direction )
		{
			switch ( direction ) {
				case CardinalDirection.EAST:
					return new Vector2( 1, 0 );
				case CardinalDirection.WEST:
					return new Vector2( -1, 0 );
				case CardinalDirection.SOUTH:
					return new Vector2( 0, 1 );
				case CardinalDirection.NORTH:
					return new Vector2( 0, -1 );
				default:
					return Vector2.Zero;
			}
		}
	}
}
