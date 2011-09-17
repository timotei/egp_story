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

namespace egp_story.Levels
{
	public class EllyuteionLake : StoryLevel
	{
		public EllyuteionLake( Game game, int index )
			: base( game, index )
		{
			Player player = Player.CreateNewHarapAlb( game );
			Enemy bugEnemy = Enemy.CreateBugEnemy( game );

			LevelMap = new LevelMap( player, bugEnemy,
				Assets.EllyuteionLakeBackground, Assets.EllyuteionLakeBackgroundMask );
		}
	}
}
