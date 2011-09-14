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
	public class LevelMap : IDrawable
	{
		public Texture2D Image { get; private set; }
		public Texture2D Mask { get; private set; }
		public Color[] MaskData { get; private set; }
		public Vector2 SpawnPoint { get; private set; }

		public Vector2 Position { get; set; }

		public LevelMap( Texture2D image, Texture2D mask )
		{
			Image = image;
			Mask = mask;

			MaskData = new Color[mask.Width * mask.Height];
			Mask.GetData<Color>( MaskData );
			CalculateSpawnPoint( );
		}

		protected void CalculateSpawnPoint( )
		{
			for ( int i = 0; i < MaskData.Length; ++i ) {
				if ( MaskData[i] == Color.Black ) {
					SpawnPoint = new Vector2( i % Mask.Width, i / Mask.Width );
					return;
				}
			}
		}

		#region IDrawable Members

		public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Image, Position );
		}

		#endregion
	}
}
