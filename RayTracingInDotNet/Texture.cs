using SkiaSharp;
using System;
using System.Runtime.InteropServices;

namespace RayTracingInDotNet
{
	record Texture(int Width, int Height, int Channels, byte[] Pixels)
	{
		public static Texture LoadTexture(string filename)
		{
			// Load the texture in normal host memory.
			int width, height, channels;

            using var image = SKBitmap.Decode(filename);
			width = image.Width;
			height = image.Height;
			channels = 4;

			var pixels = MemoryMarshal.AsBytes(image.GetPixelSpan()).ToArray();

			return new Texture(width, height, channels, pixels);
		}

		public static Texture LoadTexture(ReadOnlySpan<byte> data)
		{
			// Load the texture in normal host memory.
			int width, height, channels;

            using var image = SKBitmap.Decode(data);
			width = image.Width;
			height = image.Height;
			channels = 4;

            var pixels = MemoryMarshal.AsBytes(image.GetPixelSpan()).ToArray();

            return new Texture(width, height, channels, pixels);
		}

		public static Texture LoadTexture(byte[] pixels, int width, int height)
		{
			int channels = 4;

			return new Texture(width, height, channels, pixels);
		}
	}
}
