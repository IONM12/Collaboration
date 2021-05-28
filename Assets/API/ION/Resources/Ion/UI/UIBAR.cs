

namespace Ion
{
	[System.Serializable]
	public class UIBAR
	{
		public TEXTURE Texture;
		public float2 Position;
		public float Size;
		public float Width;

		public RECTANGLE Rectangle
		{
			get 
			{
				float x = Position.x * SCREEN.width * 0.001f;
				float y = Position.y * SCREEN.height * 0.001f;
				float h = Size * SCREEN.height * 0.001f;
				float w = Width * SCREEN.width * 0.001f;

				return new RECTANGLE(x, y, w, h);
			}
		}

		public UIBAR()
		{
		}
		public UIBAR(string path)
		{
			Texture = new TEXTURE(path);
			Position = 0;
			Size = 100;
		}

		public static implicit operator TEXTURE(UIBAR uiTexture)
		{
			return uiTexture.Texture;
		}
		public static implicit operator RECTANGLE(UIBAR uiTexture)
		{
			return uiTexture.Rectangle;
		}
		public static implicit operator UIBAR(string path)
		{
			return new UIBAR(path);
		}
	}
}