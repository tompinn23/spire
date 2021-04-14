namespace spire.world {
    public class BlockPos {
        private readonly long x;
        private readonly long y;
        private readonly long z;

        public BlockPos(long x, long y, long z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public BlockPos add(BlockPos other) {
            return new BlockPos(this.x + other.x, this.y + other.y, this.z + other.z);
        }

        public override bool Equals(object? obj) {
            BlockPos other = obj as BlockPos;
            if (other != null) {
                return this.x == other.x &&
                       this.y == other.y &&
                       this.z == other.z;
            }
            return false;
        }
    }
}