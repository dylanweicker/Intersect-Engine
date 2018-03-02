﻿using Intersect.Client.Classes.Core;
using IntersectClientExtras.GenericClasses;
using IntersectClientExtras.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Intersect_Client_MonoGame.Classes.SFML.Graphics
{
    public class MonoRenderTexture : GameRenderTexture
    {
        private GraphicsDevice mGraphicsDevice;
        private int mHeight;
        private RenderTarget2D mRenderTexture;
        private int mWidth;

        public MonoRenderTexture(GraphicsDevice graphicsDevice, int width, int height) : base(width, height)
        {
            mRenderTexture = new RenderTarget2D(
                graphicsDevice, width, height, true,
                graphicsDevice.PresentationParameters.BackBufferFormat,
                graphicsDevice.PresentationParameters.DepthStencilFormat,
                graphicsDevice.PresentationParameters.MultiSampleCount,
                RenderTargetUsage.PreserveContents
            );
            mGraphicsDevice = graphicsDevice;
            mWidth = width;
            mHeight = height;
        }

        public override string GetName()
        {
            return "";
        }

        public override int GetWidth()
        {
            return mWidth;
        }

        public override int GetHeight()
        {
            return mHeight;
        }

        public override object GetTexture()
        {
            return mRenderTexture;
        }

        public override Color GetPixel(int x1, int y1)
        {
            Microsoft.Xna.Framework.Color[] pixel = new Microsoft.Xna.Framework.Color[1];
            mRenderTexture.GetData(0, new Rectangle(x1, y1, 1, 1), pixel, 0, 1);
            return new Color(pixel[0].A, pixel[0].R, pixel[0].G, pixel[0].B);
        }

        public override bool Begin()
        {
            return true;
        }

        public override void End()
        {
            ((MonoRenderer) GameGraphics.Renderer).EndSpriteBatch();
        }

        public override void Clear(Color color)
        {
            mGraphicsDevice.SetRenderTarget(mRenderTexture);
            mGraphicsDevice.Clear(MonoRenderer.ConvertColor(color));
            mGraphicsDevice.SetRenderTarget(null);
        }
    }
}