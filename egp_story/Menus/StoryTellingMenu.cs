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
using egp_story.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace egp_story.Menus
{
	public class StoryTellingMenu : Menu
	{
		private StoryLevel _nextLevel;
		private Menu _nextMenu;

		private int _currentIndex = 0;
		private int _targetStory;

		public StoryTellingMenu( Game game, int story, StoryLevel nextLevel, Menu nextMenu )
			: base( game )
		{
			_nextLevel = nextLevel;
			_nextMenu = nextMenu;

			_targetStory = story;
		}

		public override void Update( GameTime gameTime )
		{
			if ( Keyboard.GetState( ).IsKeyDown2( Keys.Enter ) ) {
				if ( _currentIndex < Assets.Stories[_targetStory].Length - 1 ) {
					++_currentIndex;
				}
				else {
					SelectedLevel = _nextLevel;
					SelectedMenu = _nextMenu;
				}
			}
		}

		public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( Assets.Stories[_targetStory][_currentIndex], Vector2.Zero );
		}
	}
}