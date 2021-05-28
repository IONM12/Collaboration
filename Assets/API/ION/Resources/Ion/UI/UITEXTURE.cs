

namespace Ion
{
	[System.Serializable]
	public class UITEXTURE
	{
		public TEXTURE Texture;
		public float2 Position;
		public float Size;
		public bool SizeToYRelative = true;

		public RECTANGLE Rectangle
		{
			get 
			{
				float x = Position.x * SCREEN.width * 0.001f;
				float y = Position.y * SCREEN.height * 0.001f;
				float h = Size * SCREEN.height * 0.001f;
				float w = h * Texture.width / Texture.height;

				if (!SizeToYRelative)
				{
					w = Size * SCREEN.width * 0.001f;
					h = w * Texture.height / Texture.width;
				}

				return new RECTANGLE(x, y, w, h);
			}
		}

		public UITEXTURE()
		{
		}
		public UITEXTURE(string path)
		{
			Texture = new TEXTURE(path);
			Position = new float2(0, 0);
			Size = 100;
		}

		public static implicit operator TEXTURE(UITEXTURE uiTexture)
		{
			return uiTexture.Texture;
		}
		public static implicit operator RECTANGLE(UITEXTURE uiTexture)
		{
			return uiTexture.Rectangle;
		}
		public static implicit operator UITEXTURE(string path)
		{
			return new UITEXTURE(path);
		}
	}
}