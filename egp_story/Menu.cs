using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace egp_story
{
	public abstract class Menu
	{
		public abstract void Update( GameTime gameTime );
		public abstract void Draw( SpriteBatch spriteBatch, GameTime gameTime );
	}
}
