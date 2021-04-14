using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.GL;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace spire {
    public class Game : GameWindow {
        public Game(GameWindowSettings windowSettings, NativeWindowSettings nativeWindow) :
        base(windowSettings, nativeWindow) {
        }

        protected override void OnUpdateFrame(FrameEventArgs args) {
            if (KeyboardState.IsKeyDown(Keys.Escape)) {
                Close();
            }
            base.OnUpdateFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e) {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
    }
}