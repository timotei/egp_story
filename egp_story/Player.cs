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
using Microsoft.Xna.Framework.Input;

namespace egp_story
{
	public class Player : IUpdateable, IDrawable
	{
		public Vector2 Position { get; set; }
		private bool _attacking;

		public CardinalDirection FacingDirection { get; set; }

		public AnimatedSprite AttackNorthAnim { get; set; }
		public AnimatedSprite AttackSouthAnim { get; set; }
		public AnimatedSprite AttackEastAnim { get; set; }

		public AnimatedSprite WalkNorthAnim { get; set; }
		public AnimatedSprite WalkSouthAnim { get; set; }
		public AnimatedSprite WalkEastAnim { get; set; }

		public AnimatedSprite CurrentAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="initialFacingDirection"></param>
		/// <param name="attackAnims">The order of the animations: North, South, East</param>
		/// <param name="walkAnims">The order of the animations: North, South, East</param>
		public Player( CardinalDirection initialFacingDirection, AnimatedSprite[] attackAnims,
			AnimatedSprite[] walkAnims )
		{
			AttackNorthAnim = attackAnims[0];
			AttackSouthAnim = attackAnims[1];
			AttackEastAnim = attackAnims[2];

			WalkNorthAnim = walkAnims[0];
			WalkSouthAnim = walkAnims[1];
			WalkEastAnim = walkAnims[2];

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
		}

		#endregion

		public void Update( GameTime gameTime )
		{
			KeyboardState keys = Keyboard.GetState( );
			if ( !_attacking && keys.IsKeyDown2( Keys.Space ) ) {
				_attacking = true;
				ReplaceCurrentAnimation( );
			}
			else if ( _attacking && CurrentAnimation.Finished ) {
				_attacking = false;
				ReplaceCurrentAnimation( );
			}

			// cannot move while attacking
			if ( !_attacking ) {
				Vector2 deplacement = Vector2.Zero;
				if ( keys.IsKeyDown( Keys.Left ) ) {
					FacingDirection = CardinalDirection.WEST;
					deplacement.X = -3;

					ReplaceCurrentAnimation( );
				}
				else if ( keys.IsKeyDown( Keys.Right ) ) {
					FacingDirection = CardinalDirection.EAST;
					deplacement.X = 3;

					ReplaceCurrentAnimation( );
				}
				else if ( keys.IsKeyDown( Keys.Down ) ) {
					FacingDirection = CardinalDirection.SOUTH;
					deplacement.Y = 3;

					ReplaceCurrentAnimation( );
				}
				else if ( keys.IsKeyDown( Keys.Up ) ) {
					FacingDirection = CardinalDirection.NORTH;
					deplacement.Y = -3;

					ReplaceCurrentAnimation( );
				}

				Position += deplacement;
			}

			if ( CurrentAnimation != null ) {
				CurrentAnimation.Update( gameTime );
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

	public enum CardinalDirection
	{
		NORTH = 1,
		SOUTH = 2,
		WEST = 4,
		EAST = 8
	}
}
