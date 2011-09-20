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
using System;
using Microsoft.Xna.Framework;

namespace egp_story
{
	public class Enemy : GameActor
	{
		private int _lastTimeMoved = 0;
		private Vector2 _lastDisplacement;
		private int _lastDisplacementUsedTimes;
		private static Random _random = new Random( );

		public Enemy( Game game, CardinalDirection initialFacingDirection, AnimatedSprite[] attackAnims,
			AnimatedSprite[] walkAnims, AnimatedSprite[] projectileAnims )
			: base( game, initialFacingDirection, attackAnims, walkAnims, projectileAnims )
		{
			IsEnemy = true;
		}

		public Enemy( Enemy other ) :
			base( other._game )
		{
			FacingDirection = other.FacingDirection;
			IsEnemy = true;

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
			if ( ( gameTime.TotalGameTime.TotalMilliseconds - _lastTimeMoved ) > 10 ) {
				_lastTimeMoved = ( int ) gameTime.TotalGameTime.TotalMilliseconds;

				// move randomly
				int steps = 0; // bound the maximum times to retry
				Vector2 displacement = new Vector2( );
				while ( steps < 10 ) {
					if ( steps == 0 && _lastDisplacementUsedTimes < 7 ) {
						// try last displacement
						displacement = _lastDisplacement;
						++_lastDisplacementUsedTimes;
					}
					else {
						displacement = levelMap.ThePlayer.Position - Position;
						displacement.X = MathHelper.Clamp( displacement.X, -1, 1 );
						displacement.Y = MathHelper.Clamp( displacement.Y, -1, 1 );

						displacement.X *= _random.Next( 4 ) - 1;
						displacement.Y *= ( displacement.X == 0 ? _random.Next( 4 ) - 1 : 0 );

						_lastDisplacementUsedTimes = 0;
					}

					Rectangle newBoundingBox = BoundingBox;
					newBoundingBox.Offset( ( int ) displacement.X, ( int ) displacement.Y );
					if ( IsNewPositionOK( levelMap, newBoundingBox ) ) {
						Position += displacement;

						if ( levelMap.ThePlayer.BoundingBox.Intersects( newBoundingBox ) ) {
							levelMap.ThePlayer.IsDead = true;
						}
						break;
					}
					else {
						// discard the last used displacement
						_lastDisplacementUsedTimes = 500;
					}
					++steps;
				}

				// save displacement
				_lastDisplacement = displacement;

				if ( displacement.Y == 0 ) {
					if ( displacement.X < 0 ) FacingDirection = CardinalDirection.WEST;
					else FacingDirection = CardinalDirection.EAST;
				}

				if ( displacement.X == 0 ) {
					if ( displacement.Y < 0 ) FacingDirection = CardinalDirection.NORTH;
					else FacingDirection = CardinalDirection.SOUTH;
				}
				ReplaceCurrentAnimation( );
			}

			if ( CurrentAnimation != null ) {
				CurrentAnimation.Update( gameTime );
			}
		}

		private bool IsNewPositionOK( LevelMap levelMap, Rectangle rectangle )
		{
			return ( levelMap.CheckRectangleBounds( rectangle ) &&
					CheckHitAndRemove( levelMap, rectangle, false ) == null );
		}

		public static Enemy CreateBugEnemy( Game game )
		{
			return new Enemy( game, CardinalDirection.SOUTH, null,
				new[] { 
					new AnimatedSprite( Assets.BugWalkNorth, 2, 5 ),
					new AnimatedSprite( Assets.BugWalkSouth, 2, 5 ),
					new AnimatedSprite( Assets.BugWalkEast, 2, 5 )},
					null
				);
		}

		public static Enemy CreateSkeletEnemy( Game game )
		{
			return new Enemy( game, CardinalDirection.SOUTH, null,
				new[] { 
					new AnimatedSprite( Assets.SkeletWalkNorth, 3, 10 ),
					new AnimatedSprite( Assets.SkeletWalkSouth, 5, 10 ),
					new AnimatedSprite( Assets.SkeletWalkEast, 2, 5 )},
					null
				);
		}
	}
}
