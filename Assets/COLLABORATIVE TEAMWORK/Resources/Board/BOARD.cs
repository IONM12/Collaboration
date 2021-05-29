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
	public class BOARD : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		TEXTURE BoardTexture = "Board/Texture/BoardTexture";
		TEXTURE BrushTexture = "Board/Texture/BrushTexture";
		//----------------------------------------------------------------------------------------------------
		SHADER AirBrushShader = "Board/Shader/AirBrushShader";
		//----------------------------------------------------------------------------------------------------
		RENDERTEXTURE DrawingRenderTexture;
		//----------------------------------------------------------------------------------------------------
		public float2 MousePosition;
		public float2 LastPosition;
		bool DrawingFlag = false;
		//----------------------------------------------------------------------------------------------------
		MESH RectangleMesh;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			DrawingRenderTexture = new RENDERTEXTURE((int)SCREEN.width - 450, (int)SCREEN.height - 100, 0, RENDERTEXTUREFORMAT.ARGB32);

			DrawingRenderTexture.Clear(new COLOR(0, 0, 0, 0));

			CreateRectangleMesh();
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
			var p = INPUT.MousePosition;
			MousePosition = new float2(p.x, SCREEN.height - p.y);

			if (SystemInput.GetMouseButtonDown(0))
			{
				DrawingFlag = true;
				LastPosition = MousePosition;
			}

			if (SystemInput.GetMouseButtonUp(0))
			{
				DrawingFlag = false;
			}


			if (DrawingFlag)
			{
				int loop = (int) MATH.distance(LastPosition, MousePosition);

				for (int i = 0; i < loop; i++)
				{
					var LocalPos = MATH.lerp(MousePosition, LastPosition, (float) i / loop);

					float width = DrawingRenderTexture.width;
					float height = DrawingRenderTexture.height;
					float2 position = new float2(-1 + 2 * (LocalPos.x - 225) / width, -1 + 2 * (LocalPos.y - 10) / height);
					var color = COLOR.black;

					AirBrushShader
					.SetTexture("SourceTexture", BrushTexture)
					.SetColor("Color", color)
					.SetVector("Position", position)
					.SetFloat("Aspect", (float)width / height)
					.SetFloat("Size", 0.01f)
					.DrawMeshNow(DrawingRenderTexture, RectangleMesh);
				}

				LastPosition = MousePosition;
			}
		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			UI.depth = 5;

			UI.DrawTexture(new RECTANGLE(225, 10, SCREEN.width - 450, SCREEN.height - 100), BoardTexture);

			UI.DrawTexture(new RECTANGLE(225, 10, SCREEN.width - 450, SCREEN.height - 100), DrawingRenderTexture);

			UI.Label(new RECTANGLE(400, 500, 500, 100), "mouse : " + MousePosition);
		}
		//====================================================================================================
		void CreateRectangleMesh()
		{
			var vertexArray = new float3[6];
			var indexArray = new int[6];

			vertexArray[0] = new float3(0, 0, 0);
			vertexArray[1] = new float3(1, 0, 0);
			vertexArray[2] = new float3(2, 0, 0);
			vertexArray[3] = new float3(3, 0, 0);
			vertexArray[4] = new float3(4, 0, 0);
			vertexArray[5] = new float3(5, 0, 0);

			indexArray[0] = 0;
			indexArray[1] = 1;
			indexArray[2] = 2;
			indexArray[3] = 3;
			indexArray[4] = 4;
			indexArray[5] = 5;

			RectangleMesh = new MESH();
			RectangleMesh.SetVertices(vertexArray);
			RectangleMesh.SetTriangleIndices(indexArray);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
