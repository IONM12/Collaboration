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
using System.Linq;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	[Serializable]
	public class TEXTURE2DARRAY
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public Texture2DArray TextureArray;
		//----------------------------------------------------------------------------------------------------
		public int width
		{
			get { return TextureArray.width; }
		}
		//-----------------------------------------------------------------------------------------------------
		public int height
		{
			get { return TextureArray.height; }
		}
		//-----------------------------------------------------------------------------------------------------
		public int depth
		{
			get { return TextureArray.depth; }
		}
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public TEXTURE2DARRAY(int width, int height, int depth)
		{
			TextureArray = new Texture2DArray(width, height, depth, TextureFormat.ARGB32, true);

		}
		//====================================================================================================
		private TEXTURE2DARRAY(Texture2DArray texture)
		{
			TextureArray = texture;
		}
		//====================================================================================================
		public void CopyTexture(TEXTURE2D texture, int element)
		{
			var colorArray = texture.GetColors();

			SetColors(colorArray, element);
		}
		//====================================================================================================
		public void SetColors(COLOR[] colorArray, int arrayElement)
		{
			var array = new Color[colorArray.Length];
			for (int i = 0; i < colorArray.Length; i++)
			{
				array[i] = colorArray[i];
			}

			TextureArray.SetPixels(array, arrayElement);
			TextureArray.Apply();
		}
		//====================================================================================================
		public COLOR[] GetColors(int arrayElement)
		{
			var colorArray = TextureArray.GetPixels(arrayElement);
			return colorArray.Cast<COLOR>().ToArray();
		}
		//====================================================================================================
		public void SetPointFilter()
		{
			TextureArray.filterMode = FilterMode.Point;
			TextureArray.Apply();
		}
		//====================================================================================================
		public void SetBilinearFilter()
		{
			TextureArray.filterMode = FilterMode.Bilinear;
			TextureArray.Apply();
		}
		//====================================================================================================
		public void SetTrilinealFilter()
		{
			TextureArray.filterMode = FilterMode.Trilinear;
			TextureArray.Apply();
		}
		//====================================================================================================
		public COLOR[,] GetPixels(int arrayElement)
		{
			var array = TextureArray.GetPixels(arrayElement);
			int width = TextureArray.width;
			int height = TextureArray.height;

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
		public void SetPixels(COLOR[,] colorArray, int arrayElement)
		{
			int width = TextureArray.width;
			int height = TextureArray.height;

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

			TextureArray.SetPixels(array, arrayElement);
			TextureArray.Apply();
		}
		//====================================================================================================
		public void Apply()
		{
			TextureArray.Apply();
		}
		//====================================================================================================
		public static implicit operator Texture2DArray(TEXTURE2DARRAY texture)
		{
			if (texture == null) return null;

			return texture.TextureArray;
		}
		//====================================================================================================
		public static implicit operator TEXTURE2DARRAY(Texture2DArray texture)
		{
			return new TEXTURE2DARRAY(texture);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
