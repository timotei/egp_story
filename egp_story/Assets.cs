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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace egp_story
{
	public class Assets
	{
		public static SpriteFont MainFont { get; private set; }
		public static Texture2D WorldMapTexture { get; private set; }
		public static Texture2D Dot { get; private set; }
		public static Texture2D SpriteAnim { get; private set; }

		public static void LoadAssets( ContentManager content )
		{
			MainFont = content.Load<SpriteFont>( "Arial" );
			WorldMapTexture = content.Load<Texture2D>( "WorldMap" );

			Dot = content.Load<Texture2D>( "dot" );
			SpriteAnim = content.Load<Texture2D>( "test_sprite" );
		}
	}
}
