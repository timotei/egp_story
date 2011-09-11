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

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace egp_story.Menus
{
	public class MapMenu : IMenu
	{
		private Rectangle _targetRectangle;

		public MapMenu( )
		{
			_targetRectangle = new Rectangle( 0, 0, TheStory.GAME_WIDTH, Assets.WorldMapTexture.Height );
		}

		#region Menu Members

		public void Update( GameTime gameTime )
		{
			if ( Keyboard.GetState( ).IsKeyDown( Keys.Down ) ) {
				_targetRectangle.Y -= 10;
			}
			else if ( Keyboard.GetState( ).IsKeyDown( Keys.Up ) ) {
				_targetRectangle.Y += 10;
			}
			Console.WriteLine( _targetRectangle.Y );

			_targetRectangle.Y = ( int ) MathHelper.Clamp( _targetRectangle.Y,
				TheStory.GAME_HEIGHT - Assets.WorldMapTexture.Height, 0 );
		}

		public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Assets.WorldMapTexture, _targetRectangle, Color.White );
		}
		#endregion
	}
}
