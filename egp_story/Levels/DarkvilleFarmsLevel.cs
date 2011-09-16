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
namespace egp_story.Levels
{
	public class DarkvilleFarmsLevel : IStoryLevel
	{
		#region IStoryLevel Members
		private LevelMap _map;

		public DarkvilleFarmsLevel( Game game )
		{
			Player player = new Player( game, CardinalDirection.SOUTH,
				new[] {
					new AnimatedSprite( Assets.SilverboltShootNorth, 10, 20 ),
					new AnimatedSprite( Assets.SilverboltShootSouth, 10, 20 ),
					new AnimatedSprite( Assets.SilverboltShootEast, 10, 20 ) },
				new[] { 
					new AnimatedSprite( Assets.SilverboltWalkNorth, 1, 10 ),
					new AnimatedSprite( Assets.SilverboltWalkSouth, 1, 10 ),
					new AnimatedSprite( Assets.SilverboltWalkEast, 1, 10 )},
				new[] { 
					new AnimatedSprite( Assets.SilverboltArrowNorth, 1, 1),
					new AnimatedSprite( Assets.SilverboltArrowSouth, 1, 1),
					new AnimatedSprite( Assets.SilverboltArrowEast, 1, 1)
					}
				);

			Enemy bugEnemy = new Enemy( game, CardinalDirection.SOUTH, null,
				new[] { 
					new AnimatedSprite( Assets.BugWalkNorth, 2, 5 ),
					new AnimatedSprite( Assets.BugWalkSouth, 2, 5 ),
					new AnimatedSprite( Assets.BugWalkEast, 2, 5 )},
					null
				);

			_map = new LevelMap( player, bugEnemy, Assets.DarkvilleFarmsBackground, Assets.DarkvilleFarmsBackgroundMask );
		}

		public void Update( GameTime gameTime )
		{
			_map.Update( gameTime );
		}

		public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			_map.Draw( spriteBatch, gameTime );
		}
		#endregion
	}
}
