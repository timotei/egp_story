using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace egp_story
{
	public class AnimatedSprite
	{
		private Texture2D _texture;
		private Rectangle _sourceRectangle;
		private int _count;
		private int _speed;
		private int _increment;
		private TimeSpan _currentGameTime;

		public AnimatedSprite( )
		{
			_texture = Assets.SpriteAnim;
			_count = 10;
			_speed = 100;

			_increment = _texture.Width / _count;
			_sourceRectangle = new Rectangle( 0, 0, _increment, _texture.Height );
		}

		public void Update( GameTime gameTime )
		{
			if ( ( gameTime.TotalGameTime - _currentGameTime ).Milliseconds > _speed ) {

				_sourceRectangle.X = ( _sourceRectangle.X + _increment ) % ( _texture.Width );
				Console.WriteLine( _sourceRectangle.X );

				_currentGameTime = gameTime.TotalGameTime;
			}
		}

		public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
		{
			spriteBatch.Draw( _texture, Vector2.Zero, _sourceRectangle, Color.White );
		}
	}
}
