using egp_story.Levels;
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

namespace egp_story
{
	public class TheStory : Microsoft.Xna.Framework.Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private StoryLevel _currentLevel;
		private Menu _currentMenu;

		public TheStory( )
		{
			graphics = new GraphicsDeviceManager( this );
			Content.RootDirectory = "Content";
		}

		protected override void Initialize( )
		{
			base.Initialize( );
		}

		protected override void LoadContent( )
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch( GraphicsDevice );
			Assets.LoadAssets( Content );
		}

		protected override void UnloadContent( )
		{
			// TODO: Unload any non ContentManager content here
		}

		protected override void Update( GameTime gameTime )
		{
			if ( Keyboard.GetState( ).IsKeyDown( Keys.Escape ) )
				Exit( );

			base.Update( gameTime );

			if ( _currentLevel != null ) {
				_currentLevel.Update( gameTime );
			}
			else if ( _currentMenu != null ) {
				_currentMenu.Update( gameTime );
			}
		}

		protected override void Draw( GameTime gameTime )
		{
			GraphicsDevice.Clear( Color.CornflowerBlue );

			spriteBatch.Begin( );
			base.Draw( gameTime );

			if ( _currentLevel != null ) {
				_currentLevel.Draw( spriteBatch, gameTime );
			}
			else if ( _currentMenu != null ) {
				_currentMenu.Draw( spriteBatch, gameTime );
			}

			spriteBatch.End( );
		}
	}
}
