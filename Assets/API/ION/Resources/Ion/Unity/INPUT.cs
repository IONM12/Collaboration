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
using Ion;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public class INPUT
	{

		//====================================================================================================
		// ■ 
		//====================================================================================================
		public static float3 MousePosition
		{
			get { return Input.mousePosition; }
		}
		//====================================================================================================
		public static bool GetKeyDown(string name)
		{
			return Input.GetKeyDown(name);
		}
		//====================================================================================================
		public static bool GetKeyUp(string name)
		{
			return Input.GetKeyUp(name);
		}
		//====================================================================================================
		public static bool GetKeyDown(KEYCODE key)
		{
			return Input.GetKeyDown((UnityEngine.KeyCode)key);
		}
		//====================================================================================================
		public static bool GetKeyUp(KEYCODE key)
		{
			return Input.GetKeyUp((UnityEngine.KeyCode)key);
		}
		//====================================================================================================
		public static bool GetKey(KEYCODE key)
		{
			return Input.GetKey((UnityEngine.KeyCode)key);
		}
		//====================================================================================================
		public static bool GetMouseButtonDown(int button)
		{
			return Input.GetMouseButtonDown(button);
		}
		//====================================================================================================
		public static bool GetMouseButtonUp(int button)
		{
			return Input.GetMouseButtonUp(button);
		}
		//====================================================================================================
		public static float MouseScrollDeltaX()
		{
			return Input.mouseScrollDelta.x;
		}
		//====================================================================================================
		public static float MouseScrollDeltaY()
		{
			return Input.mouseScrollDelta.y;
		}
		//====================================================================================================


	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
