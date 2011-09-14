using System;
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
	public static class SpriteBatchExtensions
	{
		public static void Draw( this SpriteBatch spriteBatch, Texture2D texture, Vector2 position,
			Vector2 origin, Color color )
		{
			spriteBatch.Draw( texture, position, null, color, 0, origin, 1f, SpriteEffects.None, 0 );
		}

		public static void Draw( this SpriteBatch spriteBatch, Texture2D texture, Vector2 position,
			Vector2 origin )
		{
			spriteBatch.Draw( texture, position, null, Color.White, 0, origin, 1f, SpriteEffects.None, 0 );
		}

		public static void Draw( this SpriteBatch spriteBatch, Texture2D texture, Vector2 position )
		{
			spriteBatch.Draw( texture, position, Color.White );
		}

		public static void Draw( this SpriteBatch spriteBatch, Texture2D texture, Rectangle destinationRectangle )
		{
			spriteBatch.Draw( texture, destinationRectangle, Color.White );
		}

		public static void DrawLine( this SpriteBatch sprite, Vector2 start, Vector2 end, Color color )
		{
			DrawLine( sprite, start, end, color, 1 );
		}

		public static void DrawLine( this SpriteBatch sprite, Vector2 start, Vector2 end, Color color, int thickness )
		{
			int distance = ( int ) Vector2.Distance( start, end );
			if ( distance > 1 ) {
				float alpha = ( float ) Math.Atan2( end.Y - start.Y, end.X - start.X );
				sprite.Draw( Assets.BlankPixel, new Rectangle( ( int ) start.X, ( int ) start.Y, distance, thickness ),
							null, color, alpha, new Vector2( 0, 0 ), SpriteEffects.None, 0 );
			}
			else
				sprite.Draw( Assets.BlankPixel, start, color );
		}

	}
}
