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

using egp_story.Levels;
using Microsoft.Xna.Framework;

namespace egp_story.Menus
{
	public abstract class Menu : IDrawable, IUpdateable
	{
		public StoryLevel SelectedLevel { get; protected set; }
		public Menu SelectedMenu { get; protected set; }
		public Game Game { get; protected set; }

		public Menu( Game game )
		{
			Game = game;
		}


		#region IUpdateable Members

		public abstract void Update( Microsoft.Xna.Framework.GameTime gameTime );

		#endregion

		#region IDrawable Members

		public abstract void Draw( Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime );

		#endregion
	}
}
