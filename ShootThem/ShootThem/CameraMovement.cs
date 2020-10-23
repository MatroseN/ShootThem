using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace ShootThem {
    public class CameraMovement {
        public CameraMovement() {
        }
        public void update(OrthographicCamera camera, GameTime gameTime) {
            move(camera, gameTime);
        }
        private void move(OrthographicCamera camera, GameTime gameTime) {
            float deltaTime = gameTime.GetElapsedSeconds();
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up)) {
                camera.Move(new Vector2(0, -speed) * deltaTime);
            }

            if (keyboardState.IsKeyDown(Keys.Down)) {
                camera.Move(new Vector2(0, +speed) * deltaTime);
            }

            if (keyboardState.IsKeyDown(Keys.Left)) {
                camera.Move(new Vector2(-speed, 0) * deltaTime);
            }

            if (keyboardState.IsKeyDown(Keys.Right)) {
                camera.Move(new Vector2(+speed, 0) * deltaTime);
            }
        }

        private const float speed = 300;
    }
}