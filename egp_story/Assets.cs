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
		public static SpriteFont StyledFont { get; private set; }

		public static Texture2D MainMenuBackground { get; private set; }
		public static Texture2D MainMenuFrame { get; private set; }
		public static Texture2D FrameBackground { get; private set; }
		public static Texture2D HowToPlayBackground { get; private set; }

		public static Texture2D WorldMapTexture { get; private set; }
		public static Texture2D Cross { get; private set; }

		public static Texture2D HarapAlbShootSouth { get; private set; }
		public static Texture2D HarapAlbShootNorth { get; private set; }
		public static Texture2D HarapAlbShootEast { get; private set; }

		public static Texture2D HarapAlbWalkSouth { get; private set; }
		public static Texture2D HarapAlbWalkNorth { get; private set; }
		public static Texture2D HarapAlbWalkEast { get; private set; }

		public static Texture2D BugWalkSouth { get; private set; }
		public static Texture2D BugWalkNorth { get; private set; }
		public static Texture2D BugWalkEast { get; private set; }

		public static Texture2D SkeletWalkSouth { get; private set; }
		public static Texture2D SkeletWalkNorth { get; private set; }
		public static Texture2D SkeletWalkEast { get; private set; }

		public static Texture2D ArrowNorth { get; private set; }
		public static Texture2D ArrowSouth { get; private set; }
		public static Texture2D ArrowEast { get; private set; }

		public static Texture2D ViridesPuirrBackground { get; private set; }
		public static Texture2D ViridesPuirrBackgroundMask { get; private set; }

		public static Texture2D CalipuirrBackground { get; private set; }
		public static Texture2D CalipuirrBackgroundMask { get; private set; }

		public static Texture2D EllyuteionLakeBackground { get; private set; }
		public static Texture2D EllyuteionLakeBackgroundMask { get; private set; }

		public static Texture2D MirrosHillsBackground { get; private set; }
		public static Texture2D MirrosHillsBackgroundMask { get; private set; }

		public static Texture2D PandorashysBackground { get; private set; }
		public static Texture2D PandorashysBackgroundMask { get; private set; }

		public static Texture2D LoseMessage { get; private set; }
		public static Texture2D WinMessage { get; private set; }

		public static Texture2D[][] Stories;

		/// <summary>
		/// A blank 1x1 pixel (used by default for drawing lines)
		/// </summary>
		public static Texture2D BlankPixel { get; private set; }

		public static void LoadAssets( ContentManager content )
		{
			MainFont = content.Load<SpriteFont>( "Arial" );
			StyledFont = content.Load<SpriteFont>( "Trinigan" );

			MainMenuBackground = content.Load<Texture2D>( "gfx/main_menu_background" );
			MainMenuFrame = content.Load<Texture2D>( "gfx/main_menu_frame" );
			FrameBackground = content.Load<Texture2D>( "gfx/frame_background" );
			HowToPlayBackground = content.Load<Texture2D>( "gfx/how_to_play" );

			WorldMapTexture = content.Load<Texture2D>( "gfx/WorldMap" );

			Cross = content.Load<Texture2D>( "gfx/cross" );

			HarapAlbShootSouth = content.Load<Texture2D>( "gfx/harapalb/shoot_s" );
			HarapAlbShootNorth = content.Load<Texture2D>( "gfx/harapalb/shoot_n" );
			HarapAlbShootEast = content.Load<Texture2D>( "gfx/harapalb/shoot_e" );

			HarapAlbWalkSouth = content.Load<Texture2D>( "gfx/harapalb/walk_s" );
			HarapAlbWalkNorth = content.Load<Texture2D>( "gfx/harapalb/walk_n" );
			HarapAlbWalkEast = content.Load<Texture2D>( "gfx/harapalb/walk_e" );

			ArrowEast = content.Load<Texture2D>( "gfx/harapalb/arrow_e" );
			ArrowNorth = content.Load<Texture2D>( "gfx/harapalb/arrow_n" );
			ArrowSouth = content.Load<Texture2D>( "gfx/harapalb/arrow_s" );

			ViridesPuirrBackground = content.Load<Texture2D>( "gfx/levels/viridespuirr" );
			ViridesPuirrBackgroundMask = content.Load<Texture2D>( "gfx/levels/viridespuirr_mask" );

			CalipuirrBackground = content.Load<Texture2D>( "gfx/levels/calipuirr" );
			CalipuirrBackgroundMask = content.Load<Texture2D>( "gfx/levels/calipuirr_mask" );

			EllyuteionLakeBackground = content.Load<Texture2D>( "gfx/levels/ellyuteion_lake" );
			EllyuteionLakeBackgroundMask = content.Load<Texture2D>( "gfx/levels/ellyuteion_lake_mask" );

			MirrosHillsBackground = content.Load<Texture2D>( "gfx/levels/mirros_hills" );
			MirrosHillsBackgroundMask = content.Load<Texture2D>( "gfx/levels/mirros_hills_mask" );

			PandorashysBackground = content.Load<Texture2D>( "gfx/levels/pandorashys" );
			PandorashysBackgroundMask = content.Load<Texture2D>( "gfx/levels/pandorashys_mask" );

			BugWalkSouth = content.Load<Texture2D>( "gfx/mobs/bug_walk_s" );
			BugWalkNorth = content.Load<Texture2D>( "gfx/mobs/bug_walk_n" );
			BugWalkEast = content.Load<Texture2D>( "gfx/mobs/bug_walk_e" );

			SkeletWalkSouth = content.Load<Texture2D>( "gfx/mobs/skelet_walk_s" );
			SkeletWalkNorth = content.Load<Texture2D>( "gfx/mobs/skelet_walk_n" );
			SkeletWalkEast = content.Load<Texture2D>( "gfx/mobs/skelet_walk_e" );

			LoseMessage = content.Load<Texture2D>( "gfx/postcard_lose" );
			WinMessage = content.Load<Texture2D>( "gfx/postcard_win" );

			// create the blank pixel
			GraphicsDeviceManager graphicsManager = ( GraphicsDeviceManager )
				content.ServiceProvider.GetService( typeof( IGraphicsDeviceManager ) );

			BlankPixel = new Texture2D( graphicsManager.GraphicsDevice, 1, 1 );
			Color[] bPix = new Color[1 * 1];
			BlankPixel.GetData<Color>( bPix );
			bPix[0].R = bPix[0].G = bPix[0].B = bPix[0].A = 255;
			BlankPixel.SetData<Color>( bPix );

			// stories
			Stories = new Texture2D[][] { 
				new Texture2D[] { content.Load<Texture2D>( "gfx/story/story0_0" ),
					content.Load<Texture2D>( "gfx/story/story0_1" ),
					content.Load<Texture2D>( "gfx/story/story0_2" ) },
				new Texture2D[] { content.Load<Texture2D> ( "gfx/story/story1_0" ) }
			};
		}
	}
}
