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
using System.Collections.Generic;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	[Serializable]
	public class MESH
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public Mesh Mesh;
		//-----------------------------------------------------------------------------------------------------
		public float3[] vertices
		{
			get { return GetVertices(); }
			set { SetVertices(value); }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3[] normals
		{
			get { return GetNormals(); }
			set { SetNormals(value); }
		}
		//-----------------------------------------------------------------------------------------------------
		public float2[] uv
		{
			get { return GetUV(); }
			set { SetUV(value); }
		}
		//-----------------------------------------------------------------------------------------------------
		public int[] triangles
		{
			get { return GetIndices(); }
			set { SetTriangleIndices(value); }
		}
		//-----------------------------------------------------------------------------------------------------
		public (float3 center, float3 size) bounds
		{
			get { return GetBounds(); }
			set { SetBounds(value.center, value.size); }
		}
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public MESH()
		{			
		}
		//====================================================================================================
		void Init()
		{
			if (Mesh == null)
			{
				Mesh = new Mesh();
				Mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
			}
		}
		//====================================================================================================
		public MESH(Mesh mesh)
		{
			Mesh = mesh;
		}
		//====================================================================================================
		public void Clear()
		{
			Init();
			Mesh.Clear();
		}
		//====================================================================================================
		public (float3 center, float3 size) GetBounds()
		{
			Init();
			var bounds = Mesh.bounds;

			return (bounds.center, bounds.size);
		}
		//====================================================================================================
		public void SetBounds(float3 center, float3 size)
		{
			Init();
			Mesh.bounds = new Bounds(center, size);
		}
		//====================================================================================================
		public void RecalculateNormals()
		{
			Init();
			Mesh.RecalculateNormals();
		}
		//====================================================================================================
		public float3[] GetVertices()
		{
			Init();
			var vertices = Mesh.vertices;
			int count = vertices.Length;
			var vertexArray = new float3[count];
			for (int i = 0; i < count; i++)
			{
				vertexArray[i] = vertices[i];
			}

			return vertexArray;
		}
		//====================================================================================================
		public void SetColors(COLOR[] colorArray)
		{
			Init();
			int count = colorArray.Length;
			
			var colors = new Color[count];

			for (int i = 0; i < count; i++)
			{
				colors[i] = colorArray[i];
			}

			Mesh.colors = colors;
		}
		//====================================================================================================
		public void SetVertexBuffer<T>(T[] array) where T : struct
		{
			Init();
			Mesh.SetVertexBufferData<T>(array, 0, 0, array.Length);
		}
		//====================================================================================================
		public void SetVertexBuffer<T>(List<T> list) where T : struct
		{
			Init();
			Mesh.SetVertexBufferData<T>(list, 0, 0, list.Count);
		}
		//====================================================================================================
		public void SetVertices(float3[] vertexArray)
		{
			Init();
			int count = vertexArray.Length;
			var vertices = new Vector3[count];
			for (int i = 0; i < count; i++)
			{
				vertices[i] = vertexArray[i];
			}

			Mesh.vertices = vertices;
		}
		//====================================================================================================
		public float3[] GetNormals()
		{
			Init();
			var normals = Mesh.normals;
			int count = normals.Length;
			var normalArray = new float3[count];
			for (int i = 0; i < count; i++)
			{
				normalArray[i] = normals[i];
			}

			return normalArray;
		}
		//====================================================================================================
		public void SetNormals(float3[] normalArray)
		{
			Init();
			int count = normalArray.Length;
			var normals = new Vector3[count];
			for (int i = 0; i < count; i++)
			{
				normals[i] = normalArray[i];
			}

			Mesh.normals = normals;
		}
		//====================================================================================================
		public float2[] GetUV()
		{
			Init();
			var uvs = Mesh.uv;
			int count = uvs.Length;
			var uvArray = new float2[count];
			for (int i = 0; i < count; i++)
			{
				uvArray[i] = uvs[i];
			}
			return uvArray;
		}
		//====================================================================================================
		public void SetUV(float2[] uvArray)
		{
			Init();
			int count = uvArray.Length;
			var uvs = new Vector2[count];
			for (int i = 0; i < count; i++)
			{
				uvs[i] = uvArray[i];
			}

			Mesh.uv = uvs;
		}
		//====================================================================================================
		public int[] GetIndices()
		{
			Init();
			return Mesh.GetIndices(0);
		}
		//====================================================================================================
		public void SetPointIndices(int[] indexArray)
		{
			Init();
			Mesh.SetIndices(indexArray, MeshTopology.Points, 0);
		}
		//====================================================================================================
		public void SetLineIndices(int[] indexArray)
		{
			Init();
			Mesh.SetIndices(indexArray, MeshTopology.Lines, 0);
		}
		//====================================================================================================
		public void SetLineStripIndices(int[] indexArray)
		{
			Init();
			Mesh.SetIndices(indexArray, MeshTopology.LineStrip, 0);
		}
		//====================================================================================================
		public void SetTriangleIndices(int[] indexArray)
		{
			Init();
			Mesh.SetIndices(indexArray, MeshTopology.Triangles, 0);
		}
		//====================================================================================================
		public static implicit operator Mesh(MESH mesh)
		{
			if (mesh == null) return null;
			return mesh.Mesh;
		}
		//====================================================================================================
		public static implicit operator MESH(Mesh mesh)
		{
			if (mesh == null) return null;
			return new MESH(mesh);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
