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
namespace egp_story
{
	public class Enemy : GameActor
	{
		public Enemy( Game game, CardinalDirection initialFacingDirection, AnimatedSprite[] attackAnims,
			AnimatedSprite[] walkAnims, AnimatedSprite[] projectileAnims )
			: base( game, initialFacingDirection, attackAnims, walkAnims, projectileAnims )
		{
		}

		public Enemy( Enemy other ) :
			base( other._game )
		{
			FacingDirection = other.FacingDirection;

			if ( other.AttackEastAnim != null ) AttackEastAnim = new AnimatedSprite( other.AttackEastAnim );
			if ( other.AttackNorthAnim != null ) AttackNorthAnim = new AnimatedSprite( other.AttackNorthAnim );
			if ( other.AttackSouthAnim != null ) AttackSouthAnim = new AnimatedSprite( other.AttackSouthAnim );

			if ( other.WalkEastAnim != null ) WalkEastAnim = new AnimatedSprite( other.WalkEastAnim );
			if ( other.WalkNorthAnim != null ) WalkNorthAnim = new AnimatedSprite( other.WalkNorthAnim );
			if ( other.WalkSouthAnim != null ) WalkSouthAnim = new AnimatedSprite( other.WalkSouthAnim );

			if ( other.ProjectileEastAnim != null ) ProjectileEastAnim = new AnimatedSprite( other.ProjectileEastAnim );
			if ( other.ProjectileNorthAnim != null ) ProjectileNorthAnim = new AnimatedSprite( other.ProjectileNorthAnim );
			if ( other.ProjectileSouthAnim != null ) ProjectileSouthAnim = new AnimatedSprite( other.ProjectileSouthAnim );

			ReplaceCurrentAnimation( );
		}

		public override void Update( LevelMap levelMap, GameTime gameTime )
		{


			if ( CurrentAnimation != null ) {
				CurrentAnimation.Update( gameTime );
			}
		}
	}
}
