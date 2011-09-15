using Microsoft.Xna.Framework;
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

		public static Texture2D SilverboltShootSouth { get; private set; }
		public static Texture2D SilverboltShootNorth { get; private set; }
		public static Texture2D SilverboltShootEast { get; private set; }

		public static Texture2D SilverboltWalkSouth { get; private set; }
		public static Texture2D SilverboltWalkNorth { get; private set; }
		public static Texture2D SilverboltWalkEast { get; private set; }

		public static Texture2D BugWalkSouth { get; private set; }
		public static Texture2D BugWalkNorth { get; private set; }
		public static Texture2D BugWalkEast { get; private set; }

		public static Texture2D SilverboltArrowNorth { get; private set; }
		public static Texture2D SilverboltArrowSouth { get; private set; }
		public static Texture2D SilverboltArrowEast { get; private set; }

		public static Texture2D DarkvilleFarmsBackground { get; private set; }
		public static Texture2D DarkvilleFarmsBackgroundMask { get; private set; }

		/// <summary>
		/// A blank 1x1 pixel (used by default for drawing lines)
		/// </summary>
		public static Texture2D BlankPixel { get; private set; }

		public static void LoadAssets( ContentManager content )
		{
			MainFont = content.Load<SpriteFont>( "Arial" );
			WorldMapTexture = content.Load<Texture2D>( "WorldMap" );

			Dot = content.Load<Texture2D>( "dot" );

			SilverboltShootSouth = content.Load<Texture2D>( "gfx/silverbolt/shoot_s" );
			SilverboltShootNorth = content.Load<Texture2D>( "gfx/silverbolt/shoot_n" );
			SilverboltShootEast = content.Load<Texture2D>( "gfx/silverbolt/shoot_e" );

			SilverboltWalkSouth = content.Load<Texture2D>( "gfx/silverbolt/walk_s" );
			SilverboltWalkNorth = content.Load<Texture2D>( "gfx/silverbolt/walk_n" );
			SilverboltWalkEast = content.Load<Texture2D>( "gfx/silverbolt/walk_e" );

			SilverboltArrowEast = content.Load<Texture2D>( "gfx/silverbolt/arrow_e" );
			SilverboltArrowNorth = content.Load<Texture2D>( "gfx/silverbolt/arrow_n" );
			SilverboltArrowSouth = content.Load<Texture2D>( "gfx/silverbolt/arrow_s" );

			DarkvilleFarmsBackground = content.Load<Texture2D>( "gfx/levels/darkville_farms" );
			DarkvilleFarmsBackgroundMask = content.Load<Texture2D>( "gfx/levels/darkville_farms_mask" );

			BugWalkSouth = content.Load<Texture2D>( "gfx/mobs/bug_walk_s" );
			BugWalkNorth = content.Load<Texture2D>( "gfx/mobs/bug_walk_n" );
			BugWalkEast = content.Load<Texture2D>( "gfx/mobs/bug_walk_e" );

			// create the blank pixel
			GraphicsDeviceManager graphicsManager = ( GraphicsDeviceManager )
				content.ServiceProvider.GetService( typeof( IGraphicsDeviceManager ) );

			BlankPixel = new Texture2D( graphicsManager.GraphicsDevice, 1, 1 );
			Color[] bPix = new Color[1 * 1];
			BlankPixel.GetData<Color>( bPix );
			bPix[0].R = bPix[0].G = bPix[0].B = bPix[0].A = 255;
			BlankPixel.SetData<Color>( bPix );
		}
	}
}
