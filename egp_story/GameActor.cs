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
namespace egp_story
{
	public abstract class GameActor : IDrawable
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

		public Rectangle BoundingBox
		{
			get
			{
				Rectangle result = new Rectangle( ( int ) Position.X, ( int ) Position.Y, 0, 0 );

				if ( CurrentAnimation != null ) {
					result.Width = CurrentAnimation.FrameBoundingBox.Width;
					result.Height = CurrentAnimation.FrameBoundingBox.Height;
				}

				return result;
			}
		}

		protected GraphicsDeviceManager _graphics;
		protected Game _game;
		protected bool _attacking;

		public GameActor( Game game )
		{
			_game = game;
			_graphics = ( GraphicsDeviceManager ) game.Services.GetService( typeof( IGraphicsDeviceManager ) );
		}

		public GameActor( Game game, CardinalDirection initialFacingDirection, AnimatedSprite[] attackAnims,
			AnimatedSprite[] walkAnims, AnimatedSprite[] projectileAnims )
			: this( game )
		{
			if ( attackAnims != null && attackAnims.Length == 3 ) {
				AttackNorthAnim = attackAnims[0];
				AttackSouthAnim = attackAnims[1];
				AttackEastAnim = attackAnims[2];
			}

			if ( walkAnims != null && walkAnims.Length == 3 ) {
				WalkNorthAnim = walkAnims[0];
				WalkSouthAnim = walkAnims[1];
				WalkEastAnim = walkAnims[2];
			}

			if ( projectileAnims != null && projectileAnims.Length == 3 ) {
				ProjectileNorthAnim = projectileAnims[0];
				ProjectileSouthAnim = projectileAnims[1];
				ProjectileEastAnim = projectileAnims[2];
			}

			FacingDirection = initialFacingDirection;
			ReplaceCurrentAnimation( );
		}

		protected void ReplaceCurrentAnimation( )
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

			if ( CurrentAnimation != null ) {
				CurrentAnimation.Playing = true;
			}
		}

		protected void StopAnimation( )
		{
			if ( CurrentAnimation == null )
				return;

			CurrentAnimation.Playing = false;
			CurrentAnimation.Reset( );
		}

		public abstract void Update( LevelMap levelMap, GameTime gameTime );

		#region IDrawable Members

		public virtual void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			if ( CurrentAnimation != null ) {
				CurrentAnimation.Draw( spriteBatch, Position, gameTime,
					FacingDirection == CardinalDirection.WEST ? SpriteEffects.FlipHorizontally : SpriteEffects.None );
			}
		}

		#endregion



		/// <summary>
		/// Checks if the rectangle collides with an existing game object, and if so
		/// removes it from the map returning the removed object. Returns null if 
		/// no collision exists.
		/// </summary>
		/// <param name="rectangle"></param>
		/// <returns></returns>
		public GameActor CheckHitAndRemove( LevelMap map, Rectangle rectangle, bool remove = true )
		{
			for ( int i = 0; i < map.ActorObjects.Count; ++i ) {
				GameActor actor = map.ActorObjects[i];
				if ( actor != this &&
					actor.BoundingBox.Intersects( rectangle ) ) {
					if ( remove )
						map.ActorObjects.RemoveAt( i );
					return actor;
				}
			}
			return null;
		}
	}
}
