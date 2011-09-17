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

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace egp_story
{
	public class Player : GameActor
	{
		private Queue<Projectile> _projectilesShot;

		public Player( Game parent, CardinalDirection initialFacingDirection, AnimatedSprite[] attackAnims,
			AnimatedSprite[] walkAnims, AnimatedSprite[] projectileAnims )
			: base( parent, initialFacingDirection, attackAnims, walkAnims, projectileAnims )
		{
			_projectilesShot = new Queue<Projectile>( );
		}

		#region IDrawable Members

		public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			base.Draw( spriteBatch, gameTime );

			foreach ( Projectile projectile in _projectilesShot ) {
				projectile.Animation.Draw( spriteBatch, projectile.Position, gameTime,
					FacingDirection == CardinalDirection.WEST ? SpriteEffects.FlipHorizontally : SpriteEffects.None );
			}
		}

		#endregion

		public override void Update( LevelMap levelMap, GameTime gameTime )
		{
			KeyboardState keys = Keyboard.GetState( );
			if ( !_attacking && keys.IsKeyDown2( Keys.Space ) ) {
				_attacking = true;
				ReplaceCurrentAnimation( );
			}
			else if ( _attacking && CurrentAnimation.Finished ) {
				_attacking = false;
				ReplaceCurrentAnimation( );

				// create new projectile
				AnimatedSprite projectileAnim = null;

				switch ( FacingDirection ) {
					case CardinalDirection.EAST:
						projectileAnim = ProjectileEastAnim;
						break;
					case CardinalDirection.WEST:
						projectileAnim = ProjectileEastAnim;
						break;
					case CardinalDirection.SOUTH:
						projectileAnim = ProjectileSouthAnim;
						break;
					case CardinalDirection.NORTH:
						projectileAnim = ProjectileNorthAnim;
						break;
				}

				if ( projectileAnim != null )
					_projectilesShot.Enqueue( new Projectile( ) {
						Animation = projectileAnim,
						Position = Position + CurrentAnimation.FrameBoundingBox.Size( ) / 2,
						Velocity = FacingDirection.ToVelocity( )
					} );
			}

			// cannot move while attacking
			if ( !_attacking ) {
				bool moved = false;
				if ( keys.IsKeyDown( Keys.Left ) ) {
					FacingDirection = CardinalDirection.WEST;
					moved = true;
				}
				else if ( keys.IsKeyDown( Keys.Right ) ) {
					FacingDirection = CardinalDirection.EAST;
					moved = true;
				}
				else if ( keys.IsKeyDown( Keys.Down ) ) {
					FacingDirection = CardinalDirection.SOUTH;
					moved = true;
				}
				else if ( keys.IsKeyDown( Keys.Up ) ) {
					FacingDirection = CardinalDirection.NORTH;
					moved = true;
				}

				if ( moved ) {
					ReplaceCurrentAnimation( );
					// check if we can move there.
					Vector2 newPosition = ( Position + FacingDirection.ToVelocity( ) * 2 );
					Rectangle newBoundingBox = CurrentAnimation.FrameBoundingBox;
					newBoundingBox.Offset( ( int ) newPosition.X, ( int ) newPosition.Y );

					if ( levelMap.CheckRectangleBounds( newBoundingBox ) ) {
						// check collision with other objects
						bool collides = false;
						foreach ( GameActor actor in levelMap.ActorObjects ) {
							if ( actor.BoundingBox.Intersects( newBoundingBox ) ) {
								if ( actor.IsEnemy ) {
									this.IsDead = true;
								}
								else {
									collides = true;
								}
								break;
							}
						}

						if ( !collides ) {
							Position = newPosition;
						}
					}
				}
			}

			if ( CurrentAnimation != null ) {
				CurrentAnimation.Update( gameTime );
			}

			Projectile[] tmpArray = _projectilesShot.ToArray( );

			for ( int i = 0; i < tmpArray.Length; ++i ) {
				Projectile projectile = tmpArray[i];
				projectile.Animation.Update( gameTime );
				projectile.Position += projectile.Velocity * 5;

				Rectangle projectileBox = projectile.Animation.FrameBoundingBox;
				projectileBox.Offset( ( int ) projectile.Position.X, ( int ) projectile.Position.Y );

				if ( !levelMap.Mask.Bounds.Contains( ref projectile.Position ) ) {
					// remove this
					_projectilesShot.Dequeue( );
				}
				else if ( !levelMap.CheckRectangleBounds( projectileBox, true ) ) {
					//TODO: add hit animation
					_projectilesShot.Dequeue( );
				}
				else {
					// check collision with other objects
					if ( CheckHitAndRemove( levelMap, projectileBox ) != null ) {
						_projectilesShot.Dequeue( );
					}
				}
			}
		}

		public static Player CreateNewHarapAlb( Game game )
		{
			return new Player( game, CardinalDirection.SOUTH,
				new[] {
					new AnimatedSprite( Assets.HarapAlbShootNorth, 6, 15 ),
					new AnimatedSprite( Assets.HarapAlbShootSouth, 6, 15 ),
					new AnimatedSprite( Assets.HarapAlbShootEast, 6, 15 ) },
				new[] { 
					new AnimatedSprite( Assets.HarapAlbWalkNorth, 6, 10 ),
					new AnimatedSprite( Assets.HarapAlbWalkSouth, 6, 10 ),
					new AnimatedSprite( Assets.HarapAlbWalkEast, 6, 10 )},
				new[] { 
					new AnimatedSprite( Assets.ArrowNorth, 1, 1),
					new AnimatedSprite( Assets.ArrowSouth, 1, 1),
					new AnimatedSprite( Assets.ArrowEast, 1, 1)
					}
				);
		}
	}

	class Projectile
	{
		public AnimatedSprite Animation;
		public Vector2 Position;

		public Vector2 Velocity;
	}
}
