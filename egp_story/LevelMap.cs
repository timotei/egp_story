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
namespace egp_story
{
	public class LevelMap : IDrawable, IUpdateable
	{
		public Texture2D Image { get; private set; }
		public Texture2D Mask { get; private set; }
		public Color[] MaskData { get; private set; }
		public Vector2 SpawnPoint { get; private set; }
		public Player ThePlayer { get; private set; }
		public Enemy RedEnemy { get; private set; }

		public Vector2 Position { get; set; }
		public Color Tint { get; set; }

		public List<GameActor> ActorObjects { get; set; }

		public LevelMap( Player player, Enemy redEnemy, Texture2D image, Texture2D mask )
		{
			ActorObjects = new List<GameActor>( );
			Image = image;
			Mask = mask;

			ThePlayer = player;
			RedEnemy = redEnemy;

			MaskData = new Color[mask.Width * mask.Height];
			Mask.GetData<Color>( MaskData );
			CalculateSpawnPoints( );
			player.Position = SpawnPoint;

			Tint = Color.White;
		}

		protected void CalculateSpawnPoints( )
		{
			for ( int i = 0; i < MaskData.Length; ++i ) {
				if ( MaskData[i] == Color.Black ) {
					SpawnPoint = new Vector2( i % Mask.Width, i / Mask.Width );
				}
				else if ( MaskData[i] == Color.Red ) {
					Enemy clone =  new Enemy( RedEnemy );
					clone.Position = new Vector2( i % Mask.Width, i / Mask.Width );
					ActorObjects.Add( clone );
				}
			}
		}

		public Color GetTexel( int row, int col )
		{
			return MaskData[row * Mask.Width + col];
		}

		public Color GetTexel( float row, float col )
		{
			return MaskData[( int ) row * Mask.Width + ( int ) col];
		}

		#region IDrawable Members

		public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Image, Position, Tint );
			if ( ThePlayer != null )
				ThePlayer.Draw( spriteBatch, gameTime );

			foreach ( var actorObj in ActorObjects ) {
				actorObj.Draw( spriteBatch, gameTime );
			}
		}

		#endregion

		/// <summary>
		/// Returns true if the rectangle's bounds are on valid position (walkable)
		/// </summary>
		/// <param name="rectangle">The rectangle to check the bounds for</param>
		/// <returns></returns>
		public bool CheckRectangleBounds( Rectangle rectangle )
		{
			if ( !Mask.Bounds.Contains( rectangle ) )
				return false;

			rectangle.Width--;
			rectangle.Height--;
			// upper left
			Color texel = GetTexel( rectangle.Y, rectangle.X );
			if ( texel == Color.White || texel == Color.Black ) {

				// upper right
				texel = GetTexel( rectangle.Y, rectangle.Right );
				if ( texel == Color.White || texel == Color.Black ) {

					// bottom right
					texel = GetTexel( rectangle.Bottom, rectangle.Right );
					if ( texel == Color.White || texel == Color.Black ) {

						// bottom left
						texel = GetTexel( rectangle.Bottom, rectangle.X );
						if ( texel == Color.White || texel == Color.Black ) {
							return true;
						}
					}
				}
			}

			return false;
		}

		#region IUpdateable Members

		public void Update( GameTime gameTime )
		{
			if ( ThePlayer != null )
				ThePlayer.Update( this, gameTime );

			foreach ( var actorObject in ActorObjects ) {
				actorObject.Update( this, gameTime );
			}
		}

		#endregion
	}
}
