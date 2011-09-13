using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace egp_story
{
	public class AnimatedSprite
	{
		private Texture2D _texture;
		private Rectangle _sourceRectangle;
		private float _fps;
		private int _increment;
		private float _totalElapsed;
		public bool Finished { get; set; }

		public AnimatedSprite( Texture2D texture, int spriteCount, int speed )
		{
			_texture = texture;
			_fps = ( float ) 1 / speed;

			_increment = _texture.Width / spriteCount;
			_sourceRectangle = new Rectangle( 0, 0, _increment, _texture.Height );
		}

		public void Update( GameTime gameTime )
		{
			if ( !Playing )
				return;

			_totalElapsed += ( float ) gameTime.ElapsedGameTime.TotalSeconds;
			if ( _totalElapsed > _fps ) {

				_sourceRectangle.X = ( _sourceRectangle.X + _increment ) % ( _texture.Width );

				_totalElapsed -= _fps;

				// restarted.
				if ( _sourceRectangle.X == 0 ) {
					Finished = true;
				}
			}
		}

		public void Draw( SpriteBatch spriteBatch, Vector2 position, GameTime gameTime, SpriteEffects effects )
		{
			spriteBatch.Draw( _texture, position, _sourceRectangle, Color.White, 0f, Vector2.Zero, 1f,
				effects, 0 );
		}

		/// <summary>
		/// True if the sprite is being animated, false otherwise
		/// </summary>
		public bool Playing { get; set; }

		/// <summary>
		/// Resets the animation
		/// </summary>
		public void Reset( )
		{
			_totalElapsed = 0;
			_sourceRectangle.X = 0;

			Finished = false;
		}
	}
}
