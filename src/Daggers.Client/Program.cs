using System;
using System.Windows.Forms;
using Daggers.Client.Rendering;
using SlimDX.Windows;

namespace Daggers.Client
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            var program = new Program();
            MessagePump.Run(program.form, program.MainLoop);
            Application.Exit();
        }

        public Program()
        {
            form = new Form {Width = 1024, Height = 768, Text = "Daggers"};
            renderer = new Renderer(form);
        }

        public void MainLoop()
        {
            renderer.Render();
        }

        private Form form;
        private Renderer renderer;
    }
}
