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
using egp_story.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace egp_story.Menus
{
	public class MapMenu : Menu
	{
		private static Vector2[] LOCATIONS = new[] {
											new Vector2( 80, 75 ),
											new Vector2( 420, 76 ),
											new Vector2( 94, 241 ),
											new Vector2( 330, 267 ),
											new Vector2( 226, 200 )
										};
		private const float VIEW_OFFSET = 50f;
		public static bool[] WON_STATUSES = new bool[LOCATIONS.Length];

		private int _currentLocation;
		private Rectangle _targetRectangle;

		public MapMenu( Game game )
			: base( game )
		{
			_targetRectangle = new Rectangle( 0, 0, TheStory.GAME_WIDTH, Assets.WorldMapTexture.Height );
			_currentLocation = 0;
			foreach ( bool status in WON_STATUSES ) {
				if ( status == true ) {
					_currentLocation = ( _currentLocation + 1 ) % LOCATIONS.Length;
				}
			}
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

			int prevLocation = _currentLocation;
			// select location
			if ( Keyboard.GetState( ).IsKeyDown2( Keys.Left ) ) {
				--_currentLocation;
			}
			else if ( Keyboard.GetState( ).IsKeyDown2( Keys.Right ) ) {
				++_currentLocation;
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

			if ( Keyboard.GetState( ).IsKeyDown2( Keys.Enter ) ) {
				switch ( _currentLocation ) {
					case 0: SelectedLevel = new ViridesPuirr( Game, 0 ); break;
					case 1: SelectedLevel = new Calipuirr( Game, 1 ); break;
					case 2: SelectedLevel = new EllyuteionLake( Game, 2 ); break;
					case 3: SelectedLevel = new MirrosHills( Game, 3 ); break;
					case 4: SelectedLevel = new Pandorashys( Game, 4 ); break;
					default: break;
				}
			}
			else if ( Keyboard.GetState( ).IsKeyDown2( Keys.Back ) ) {
				SelectedMenu = new MainMenu( Game );
			}

		}

		public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Assets.WorldMapTexture, _targetRectangle, Color.White );

			// draw completed levels
			for ( int i = 0; i < LOCATIONS.Length; ++i ) {
				if ( WON_STATUSES[i] == true ) {
					spriteBatch.Draw( Assets.Cross, LOCATIONS[i] + new Vector2( 0, _targetRectangle.Y ),
						Assets.Cross.Bounds.Center.ToVector2( ), Color.Yellow );
				}
			}

			// draw the location
			spriteBatch.Draw( Assets.Cross, LOCATIONS[_currentLocation] + new Vector2( 0, _targetRectangle.Y ),
				Assets.Cross.Bounds.Center.ToVector2( ), Color.Red );
		}
		#endregion
	}
}
