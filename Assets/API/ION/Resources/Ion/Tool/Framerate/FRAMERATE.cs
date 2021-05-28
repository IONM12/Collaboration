///////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
///////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace MagicTools
{
	[ExecuteInEditMode]
	public class FRAMERATE : MonoBehaviour
	{
		//*****************************************************************************************************	
		public bool BlackFont = false;
		//-----------------------------------------------------------------------------------------------------
		public Vector2 Position = new Vector2(50, 100);
		//-----------------------------------------------------------------------------------------------------
		Texture NumbersTexture;
		//-----------------------------------------------------------------------------------------------------
		float updateInterval = 0.5f;
		//-----------------------------------------------------------------------------------------------------
		float timeleft; // Left time for current interval
		float fps = 0;
		//---------------------------------------------------------------------------------------------
		bool Initialization;
		//*****************************************************************************************************

		//---------------------------------------------------------------------------------------------
		void OnEnable()
		{
			Initialization = true;
			Start();
		}
		//-----------------------------------------------------------------------------------------------------
		void Start()
		{
			if (Initialization)
			{
				Initialization = false;
				timeleft = updateInterval;

				if (BlackFont)
				{
					NumbersTexture = Resources.Load<Texture>("Ion/Tool/Framerate/Texture/NumbersTextureBlack") as Texture;
				}
				else
				{
					NumbersTexture = Resources.Load<Texture>("Ion/Tool/Framerate/Texture/NumbersTexture") as Texture;
					//NumbersTexture = Resources.Load<Texture>("Framerate/Texture/NumbersTextureRed") as Texture;

				}

				Time.maximumDeltaTime = 10;
			}
		}
        //-----------------------------------------------------------------------------------------------------
        void Update()
        {
			timeleft -= Time.deltaTime;

			if (timeleft <= 0.0)
			{
				fps = 1.0f / Time.deltaTime;
				timeleft = updateInterval;
			}

			if (fps > 10) fps = (int)fps;
			else fps = (float)System.Math.Round(fps, 2);
		}
		//-----------------------------------------------------------------------------------------------------
		void OnDrawGizmos()
        {

#if UNITY_EDITOR
			UnityEditor.Handles.BeginGUI();

			var color = Color.white;
            GUI.color = color;
            GUI.Label(new Rect(30,30, 100, 100), "Fps : " + fps.ToString());

			UnityEditor.Handles.EndGUI();
#endif

		}
        //-----------------------------------------------------------------------------------------------------
        void OnGUI()
		{
			GUI.depth = 0;
			Fps();
		}
		//-----------------------------------------------------------------------------------------------------
		public void DrawNumber(int number, Rect area)
		{
			int n = number;
			int count = 0;
			do
			{
				n = n / 10;
				count++;
			}
			while (n > 0);

			for (int i = count; i > 0; i--)
			{
				n = number % 10;
				number = number / 10;
				UnityEngine.GUI.DrawTextureWithTexCoords(Coord(new Rect((area.x + i * area.width), area.y, area.width, area.height)), NumbersTexture, new Rect(0.1f * n, 0, 0.1f, 1.0f));
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public void DrawNumber(int number, int digitCount, Rect area)
		{
			int n = number;
			int count = 0;
			do
			{
				n = n / 10;
				count++;
			}
			while (n > 0);

			for (int i = 0; i < digitCount - count; i++)
			{
				UnityEngine.GUI.DrawTextureWithTexCoords(Coord(new Rect(area.x + i * area.width, area.y, area.width, area.height)), NumbersTexture, new Rect(0.0f, 0, 0.1f, 1.0f));
			}

			for (int i = count; i > 0; i--)
			{
				n = number % 10;
				number = number / 10;
				UnityEngine.GUI.DrawTextureWithTexCoords(Coord(new Rect(area.x + (i + digitCount - count - 1) * area.width, area.y, area.width, area.height)), NumbersTexture, new Rect(0.1f * n, 0, 0.1f, 1.0f));
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public static Rect Coord(Rect rect)
		{
			float width = (float)Screen.width;
			float height = (float)Screen.height;

			Rect result = new Rect();
			result.x = (rect.x * width) / 1600;
			result.y = (rect.y * height) / 900;
			result.width = (rect.width * width) / 1600;
			result.height = (rect.height * height) / 900;

			return result;
		}
		//-----------------------------------------------------------------------------------------------------
		void Fps()
		{
			GUI.DrawTexture(Coord(new Rect(Position.x, Position.y, 3 * 24, 50)), Texture2D.whiteTexture);

			//Print Fps
			DrawNumber((int)fps, 3, new Rect(Position.x, Position.y, 24, 50));
		}
		//-----------------------------------------------------------------------------------------------------
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
