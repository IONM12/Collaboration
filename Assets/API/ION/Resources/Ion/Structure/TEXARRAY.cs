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
using System;
///////////////////////////////////////////////////////////////////////////////////////////////////////
using Unity;
using UnityEngine;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	[Serializable]
	public partial class TEXARRAY
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		Color[] Array;
		//----------------------------------------------------------------------------------------------------
		bool Changed;
		bool[] ChangedArray;
		//----------------------------------------------------------------------------------------------------
		int Width = 2048;
		int Height;
		//----------------------------------------------------------------------------------------------------
		Texture2D Texture;
		//----------------------------------------------------------------------------------------------------
		public int Length;
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public TEXARRAY(int size)
		{
			Length = size;
			Height = 1 + size / Width;
			Texture = new Texture2D(Width, Height, TextureFormat.RGBAFloat, false);
			Texture.filterMode = FilterMode.Point;
			Array = new Color[Height * Width];

			Changed = true;
			ChangedArray = new bool[Height];
			
			for (int i = 0; i < Height; i++)
			{
				ChangedArray[i] = true;
			}
			
		}
		//====================================================================================================
		public void Set(float4[] array)
		{
			Texture.SetPixelData<float4>(array, 0);
			Texture.Apply();
		}
		//====================================================================================================
		public void Set(COLOR[] array)
		{
			Texture.SetPixelData<COLOR>(array, 0);
			Texture.Apply();
		}
		//====================================================================================================
		//feltolti a texturat a gpu-ba, azokat a sorokat amik valtoztak, az egymas utani sorokat egyben tolti fol
		//====================================================================================================
		void Apply()
		{
			if (Changed)
			{
				for (int i = 0; i < Height; i++)
				{
					ChangedArray[i] = false;
				}

				Changed = false;

				Texture.SetPixels(Array);
				Texture.Apply();
			}
		}
		//====================================================================================================
		public COLOR this[int i]
		{
			get
			{
				return Array[i];
			}
			set
			{
				Changed = true;
				ChangedArray[i >> 11] = true;
				Array[i] = value;
			}
		}
		//====================================================================================================
		public static implicit operator TEXARRAY(float4 value)
		{
			var texArray = new TEXARRAY(1);
			texArray[0] = value;
			return texArray;
		}
		//====================================================================================================
		public static implicit operator TEXARRAY(COLOR value)
		{
			var texArray = new TEXARRAY(1);
			texArray[0] = value;
			return texArray;
		}
		//====================================================================================================
		public static implicit operator Texture2D(TEXARRAY texArray)
		{
			texArray.Apply();
			return texArray.Texture;
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
