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

		private Player _player;

		public DarkvilleFarmsLevel( )
		{
			_player = new Player( CardinalDirection.EAST,
				new[] {
					new AnimatedSprite( Assets.SilverboltShootNorth, 10, 10 ),
					new AnimatedSprite( Assets.SilverboltShootSouth, 10, 10 ),
					new AnimatedSprite( Assets.SilverboltShootEast, 10, 10 ) },
				new[] { 
					new AnimatedSprite( Assets.SilverboltWalkNorth, 2, 10 ),
					new AnimatedSprite( Assets.SilverboltWalkSouth, 2, 10 ),
					new AnimatedSprite( Assets.SilverboltWalkEast, 2, 10 )}
				);
		}

		public void Update( GameTime gameTime )
		{
			_player.Update( gameTime );
		}

		public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			_player.Draw( spriteBatch, gameTime );
		}
		#endregion
	}
}
