using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daggers.Client.Data;
using SlimDX;
using SlimDX.Direct3D11;
using Buffer = SlimDX.Direct3D11.Buffer;

namespace Daggers.Client.Rendering.Terrain
{
    class TerrainRenderer
    {
        public TerrainRenderer(Renderer renderer)
        {
            this.renderer = renderer;
            shader = renderer.Load("triangle.fx");
        }

        public void Render()
        {
            var context = renderer.Device.ImmediateContext;

            context.InputAssembler.InputLayout = shader.InputLayout;
            context.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;

            var vertices = new DataStream(12 * 3, true, true);

            vertices.Write(new Vector3(0.0f, 0.5f, 0.5f));
            vertices.Write(new Vector3(0.5f, -0.5f, 0.5f));
            vertices.Write(new Vector3(-0.5f, -0.5f, 0.5f));
            vertices.Position = 0;

            var vertexBuffer = new Buffer(renderer.Device, vertices, 12 * 3, ResourceUsage.Default, BindFlags.VertexBuffer, CpuAccessFlags.None, ResourceOptionFlags.None, 0);

            context.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, 12, 0));

            context.VertexShader.Set(shader.VertexShader);
            context.PixelShader.Set(shader.PixelShader);

            context.Draw(3, 0);
        }

        private readonly Renderer renderer;
        private readonly Shader shader;
    }
}
