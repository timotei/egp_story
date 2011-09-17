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
namespace egp_story.Levels
{
	public abstract class StoryLevel : IUpdateable, IDrawable
	{
		public bool LevelEnded { get; protected set; }
		public bool Won { get; protected set; }
		public LevelMap LevelMap { get; protected set; }
		public Game Game { get; protected set; }
		public int LevelIndex { get; protected set; }

		protected bool _gameEnded;

		public StoryLevel( Game game, int index )
		{
			Game = game;
			LevelIndex = index;
		}

		#region IUpdateable Members

		public virtual void Update( GameTime gameTime )
		{
			if ( LevelMap == null ) {
				LevelEnded = true;
			}
			else {
				if ( !_gameEnded ) {
					LevelMap.Update( gameTime );

					if ( LevelMap.ActorObjects.Count == 0 ||
						LevelMap.ThePlayer.IsDead ) {
						_gameEnded = true;

						Won = !LevelMap.ThePlayer.IsDead;
						if ( Won ) {
							LevelMap.Tint = Color.Yellow;
						}
						else {
							LevelMap.Tint = Color.IndianRed;
						}
					}

					if ( Keyboard.GetState( ).IsKeyDown2( Keys.Back ) ) {
						// go back to menu
						LevelEnded = true;
					}
				}
				else {
					if ( Keyboard.GetState( ).IsKeyDown2( Keys.Enter ) ) {
						// go back to menu
						LevelEnded = true;
					}
				}
			}
		}

		#endregion

		#region IDrawable Members

		public virtual void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			if ( LevelMap == null )
				return;

			LevelMap.Draw( spriteBatch, gameTime );

			if ( _gameEnded ) {
				spriteBatch.Draw( Won ? Assets.WinMessage : Assets.LoseMessage, new Vector2( 0, 100 ) );
			}
		}

		#endregion
	}
}
