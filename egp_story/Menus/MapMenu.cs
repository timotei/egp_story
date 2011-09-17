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
	public class MapMenu : Menu
	{
		private static Vector2[] LOCATIONS = new[] {
											new Vector2( 180, 137 ),
											new Vector2( 320, 160 ),
											new Vector2( 675, 130 ),
											new Vector2( 515, 305 ),
											new Vector2( 200, 400 ),
											new Vector2( 818, 455 ),
											new Vector2( 484, 652 ),
											new Vector2( 751, 730 ),
											new Vector2( 300, 770 ),
											new Vector2( 755, 835 )
										};
		private const float VIEW_OFFSET = 50f;

		private int _currentLocation;
		private Rectangle _targetRectangle;

		public MapMenu( Game game )
			: base( game )
		{
			_targetRectangle = new Rectangle( 0, 0, TheStory.GAME_WIDTH, Assets.WorldMapTexture.Height );
			_currentLocation = 0;
		}

		#region Menu Members

		public override void Update( GameTime gameTime )
		{
			if ( Keyboard.GetState( ).IsKeyDown( Keys.Down ) ) {
				_targetRectangle.Y -= 10;
			}
			else if ( Keyboard.GetState( ).IsKeyDown( Keys.Up ) ) {
				_targetRectangle.Y += 10;
			}

			_targetRectangle.Y = ( int ) MathHelper.Clamp( _targetRectangle.Y,
				TheStory.GAME_HEIGHT - Assets.WorldMapTexture.Height, 0 );

			// select location
			if ( Keyboard.GetState( ).IsKeyDown2( Keys.Left ) ) {
				_currentLocation = ( _currentLocation - 1 ) % LOCATIONS.Length;
			}
			else if ( Keyboard.GetState( ).IsKeyDown2( Keys.Right ) ) {
				_currentLocation = ( _currentLocation + 1 ) % LOCATIONS.Length;
			}

			_currentLocation = ( int ) MathHelper.Clamp( _currentLocation, 0, LOCATIONS.Length - 1 );

			// if the current location is not visible, scroll it into view
			Vector2 currentLoc = LOCATIONS[_currentLocation];
			float difference = currentLoc.Y - ( Math.Abs( _targetRectangle.Y ) + TheStory.GAME_HEIGHT ) + VIEW_OFFSET;

			if ( difference > 0 ) {
				difference = difference / 5;
			}
			else {
				difference = currentLoc.Y - Math.Abs( _targetRectangle.Y ) - VIEW_OFFSET;
				if ( difference < 0 ) {
					difference = difference / 5;
				}
				else {
					// nothing
					difference = 0f;
				}
			}

			_targetRectangle.Y -= ( int ) difference;
		}

		public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Assets.WorldMapTexture, _targetRectangle, Color.White );

			// draw the location
			spriteBatch.Draw( Assets.Dot, LOCATIONS[_currentLocation] + new Vector2( 0, _targetRectangle.Y ),
				Assets.Dot.Bounds.Center.ToVector2( ) );
		}
		#endregion
	}
}
