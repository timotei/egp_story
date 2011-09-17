﻿/*
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

namespace egp_story.Levels
{
	public class ViridesPuirr : StoryLevel
	{
		public ViridesPuirr( Game game )
			: base( game )
		{
			Player player = new Player( game, CardinalDirection.SOUTH,
				new[] {
					new AnimatedSprite( Assets.HarapAlbShootNorth, 10, 20 ),
					new AnimatedSprite( Assets.HarapAlbShootSouth, 10, 20 ),
					new AnimatedSprite( Assets.HarapAlbShootEast, 10, 20 ) },
				new[] { 
					new AnimatedSprite( Assets.HarapAlbWalkNorth, 1, 10 ),
					new AnimatedSprite( Assets.HarapAlbWalkSouth, 1, 10 ),
					new AnimatedSprite( Assets.HarapAlbWalkEast, 1, 10 )},
				new[] { 
					new AnimatedSprite( Assets.ArrowNorth, 1, 1),
					new AnimatedSprite( Assets.ArrowSouth, 1, 1),
					new AnimatedSprite( Assets.ArrowEast, 1, 1)
					}
				);

			Enemy bugEnemy = new Enemy( game, CardinalDirection.SOUTH, null,
				new[] { 
					new AnimatedSprite( Assets.BugWalkNorth, 2, 5 ),
					new AnimatedSprite( Assets.BugWalkSouth, 2, 5 ),
					new AnimatedSprite( Assets.BugWalkEast, 2, 5 )},
					null
				);

			LevelMap = new LevelMap( player, bugEnemy, Assets.ViridesPuirrBackground, Assets.ViridesPuirrBackgroundMask );
		}
	}
}
