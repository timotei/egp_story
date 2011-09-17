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
using Microsoft.Xna.Framework.Input;

namespace egp_story.Menus
{
	public class MainMenu : Menu
	{
		private Vector2 _backgroundPosition = new Vector2( 0, 40 );
		private float _xDisplacement = -0.5f;
		private int _menuItemSelected = 0;

		public MainMenu( Game game )
			: base( game )
		{
		}

		public override void Update( GameTime gameTime )
		{
			if ( Keyboard.GetState( ).IsKeyDown2( Keys.Enter ) ) {
				switch ( _menuItemSelected ) {
					case 0:
						SelectedMenu = new StoryTellingMenu( Game, 0, null, new MapMenu( Game ) );
						break;
					case 1:
						SelectedMenu = new HowToPlayMenu( Game );
						break;
					case 2:
						Game.Exit( );
						break;
					default:
						// nothing.
						break;
				}
			}
			else if ( Keyboard.GetState( ).IsKeyDown2( Keys.Down ) ) {
				if ( _menuItemSelected < 2 ) {
					_menuItemSelected = _menuItemSelected + 1;
				}
			}
			else if ( Keyboard.GetState( ).IsKeyDown2( Keys.Up ) ) {
				if ( _menuItemSelected > 0 ) {
					--_menuItemSelected;
				}
			}

			_backgroundPosition.X += _xDisplacement;

			if ( _backgroundPosition.X >= 0 ||
				_backgroundPosition.X <= TheStory.GAME_WIDTH - Assets.MainMenuBackground.Width ) {
				_xDisplacement *= -1;
			}
		}

		public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Assets.MainMenuBackground, _backgroundPosition );

			spriteBatch.Draw( Assets.MainMenuFrame, Vector2.Zero );

			spriteBatch.DrawString( Assets.StyledFont, "H A R A P -- A L B ", new Vector2( 280, 80 ), Color.White );

			spriteBatch.DrawString( Assets.StyledFont, "Tell me the story!", new Vector2( 120, 310 ),
				_menuItemSelected == 0 ? Color.Red : Color.White );
			spriteBatch.DrawString( Assets.StyledFont, "How to play", new Vector2( 120, 350 ),
				_menuItemSelected == 1 ? Color.Red : Color.White );
			spriteBatch.DrawString( Assets.StyledFont, "Exit", new Vector2( 120, 390 ),
				_menuItemSelected == 2 ? Color.Red : Color.White );

			spriteBatch.DrawString( Assets.MainFont, "7 days game by Timotei Dolean",
				new Vector2( 150, 512 - 35 ), Color.White );
		}
	}
}
