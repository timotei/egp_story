
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace egp_story
{
	public interface Menu
	{
		void Update( GameTime gameTime );
		void Draw( SpriteBatch spriteBatch, GameTime gameTime );
	}
}
