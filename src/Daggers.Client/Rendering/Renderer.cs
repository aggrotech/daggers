using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daggers.Client.Data;
using Daggers.Client.Rendering.Terrain;
using SlimDX;
using SlimDX.D3DCompiler;
using SlimDX.DXGI;
using SlimDX.Direct3D11;
using Device = SlimDX.Direct3D11.Device;
using Resource = SlimDX.Direct3D11.Resource;

namespace Daggers.Client.Rendering
{
    class Renderer : IArchiveLoader<Shader>
    {
        public Renderer(Form form)
        {
            var description = new SwapChainDescription
            {
                BufferCount = 1,
                Usage = Usage.RenderTargetOutput,
                OutputHandle = form.Handle,
                IsWindowed = true,
                ModeDescription = new ModeDescription(0, 0, new Rational(60, 1), Format.R8G8B8A8_UNorm),
                SampleDescription = new SampleDescription(1, 0),
                Flags = SwapChainFlags.AllowModeSwitch,
                SwapEffect = SwapEffect.Discard
            };

            Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, description, out device, out swapChain);

            viewport = new Viewport(0.0f, 0.0f, form.Width, form.Height);
            device.ImmediateContext.Rasterizer.SetViewports(viewport);

            using (var resource = Resource.FromSwapChain<Texture2D>(swapChain, 0))
            {
                backbufferRtv = new RenderTargetView(device, resource);
            }

            device.ImmediateContext.OutputMerger.SetTargets(backbufferRtv);

            terrainRenderer = new TerrainRenderer(this);
        }

        public void Render()
        {
            device.ImmediateContext.ClearRenderTargetView(backbufferRtv, System.Drawing.Color.Black);

            terrainRenderer.Render();

            swapChain.Present(0, PresentFlags.None);
        }

        public Shader Load(string filepath)
        {
            var vsbc = ShaderBytecode.CompileFromFile(filepath, "VShader", "vs_4_0", ShaderFlags.Debug, EffectFlags.None);
            var psbc = ShaderBytecode.CompileFromFile(filepath, "PShader", "ps_4_0", ShaderFlags.Debug, EffectFlags.None);

            var vs = new VertexShader(device, vsbc);
            var ps = new PixelShader(device, psbc);

            // Hard hack, todo: remove.
            var elements = new[] {new InputElement("POSITION", 0, Format.R32G32B32_Float, 0)};

            var il = new InputLayout(device, vsbc, elements);

            return new Shader(vs, ps, il);
        }

        public Device Device { get { return device; } }

        private readonly TerrainRenderer terrainRenderer;

        private readonly Device device;
        private readonly SwapChain swapChain;
        private readonly Viewport viewport;
        private readonly RenderTargetView backbufferRtv;
    }
}
