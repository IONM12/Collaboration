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
using System;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public enum TEXTUREFORMAT
	{
		ARGBFloat = TextureFormat.RGBAFloat,
		ARGB32 = TextureFormat.ARGB32,
		RFloat = TextureFormat.RFloat,
		RGFloat = TextureFormat.RGFloat,
	}

	[Serializable]
	public class TEXTURE2D
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public Texture2D Texture;
		//----------------------------------------------------------------------------------------------------
		static public TEXTURE whiteTexture
		{
			get
			{
				return new TEXTURE2D(Texture2D.whiteTexture);
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public int width
		{
			get
			{
				return Texture.width;
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public int height
		{
			get
			{
				return Texture.height;
			}
		}
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public TEXTURE2D(string fileName)
		{
			Texture = Resources.Load<Texture2D>(fileName);

			if (Texture == null)
			{
				Debug.Log("ERROR, Cant load texture file : " + fileName);
			}
		}
		//====================================================================================================
		public TEXTURE2D(int width, int height, TEXTUREFORMAT textureFormat = TEXTUREFORMAT.ARGBFloat)
		{
			Texture = new Texture2D(width, height, (TextureFormat) textureFormat, false);
		}
		//====================================================================================================
		internal TEXTURE2D(Texture2D texture)
		{
			Texture = texture;
		}
		//====================================================================================================
		public COLOR[] GetColors()
		{
			var colorArray = Texture.GetPixels();

			var array = new COLOR[colorArray.Length];
			for (int i = 0; i < colorArray.Length; i++)
			{
				array[i] = colorArray[i];
			}

			return array;
		}
		//====================================================================================================
		public void SetColors(COLOR[] colorArray)
		{
			var array = new Color[colorArray.Length];
			for (int i = 0; i < colorArray.Length; i++)
			{
				array[i] = colorArray[i];
			}

			Texture.SetPixels(array);
			Texture.Apply();
		}
		//====================================================================================================
		public void SetPointFilter()
		{
			Texture.filterMode = FilterMode.Point;
			Texture.Apply();
		}
		//====================================================================================================
		public void SetBilinearFilter()
		{
			Texture.filterMode = FilterMode.Bilinear;
			Texture.Apply();
		}
		//====================================================================================================
		public void SetTrilinealFilter()
		{
			Texture.filterMode = FilterMode.Trilinear;
			Texture.Apply();
		}
		//====================================================================================================
		public COLOR GetPixel(int x, int y)
		{
			return new COLOR(Texture.GetPixel(x, y));
		}
		//====================================================================================================
		public void SetPixel(int x, int y, COLOR color)
		{
			Texture.SetPixel(x, y, color);
		}
		//====================================================================================================
		public COLOR[,] GetPixels()
		{
			var array = Texture.GetPixels();
			int width = Texture.width;
			int height = Texture.height;

			var colorArray = new COLOR[width, height];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					colorArray[x, y] = array[i++];
				}
			}

			return colorArray;
		}
		//====================================================================================================
		public void SetPixels(COLOR[,] colorArray)
		{
			int width = Texture.width;
			int height = Texture.height;

			if (colorArray.GetLength(0) != width || colorArray.GetLength(1) != height)
			{
				Debug.Log("Color array dimension is not equal with texture array dimension !");
				return;
			}

			var array = new Color[width * height];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					array[i++] = colorArray[x, y];
				}
			}

			Texture.SetPixels(array);
			Texture.Apply();
		}
		//====================================================================================================
		public void SetPixels(RECTANGLE rectangle, COLOR[,] colorArray)
		{
			int width = (int)rectangle.width;
			int height = (int)rectangle.height;

			if (colorArray.GetLength(0) != width || colorArray.GetLength(1) != height)
			{
				Debug.Log("Color array dimension is not equal with texture array dimension !");
				return;
			}

			var array = new Color[width * height];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					array[i++] = colorArray[x, y];
				}
			}

			Texture.SetPixels((int)rectangle.x, (int)rectangle.y, (int)rectangle.width, (int)rectangle.height, array);
			Texture.Apply();
		}
		//====================================================================================================
		public void Apply()
		{
			Texture.Apply();
		}
		//====================================================================================================
		public static implicit operator Texture2D(TEXTURE2D texture)
		{
			if (texture == null) return null;

			return texture.Texture;
		}
		//====================================================================================================
		public static implicit operator TEXTURE2D(Texture2D texture)
		{
			return new TEXTURE2D(texture);
		}
		//====================================================================================================
		public static implicit operator TEXTURE(TEXTURE2D texture)
		{
			if (texture == null) return null;

			return new TEXTURE(texture.Texture);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
