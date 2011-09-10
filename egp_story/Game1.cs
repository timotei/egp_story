using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace egp_story
{
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public Game1( )
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

		}

		protected override void UnloadContent( )
		{
			// TODO: Unload any non ContentManager content here
		}

		protected override void Update( GameTime gameTime )
		{
			// Allows the game to exit
			if ( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed )
				this.Exit( );

			// TODO: Add your update logic here

			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime )
		{
			GraphicsDevice.Clear( Color.CornflowerBlue );

			// TODO: Add your drawing code here

			base.Draw( gameTime );
		}
	}
}
