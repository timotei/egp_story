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

		public AnimatedSprite CurrentAnimation { get; set; }

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
			// for the moment
			_attacking = true;

			KeyboardState keys = Keyboard.GetState( );
			Vector2 deplacement = Vector2.Zero;
			if ( keys.IsKeyDown2( Keys.Left ) ) {
				StopAnimation( );

				FacingDirection = CardinalDirection.WEST;
				CurrentAnimation = _attacking ? AttackEastAnim : null;
				deplacement.X = -10;
			}
			else if ( keys.IsKeyDown2( Keys.Right ) ) {
				StopAnimation( );

				FacingDirection = CardinalDirection.EAST;
				CurrentAnimation = _attacking ? AttackEastAnim : null;
				deplacement.X = 10;
			}
			else if ( keys.IsKeyDown2( Keys.Down ) ) {
				StopAnimation( );

				FacingDirection = CardinalDirection.SOUTH;
				CurrentAnimation = _attacking ? AttackSouthAnim : null;
				deplacement.Y = 10;
			}
			else if ( keys.IsKeyDown2( Keys.Up ) ) {
				StopAnimation( );

				FacingDirection = CardinalDirection.NORTH;
				CurrentAnimation = _attacking ? AttackNorthAnim : null;
				deplacement.Y = -10;
			}

			if ( CurrentAnimation != null ) {
				CurrentAnimation.Playing = true;

				CurrentAnimation.Update( gameTime );
			}

			Position += deplacement;
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
