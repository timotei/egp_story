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
	public class Player : IDrawable
	{
		public Vector2 Position { get; set; }

		public CardinalDirection FacingDirection { get; set; }

		public AnimatedSprite AttackNorthAnim { get; set; }
		public AnimatedSprite AttackSouthAnim { get; set; }
		public AnimatedSprite AttackEastAnim { get; set; }

		public AnimatedSprite WalkNorthAnim { get; set; }
		public AnimatedSprite WalkSouthAnim { get; set; }
		public AnimatedSprite WalkEastAnim { get; set; }

		public AnimatedSprite ProjectileNorthAnim { get; set; }
		public AnimatedSprite ProjectileSouthAnim { get; set; }
		public AnimatedSprite ProjectileEastAnim { get; set; }

		public AnimatedSprite CurrentAnimation { get; set; }

		private Queue<Projectile> _projectilesShot;
		private bool _attacking;

		private GraphicsDeviceManager _graphics;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="initialFacingDirection"></param>
		/// <param name="attackAnims">The order of the animations: North, South, East</param>
		/// <param name="walkAnims">The order of the animations: North, South, East</param>
		/// <param name="projectileAnims">The order of the animations: North, South, East</param>
		public Player( Game parent, CardinalDirection initialFacingDirection, AnimatedSprite[] attackAnims,
			AnimatedSprite[] walkAnims, AnimatedSprite[] projectileAnims )
		{
			AttackNorthAnim = attackAnims[0];
			AttackSouthAnim = attackAnims[1];
			AttackEastAnim = attackAnims[2];

			WalkNorthAnim = walkAnims[0];
			WalkSouthAnim = walkAnims[1];
			WalkEastAnim = walkAnims[2];

			ProjectileNorthAnim = projectileAnims[0];
			ProjectileSouthAnim = projectileAnims[1];
			ProjectileEastAnim = projectileAnims[2];

			_projectilesShot = new Queue<Projectile>( );

			_graphics = ( GraphicsDeviceManager ) parent.Services.GetService( typeof( IGraphicsDeviceManager ) );

			FacingDirection = initialFacingDirection;
			ReplaceCurrentAnimation( );
		}

		private void ReplaceCurrentAnimation( )
		{
			StopAnimation( );

			switch ( FacingDirection ) {
				case CardinalDirection.EAST:
					CurrentAnimation = _attacking ? AttackEastAnim : WalkEastAnim;
					break;
				case CardinalDirection.WEST:
					CurrentAnimation = _attacking ? AttackEastAnim : WalkEastAnim;
					break;
				case CardinalDirection.SOUTH:
					CurrentAnimation = _attacking ? AttackSouthAnim : WalkSouthAnim;
					break;
				case CardinalDirection.NORTH:
					CurrentAnimation = _attacking ? AttackNorthAnim : WalkNorthAnim;
					break;
			}

			CurrentAnimation.Playing = true;
		}

		#region IDrawable Members

		public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			if ( CurrentAnimation != null ) {
				CurrentAnimation.Draw( spriteBatch, Position, gameTime,
					FacingDirection == CardinalDirection.WEST ? SpriteEffects.FlipHorizontally : SpriteEffects.None );
			}

			foreach ( Projectile projectile in _projectilesShot ) {
				projectile.Animation.Draw( spriteBatch, projectile.Position, gameTime,
					FacingDirection == CardinalDirection.WEST ? SpriteEffects.FlipHorizontally : SpriteEffects.None );
			}
		}

		#endregion

		public void Update( LevelMap levelMap, GameTime gameTime )
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

					if ( levelMap.Mask.Bounds.Contains( newBoundingBox ) ) {
						bool canMove = false;
						// upper left
						Color texel = levelMap.GetTexel( newPosition.Y, newPosition.X );
						if ( texel == Color.White || texel == Color.Black ) {

							// upper right
							texel = levelMap.GetTexel( newPosition.Y, newBoundingBox.Right );
							if ( texel == Color.White || texel == Color.Black ) {

								// bottom right
								texel = levelMap.GetTexel( newBoundingBox.Bottom, newBoundingBox.Right );
								if ( texel == Color.White || texel == Color.Black ) {

									// bottom left
									texel = levelMap.GetTexel( newBoundingBox.Bottom, newPosition.X );
									if ( texel == Color.White || texel == Color.Black ) {
										canMove = true;
									}
								}
							}
						}

						if ( canMove ) {
							Position += FacingDirection.ToVelocity( ) * 2;
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

				if ( !_graphics.GraphicsDevice.Viewport.Bounds.Contains( ref projectile.Position ) ) {
					// remove this
					_projectilesShot.Dequeue( );
				}
			}
		}

		private void StopAnimation( )
		{
			if ( CurrentAnimation == null )
				return;

			CurrentAnimation.Playing = false;
			CurrentAnimation.Reset( );
		}
	}

	class Projectile
	{
		public AnimatedSprite Animation;
		public Vector2 Position;

		public Vector2 Velocity;
	}
}
