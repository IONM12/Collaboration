///////////////////////////////////////////////////////////////////////////////////////////////////////
/*
 * ██████████████████████████████████████████████████████████████████████████████
 * ██████████████████████████████████████████████████████████████████████████████
 * ███████████████████████▀█████████████████████████████▀████████████████████████
 * █████████████████████▀   '▀████████████████████████▀   '▀█████████████████████
 * ███████████████████▀        '▀███████████████████▀        '▀██████████████████
 * █████████████████▀             '▀██████████████▀             '▀███████████████
 * ███████████████▀                  '▀█████████▀                  '▀████████████
 * █████████████▀      ▄             ▄████████▀                       '▀█████████
 * ███████████▀      ▄███▄,        ▄████▀▀▀▀▀      ▄█▄,                  '▀██████
 * █████████▀      ▄████████▄,   ▄███▀           ▄██████▄,                  '▀███
 * ███████▀        '▀██████████▄████    I O N   ▐██████████▄,                ▄███
 * █████▀             '▀███████████▌     API     █████████████▄,           ▄█████
 * ███▀                  '▀████████▀	  #     ███▀ '▀██████████▄       ▄███████
 * ████▄,                   '▀███▀          ▄▄███▀      '▀██████▀      ▄█████████
 * ███████▄,                   ▀      ▄████████▀           '▀█▀      ▄███████████
 * ██████████▄,                     ▄████████▀                     ▄█████████████
 * █████████████▄,                ▄████████████▄,                ▄███████████████
 * ████████████████▄,           ▄█████████████████▄,           ▄█████████████████
 * ███████████████████▄,      ▄██████████████████████▄,      ▄███████████████████
 * ██████████████████████▄, ▄███████████████████████████▄, ▄█████████████████████
 * ██████████████████████████████████████████████████████████████████████████████
 * ██████████████████████████████████████████████████████████████████████████████
 *
 * ----------------------------------------------------------------------
 * Copyright (C) M-12 technology Incorporated - All Rights Reserved.
 * ----------------------------------------------------------------------
 *
 * NOTICE:  All information contained herein is, and remains
 * the property of M-12 technology Incorporated and its suppliers.
 * The intellectual and technical concepts contained
 * herein are proprietary to M-12 Technology Incorporated
 * and its suppliers and may be covered by U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from M-12 technology Incorporated.
 * 
 * Website  : http://www.m12.technology
 *
 * Facebook : https://www.facebook.com/m12.technology
 * 
 * Twitter  : https://twitter.com/ION_CODE
 * 
 * Youtube  : https://www.youtube.com/user/TheVersio/
 * 
 * E-mail   : m12.software.technology@gmail.com
 * 
 * Developer : ION
 * 
 * ----------------------------------------------------------------------
 * Copyright (C) M-12 technology Incorporated - All Rights Reserved.
 * ----------------------------------------------------------------------
 */
///////////////////////////////////////////////////////////////////////////////////////////////////////
using Unity;
using UnityEngine;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public class UI
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		static float2 Position = new float2(0, 0);
		static float Size = 1;
		//----------------------------------------------------------------------------------------------------
		public static int depth
		{
			get { return GUI.depth; }
			set { GUI.depth = value; }
		}
		//----------------------------------------------------------------------------------------------------
		public static float2 Center
		{
			get { return new float2(SCREEN.width * 0.5f, SCREEN.height * 0.5f); }
		}
		//----------------------------------------------------------------------------------------------------
		public static float Width
		{
			get { return SCREEN.width; }
		}
		//----------------------------------------------------------------------------------------------------
		public static float Height
		{
			get { return SCREEN.height; }
		}
		//----------------------------------------------------------------------------------------------------
		public static float Aspect
		{
			get { return SCREEN.width / SCREEN.height; }
		}
		//----------------------------------------------------------------------------------------------------
		public static COLOR Color
		{
			set { GUI.color = value; }
		}
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public static void DrawTexture(UITEXTURE uiTexture)
		{
			GUI.DrawTexture(uiTexture.Rectangle, uiTexture.Texture);
		}
		//====================================================================================================
		public static void DrawTexture(UIBACKGROUND uiTexture)
		{
			GUI.DrawTexture(uiTexture.Rectangle, uiTexture.Texture);
		}
		//====================================================================================================
		public static void DrawTexture(UIBAR uiTexture)
		{
			GUI.DrawTexture(uiTexture.Rectangle, uiTexture.Texture);
		}
		//====================================================================================================
		public static void DrawTexture(RECTANGLE rectangle, TEXTURE texture)
		{
			GUI.DrawTexture(rectangle, texture);
		}
		//====================================================================================================
		public static void DrawTexture(RECTANGLE rectangle, TEXARRAY texture)
		{
			GUI.DrawTexture(rectangle, texture);
		}
		//====================================================================================================
		public static void DrawTexture(TEXTURE texture)
		{
			GUI.DrawTexture(new RECTANGLE(0, 0, SCREEN.width, SCREEN.height), texture);
		}
		//====================================================================================================
		public static void DrawTexture(TEXARRAY texture)
		{
			GUI.DrawTexture(new RECTANGLE(0, 0, SCREEN.width, SCREEN.height), texture);
		}
		//====================================================================================================
		public static void DrawTextureWithTexCoords(RECTANGLE rectangle, TEXTURE texture, RECTANGLE texcoord)
		{
			GUI.DrawTextureWithTexCoords(rectangle, texture, texcoord);
		}
		//====================================================================================================
		public static void DrawTexture(float x, float y, float width, TEXTURE texture)
		{
			float height = width * texture.height / texture.width;

			var rectangle = new RECTANGLE(x, y, width, height);

			GUI.DrawTexture(rectangle, texture);
		}
		//====================================================================================================
		public static void Label(RECTANGLE rectangle, string text)
		{
			GUI.Label(rectangle, text);
		}
		//====================================================================================================
		public static void Label(RECTANGLE rectangle, string text, GUIStyle style)
		{
			GUI.Label(rectangle, text, style);
		}
		//====================================================================================================
		public static RECTANGLE GetCenterRectangle(float size, TEXTURE texture)
		{
			float s = size * MATH.min(UI.Width / texture.width, UI.Height / texture.height);

			float width = s * texture.width;
			float height = s * texture.height;
			float x = Center.x - width / 2;
			float y = Center.y - height / 2;

			var rectangle = new RECTANGLE(x, y, width, height);

			return rectangle;
		}
		//====================================================================================================
		public static RECTANGLE GetTransformRectangle(RECTANGLE rectangle)
		{
			var transformRectangle = new RECTANGLE(Size * rectangle.x + Position.x, Size * rectangle.y + Position.y, Size * rectangle.width, Size * rectangle.height);

			return transformRectangle;
		}
		//====================================================================================================
		public static void SetMatrix()
		{
			Position = float2.zero;
			Size = 1;
		}
		//====================================================================================================
		public static void SetMatrix(float2 position, float size)
		{
			Position = position;
			Size = size;
		}
		//====================================================================================================
		public static void DrawImage(RECTANGLE rectangle, TEXTURE image)
		{
			DrawTexture(rectangle, image);

		}
		//====================================================================================================
		public static void SetViewport(RECTANGLE rectangle)
		{
			GUI.BeginGroup(rectangle);
		}
		//====================================================================================================
		public static void SetViewport()
		{
			GUI.EndGroup();
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
