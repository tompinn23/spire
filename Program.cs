using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace spire
{
    public class Program {
        static void Main(string[] args) {
            var nativeWindowSettings = new NativeWindowSettings() {
                Size = new Vector2i(800, 600),
                Title = "spire"
            };
            using (Game window = new Game(GameWindowSettings.Default, nativeWindowSettings)) {
                window.Run();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
