using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace egp_story
{
	public class Assets
	{
		public static SpriteFont MainFont { get; private set; }

		public static void LoadAssets( ContentManager content )
		{
			MainFont = content.Load<SpriteFont>( "Arial" );
		}
	}
}
