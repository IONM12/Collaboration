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
	public struct COLOR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public Color Color;
		//----------------------------------------------------------------------------------------------------
		public float r
		{
			get { return Color.r; }
			set { Color.r = value; }
		}
		//----------------------------------------------------------------------------------------------------
		public float g
		{
			get { return Color.g; }
			set { Color.g = value; }
		}
		//----------------------------------------------------------------------------------------------------
		public float b
		{
			get { return Color.b; }
			set { Color.b = value; }
		}
		//----------------------------------------------------------------------------------------------------
		public float a
		{
			get { return Color.a; }
			set { Color.a = value; }
		}
		//----------------------------------------------------------------------------------------------------
		static public COLOR white { get { return new COLOR(1, 1, 1); } }
		static public COLOR black { get { return new COLOR(0, 0, 0); } }
		static public COLOR yellow { get { return new COLOR(1, 1, 0); } }
		static public COLOR red { get { return new COLOR(1, 0, 0); } }
		static public COLOR green { get { return new COLOR(0, 1, 0); } }
		static public COLOR blue { get { return new COLOR(0, 0, 1); } }
		static public COLOR grey { get { return new COLOR(0.5f, 0.5f, 0.5f); } }
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public COLOR(float r, float g, float b)
		{
			Color = new Color(r, g, b, 1);
		}
		//====================================================================================================
		public COLOR(float r, float g, float b, float a)
		{
			Color = new Color(r, g, b, a);
		}
		//====================================================================================================
		internal COLOR(Color color)
		{
			Color = color;
		}
		//====================================================================================================
		public static COLOR operator *(COLOR a, float x)
		{
			return new COLOR(a.r * x, a.g * x, a.b * x, a.a * x);
		}
		//====================================================================================================
		public static COLOR operator +(COLOR a, COLOR b)
		{
			return new COLOR(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
		}
		//====================================================================================================
		public static implicit operator Color(COLOR color)
		{
			return color.Color;
		}
		//====================================================================================================
		public static implicit operator COLOR(Color color)
		{
			return new COLOR(color);
		}
		//====================================================================================================
		public static implicit operator COLOR(float4 value)
		{
			return new COLOR(value.x, value.y, value.z, value.w);
		}
		//====================================================================================================
		public static implicit operator float4(COLOR color)
		{
			return new float4(color.r, color.g, color.b, color.a);
		}
		//====================================================================================================
		public static implicit operator COLOR((float r, float g, float b, float a) color)
		{
			return new COLOR(color.r, color.g, color.b, color.a);
		}
		//====================================================================================================
		public static implicit operator (float r, float g, float b, float a) (COLOR color)
		{
			return (color.r, color.g, color.b, color.a);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
