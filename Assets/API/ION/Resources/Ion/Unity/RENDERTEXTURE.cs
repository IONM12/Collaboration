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
	public enum RENDERTEXTUREFORMAT
	{
		ARGBFloat = RenderTextureFormat.ARGBFloat,
		ARGB32 = RenderTextureFormat.ARGB32,
		RFloat = RenderTextureFormat.RFloat,
		R8 = RenderTextureFormat.R8,
		R16 = RenderTextureFormat.R16,
		RGFloat = RenderTextureFormat.RGFloat,
		RG32 = RenderTextureFormat.RG32,
		RG16 = RenderTextureFormat.RG16,
		RInt = RenderTextureFormat.RInt,
	}

	public class RENDERTEXTURE
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public RenderTexture RenderTexture;
		//-----------------------------------------------------------------------------------------------------
		RENDERTEXTUREFORMAT Format;
		//-----------------------------------------------------------------------------------------------------
		public RENDERTEXTUREFORMAT format
		{
			get { return Format; }
		}
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public RENDERTEXTURE(int width, int height, int depth, RENDERTEXTUREFORMAT format)
		{
			Format = format;
			RenderTexture = new RenderTexture(width, height, depth, (RenderTextureFormat)format);
		}
		//====================================================================================================
		public void EnableRandomWrite()
		{
			RenderTexture.enableRandomWrite = true;
		}
		//====================================================================================================
		public void DisableRandomWrite()
		{
			RenderTexture.enableRandomWrite = false;
		}
		//====================================================================================================
		public void SetPointFilter()
		{
			RenderTexture.filterMode = FilterMode.Point;
		}
		//====================================================================================================
		public void SetBilinearFilter()
		{
			RenderTexture.filterMode = FilterMode.Bilinear;
		}
		//====================================================================================================
		public void SetTrilinearFilter()
		{
			RenderTexture.filterMode = FilterMode.Trilinear;
		}
		//====================================================================================================
		public int width
		{
			get
			{
				return RenderTexture.width;
			}
		}
		//====================================================================================================
		public int height
		{
			get
			{
				return RenderTexture.height;
			}
		}
		//====================================================================================================
		static public RENDERTEXTURE active
		{
			get
			{
				return new RENDERTEXTURE(RenderTexture.active);
			}
			set
			{
				RenderTexture.active = value;
			}
		}
		//====================================================================================================
		public RENDERTEXTURE(RenderTexture texture)
		{
			RenderTexture = texture;
		}
		//====================================================================================================
		public void Release()
		{
			RenderTexture.Release();
		}
		//====================================================================================================
		public void Create()
		{
			RenderTexture.Create();
		}
		//====================================================================================================
		public void Clear(COLOR color)
		{
			GRAPHICS.ClearRenderTexture(this, color);
		}
		//====================================================================================================
		public static implicit operator RenderTexture(RENDERTEXTURE texture)
		{
			if (texture == null) return null;
			return texture.RenderTexture;
		}
		//====================================================================================================
		public static implicit operator TEXTURE(RENDERTEXTURE texture)
		{
			if (texture == null) return null;
			return new TEXTURE(texture.RenderTexture);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
