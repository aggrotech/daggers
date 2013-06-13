using SlimDX.Direct3D11;

namespace Daggers.Client.Data
{
    class Shader : IAsset
    {
        public Shader(VertexShader vs, PixelShader ps, InputLayout il)
        {
            VertexShader = vs;
            PixelShader = ps;
            InputLayout = il;
        }

        public VertexShader VertexShader { get; private set; }

        public PixelShader PixelShader { get; private set; }

        public InputLayout InputLayout { get; private set; }
    }
}
