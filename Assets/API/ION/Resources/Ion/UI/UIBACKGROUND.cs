

namespace Ion
{
	[System.Serializable]
	public class UIBACKGROUND
	{
		public TEXTURE Texture;
		public float Position;
		public float Size;

		public RECTANGLE Rectangle
		{
			get 
			{
				float x = 0;
				float y = Position * SCREEN.height * 0.001f;
				float h = Size * SCREEN.height * 0.001f;
				float w = SCREEN.width;

				return new RECTANGLE(x, y, w, h);
			}
		}

		public UIBACKGROUND()
		{
		}
		public UIBACKGROUND(string path)
		{
			Texture = new TEXTURE(path);
			Position = 0;
			Size = 100;
		}

		public static implicit operator TEXTURE(UIBACKGROUND uiTexture)
		{
			return uiTexture.Texture;
		}
		public static implicit operator RECTANGLE(UIBACKGROUND uiTexture)
		{
			return uiTexture.Rectangle;
		}
		public static implicit operator UIBACKGROUND(string path)
		{
			return new UIBACKGROUND(path);
		}
	}
}