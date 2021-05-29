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
using System.Collections.Generic;
///////////////////////////////////////////////////////////////////////////////////////////////////////
using Ion;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Collaboration
{
	public class POINTER : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		TEXTURE Pointer1Texture = "Pointer/Texture/Pointer1Texture";
		TEXTURE Pointer2Texture = "Pointer/Texture/Pointer2Texture";
		TEXTURE Pointer3Texture = "Pointer/Texture/Pointer3Texture";
		TEXTURE Pointer4Texture = "Pointer/Texture/Pointer4Texture";
		TEXTURE Pointer5Texture = "Pointer/Texture/Pointer5Texture";
		TEXTURE Pointer6Texture = "Pointer/Texture/Pointer6Texture";
		//----------------------------------------------------------------------------------------------------
		TEXTURE ClickTexture = "Pointer/Texture/ClickTexture";
		//----------------------------------------------------------------------------------------------------
		TEXTURE[] TextureArray;
		COLOR[] ColorArray;
		//----------------------------------------------------------------------------------------------------
		float2[] PositionArray;
		float2[] TargetPositionArray;
		//----------------------------------------------------------------------------------------------------
		float[] SpeedArray;
		//----------------------------------------------------------------------------------------------------
		float ClickSize = 0;
		float ClickSpeed = 1;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			PositionArray = new float2[6];
			for (int i = 0; i < 6; i++)
			{
				PositionArray[i] = new float2(RANDOM.Float(0, SCREEN.width), RANDOM.Float(0, SCREEN.height));
			}

			TargetPositionArray = new float2[6];
			for (int i = 0; i < 6; i++)
			{
				TargetPositionArray[i] = new float2(RANDOM.Float(0, SCREEN.width), RANDOM.Float(0, SCREEN.height));
			}

			SpeedArray = new float[6];
			for (int i = 0; i < 6; i++)
			{
				SpeedArray[i] = RANDOM.Float(0.5f, 100);
			}


			TextureArray = new TEXTURE[6];
			TextureArray[0] = Pointer1Texture;
			TextureArray[1] = Pointer2Texture;
			TextureArray[2] = Pointer3Texture;
			TextureArray[3] = Pointer4Texture;
			TextureArray[4] = Pointer5Texture;
			TextureArray[5] = Pointer6Texture;


			ColorArray = new COLOR[6];
			ColorArray[0] = new COLOR(1, 0, 0, 1);
			ColorArray[1] = new COLOR(0, 1, 0, 1);
			ColorArray[2] = new COLOR(0, 0, 1, 1);
			ColorArray[3] = new COLOR(1, 1, 0, 1);
			ColorArray[4] = new COLOR(0, 1, 1, 1);
			ColorArray[5] = new COLOR(1, 0, 1, 1);
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			for (int i = 0; i < 6; i++)
			{
				var position = PositionArray[i];
				var speed = SpeedArray[i];
				var target = TargetPositionArray[i];

				position += MATH.normalize(target - position) * speed * TIME.deltaTime;

				if (MATH.distance(position, target) < 1.0f)
				{
					TargetPositionArray[i] = new float2(RANDOM.Float(0, SCREEN.width), RANDOM.Float(0, SCREEN.height));
				}

				PositionArray[i] = position;
			}

			ClickSize += ClickSpeed * TIME.deltaTime;
			if (ClickSize > 1) ClickSize = 0;

		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			UI.depth = 0;

			var clickPosition = PositionArray[0];
			var clickColor = ColorArray[0];
			clickColor.a = 0.5f;
			UI.Color = clickColor;

			float size = 200 * ClickSize;
			UI.DrawTexture(new RECTANGLE(clickPosition.x + 50 - size * 0.5f, clickPosition.y + 25 - size * 0.5f, size, size), ClickTexture);


			for (int i = 0; i < 6; i++)
			{
				var position = PositionArray[i];
				var texture = TextureArray[i];
				var color = ColorArray[i];

				UI.Color = color;
				UI.DrawTexture(new RECTANGLE(position.x, position.y, 100, 100), texture);
			}

			UI.Color = COLOR.white;
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
