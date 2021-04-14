using C5;
using OpenTK.Graphics.OpenGL4;
using spire.world;

namespace spire.renderer {
    public class ChunkRenderer {
        public IChunk chunk;
        private ChunkPos pos;

        private HashedLinkedList<KeyValuePair<BlockPos, BlockModel>> modelCache;

        public ChunkRenderer(ChunkPos pos, IChunk chunk) {
            this.chunk = chunk;
            this.pos = pos;
        }



        public void render(long ticks, float partialTicks) {
            
        }
        
        
    }
}