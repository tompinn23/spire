using spire.world;

namespace spire.blocks {
    public abstract class AbstractBlock {
        private string registryName;

        public AbstractBlock() {
            
        }


        public AbstractBlock setRegistryName(string name) {
            this.registryName = name;
            return this;
        }

        public abstract void onBlockPlaced(BlockPos pos, World world);
    }
}