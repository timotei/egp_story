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
	public class HowToPlayMenu : Menu
	{
		public HowToPlayMenu( Game game )
			: base( game )
		{

		}

		#region IDrawable Members

		public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Assets.FrameBackground, Vector2.Zero );
			spriteBatch.Draw( Assets.HowToPlayBackground, Vector2.Zero );

			spriteBatch.DrawString( Assets.StyledFont, "Beware of monsters. They can kill you!", new Vector2( 110, 350 ), Color.Black );

			spriteBatch.DrawString( Assets.StyledFont, "Go Back", new Vector2( 230, 450 ), Color.Red );
		}

		#endregion

		#region IUpdateable Members

		public override void Update( GameTime gameTime )
		{
			if ( Keyboard.GetState( ).IsKeyDown2( Keys.Enter ) ) {
				SelectedMenu = new MainMenu( Game );
			}
		}

		#endregion
	}
}
