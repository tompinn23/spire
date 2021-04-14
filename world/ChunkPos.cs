using System;
using spire.renderer;

namespace spire.world {
    public class ChunkPos {
        private readonly int x;
        private readonly int z;

        public ChunkPos(int x, int z) {
            this.x = x;
            this.z = z;
        }

        public int getX() {
            return x;
        }

        public int getZ() {
            return z;
        }

        public override bool Equals(object? obj) {
            ChunkPos other = obj as ChunkPos;
            if (other != null) {
                return this.x == other.x && this.z == other.z;
            }
            return false;
        }

        public override string ToString() {
            return String.Format("ChunkPos X: {0}, Z: {1}", x, z);
        }
    }
}