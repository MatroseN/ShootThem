using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
// To get the camera
using MonoGame.Extended;
// Then you need a viewport adapter
using MonoGame.Extended.ViewportAdapters;

namespace ShootThem {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private OrthographicCamera camera;
        private CameraMovement _cameraMovement;
        private TiledMap map;
        private TiledMapRenderer _mapRenderer;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            map = Content.Load<TiledMap>("test");
            _mapRenderer = new TiledMapRenderer(GraphicsDevice, map);

            var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, 400, 400);
            camera = new OrthographicCamera(viewportadapter);
            camera.LookAt(new Vector2(0, 0));
            _cameraMovement = new CameraMovement();

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _mapRenderer.Update(gameTime);

            _cameraMovement.update(camera, gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), samplerState: new SamplerState { Filter = TextureFilter.Point});

            _mapRenderer.Draw(camera.GetViewMatrix());

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
