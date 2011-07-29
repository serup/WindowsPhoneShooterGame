// Projectile.cs
//Using declarations
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shooter
{
    /// <summary>
    /// Adds interactions between the player and enemies
    /// </summary>
    class Projectile
    {
        // Image representing the Projectile
        public Texture2D Texture;

        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;

        // State of the Projectile
        public bool Active;

        // The amount of damage the projectile can inflict to an enemy
        public int Damage;

        // Represents the viewable boundary of the game
        Viewport viewport;

        // Get the width of the projectile ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the projectile ship
        public int Height
        {
            get { return Texture.Height; }
        }

        // Determines how fast the projectile moves
        float projectileMoveSpeed;

        /// <summary>
        /// Initialize the projectiles
        /// </summary>
        /// <param name="viewport">Defines the window dimensions of a render-target surface onto which a 3D volume projects.</param>
        /// <param name="texture">Represents a 2D grid of pixels.</param>
        /// <param name="position">Projectiles position on screen</param>
        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;
            Active = true;
            Damage = 9;
            projectileMoveSpeed = 10.0f;
        }
        /// <summary>
        /// Decide how far to move the projectiles and when they should be considered “dead”.
        /// </summary>
        public void Update()
        {
            // Projectiles always move to the right
            Position.X += projectileMoveSpeed;

            // Deactivate the bullet if it goes out of screen
            if (Position.X + Texture.Width / 2 > viewport.Width)
                Active = false;

        }
        /// <summary>
        /// Draw the projectiles on screen
        /// </summary>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }


    }
}
