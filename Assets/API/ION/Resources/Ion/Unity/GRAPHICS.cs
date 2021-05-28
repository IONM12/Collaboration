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
	public static partial class GRAPHICS
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		static Mesh[] PointProceduralMesh;
		static Mesh[] LineProceduralMesh;
		static Mesh[] TriangleProceduralMesh;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		public static void ClearRenderTexture(RENDERTEXTURE renderTexture, COLOR color)
		{
			var clearMaterial = new MATERIAL(new SHADER("Ion/Shader/ClearShader"));

			clearMaterial.SetColor("Color", color);
			Blit(renderTexture, clearMaterial);
		}
		//====================================================================================================
		public static void ClearScreen(COLOR color)
		{
			var clearMaterial = new MATERIAL(new SHADER("Ion/Shader/ClearShader"));

			clearMaterial.SetColor("Color", color);
			Blit(null, clearMaterial);
		}
		//====================================================================================================
		public static void Blit(TEXTURE source, RENDERTEXTURE destination)
		{
			var rt = GetRenderTarget();
			UnityEngine.Graphics.Blit(source, destination);
			SetRenderTarget(rt);
		}
		//====================================================================================================
		public static void Blit(RENDERTEXTURE destination, MATERIAL material)
		{
			var rt = GetRenderTarget();
			UnityEngine.Graphics.Blit(null, destination, material);
			SetRenderTarget(rt);
		}
		//====================================================================================================
		public static void DrawMesh(MESH mesh, MATERIAL material)
		{
			material.SetPass();
			UnityEngine.Graphics.DrawMesh(mesh, float4x4.identity, material, 0);
		}
		//====================================================================================================
		public static void DrawMeshNow(MESH mesh, MATERIAL material)
		{
			material.SetPass();
			UnityEngine.Graphics.DrawMeshNow(mesh, float4x4.identity);
		}
		//====================================================================================================
		public static void DrawPoints(MATERIAL material, int count)
		{
			CreatePointProceduralMesh();

			material.SetFloat("Reciproc", 1.0f / 2048);

			float offset = 0;
			for (int i = 0; i < (count >> 15); i++)
			{
				material.SetFloat("Offset", offset);
				material.SetPass();
				UnityEngine.Graphics.DrawMeshNow(PointProceduralMesh[15], float4x4.identity);
				offset += 2 << 15;
			}

			for (int i = 14; i >= 0; i--)
			{
				if ((count & (1 << i)) > 0)
				{
					material.SetFloat("Offset", offset);
					material.SetPass();
					UnityEngine.Graphics.DrawMeshNow(PointProceduralMesh[i], float4x4.identity);
					offset += 2 << i;
				}
			}
		}
		//====================================================================================================
		public static void DrawLines(MATERIAL material, int count)
		{
			CreateLineProceduralMesh();

			count = count >> 1;
	
			material.SetFloat("Reciproc", 1.0f / 2048);

			float offset = 0;
			for (int i = 0; i < (count >> 15); i++)
			{
				material.SetFloat("Offset", offset);
				material.SetPass();
				UnityEngine.Graphics.DrawMeshNow(LineProceduralMesh[15], float4x4.identity);
				offset += 2 * (2 << 15);
			}

			for (int i = 14; i >= 0; i--)
			{
				if ((count & (1 << i)) > 0)
				{
					material.SetFloat("Offset", offset);
					material.SetPass();
					UnityEngine.Graphics.DrawMeshNow(LineProceduralMesh[i], float4x4.identity);
					offset += 2 * (2 << i);
				}
			}
		}
		//====================================================================================================
		public static void DrawTriangles(MATERIAL material, int count)
		{
			CreateTriangleProceduralMesh();

			count = count / 3;

			material.SetFloat("Reciproc", 1.0f / 2048);

			float offset = 0;
			for (int i = 0; i < (count >> 15); i++)
			{
				material.SetFloat("Offset", offset);
				material.SetPass();
				UnityEngine.Graphics.DrawMeshNow(TriangleProceduralMesh[15], float4x4.identity);
				offset += 3 * (2 << 15);
			}

			for (int i = 14; i >= 0; i--)
			{
				if ((count & (1 << i)) > 0)
				{
					material.SetFloat("Offset", offset);
					material.SetPass();
					UnityEngine.Graphics.DrawMeshNow(TriangleProceduralMesh[i], float4x4.identity);
					offset += 3 * (2 << i);
				}
			}
		}
		//====================================================================================================
		public static void SetRenderTarget(RENDERTEXTURE renderTexture)
		{
			RENDERTEXTURE.active = renderTexture;
		}
		//====================================================================================================
		public static RENDERTEXTURE GetRenderTarget()
		{
			return RENDERTEXTURE.active;
		}
		//====================================================================================================
		//CREATE PROCEDURAL POINT MESH ARRAY
		//====================================================================================================
		public static void CreatePointProceduralMesh()
		{
			if (PointProceduralMesh == null)
			{
				PointProceduralMesh = new Mesh[16];

				for (int i = 0; i < 16; i++)
				{
					PointProceduralMesh[i] = new Mesh();

					int count = 1 << i;

					var vertexArray = new Vector3[count];
					var indexArray = new int[count];

					for (int j = 0; j < count; j++)
					{
						vertexArray[j] = new Vector3(j, j, j);
						indexArray[j] = j;
					}

					PointProceduralMesh[i].vertices = vertexArray;
					PointProceduralMesh[i].SetIndices(indexArray, MeshTopology.Points, 0);
				}
			}
		}
		//====================================================================================================
		//CREATE PROCEDURAL LINE MESH ARRAY
		//====================================================================================================
		public static void CreateLineProceduralMesh()
		{
			if (LineProceduralMesh == null)
			{
				LineProceduralMesh = new Mesh[16];

				for (int i = 0; i < 16; i++)
				{
					var mesh = new Mesh();
					mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
					LineProceduralMesh[i] = mesh;

					int count = 2 * (1 << i);
					
					var vertexArray = new Vector3[count];
					var indexArray = new int[count];

					for (int j = 0; j < count; j++)
					{
						vertexArray[j] = new Vector3(j, j, j);
						indexArray[j] = j;
					}

					LineProceduralMesh[i].vertices = vertexArray;
					LineProceduralMesh[i].SetIndices(indexArray, MeshTopology.Lines, 0);
				}
			}
		}
		//====================================================================================================
		//CREATE PROCEDURAL TRIANGLE MESH ARRAY
		//====================================================================================================
		public static void CreateTriangleProceduralMesh()
		{
			if (TriangleProceduralMesh == null)
			{
				TriangleProceduralMesh = new Mesh[16];

				for (int i = 0; i < 16; i++)
				{
					var mesh = new Mesh();
					mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
					TriangleProceduralMesh[i] = mesh;

					int count = 3 * (1 << i);

					var vertexArray = new Vector3[count];
					var indexArray = new int[count];

					for (int j = 0; j < count; j++)
					{
						vertexArray[j] = new Vector3(j, j, j);
						indexArray[j] = j;
					}

					TriangleProceduralMesh[i].vertices = vertexArray;
					TriangleProceduralMesh[i].SetIndices(indexArray, MeshTopology.Triangles, 0);
				}
			}
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
