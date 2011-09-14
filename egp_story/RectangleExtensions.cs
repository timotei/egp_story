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
using Microsoft.Xna.Framework.Graphics;

namespace egp_story
{
	public static class RectangleExtensions
	{
		public static bool Contains( this Rectangle rectangle, Vector2 position )
		{
			return rectangle.Contains( ( int ) position.X, ( int ) position.Y );
		}

		public static bool Contains( this Rectangle rectangle, ref Vector2 position )
		{
			return rectangle.Contains( ( int ) position.X, ( int ) position.Y );
		}

		public static Vector2 Size( this Rectangle rectangle )
		{
			return new Vector2( rectangle.Width, rectangle.Height );
		}

		public static void Draw( this Rectangle rectangle, SpriteBatch spriteBatch )
		{
			spriteBatch.DrawLine( new Vector2( rectangle.X, rectangle.Y ),
				new Vector2( rectangle.X + rectangle.Width, rectangle.Y ), Color.Black );
			spriteBatch.DrawLine( new Vector2( rectangle.X + rectangle.Width, rectangle.Y ),
				new Vector2( rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height ), Color.Black );
			spriteBatch.DrawLine( new Vector2( rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height ),
				new Vector2( rectangle.X, rectangle.Y + rectangle.Height ), Color.Black );
			spriteBatch.DrawLine( new Vector2( rectangle.X, rectangle.Y + rectangle.Height ),
				new Vector2( rectangle.X, rectangle.Y ), Color.Black );
		}
	}
}
