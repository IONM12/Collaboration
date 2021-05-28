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
	public class SHADER
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public string Name;
		//---------------------------------------------------------------------------------------------
		string Path;
		//---------------------------------------------------------------------------------------------
		internal Shader Shader;
		internal MATERIAL Material;
		//---------------------------------------------------------------------------------------------
		bool RandomWriteTargetFlag = false;
		//---------------------------------------------------------------------------------------------
		public int CallCount = 0;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public SHADER(string path)
		{
			Name = System.IO.Path.GetFileName(path);
			Path = path;

		}
		//-----------------------------------------------------------------------------------------------------
		public void Load()
		{
			if (Material == null)
			{
				Shader = Resources.Load<Shader>(Path);
				if (Shader == null)
				{
					Debug.LogError("ERROR : Shader cannot load , Name : " + Name + " , Path : " + Path);
				}
				else
				{
					Material = new MATERIAL(this);
				}
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public void LoadShader()
		{
			if (Shader == null)
			{
				Shader = Resources.Load<Shader>(Path);
				if (Shader == null)
				{
					Debug.Log("ERROR : Shader cannot load , Name : " + Name + " , Path : " + Path);
				}
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public bool Blit()
		{
			Load();
			var rt = GRAPHICS.GetRenderTarget();
			GRAPHICS.Blit(null, Material);
			GRAPHICS.SetRenderTarget(rt);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool Blit(RENDERTEXTURE destination)
		{
			Load();
			var rt = GRAPHICS.GetRenderTarget();
			GRAPHICS.Blit(destination, Material);
			GRAPHICS.SetRenderTarget(rt);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawMeshNow(MESH mesh)
		{
			Load();
			GRAPHICS.DrawMeshNow(mesh, Material);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawMeshNow(RENDERTEXTURE renderTexture, MESH mesh)
		{
			Load();
			var rt = GRAPHICS.GetRenderTarget();
			GRAPHICS.SetRenderTarget(renderTexture);
			GRAPHICS.DrawMeshNow(mesh, Material);
			GRAPHICS.SetRenderTarget(rt);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawTriangles(int vertexCount)
		{
			Load();
			GRAPHICS.DrawTriangles(Material, vertexCount);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawLines(int vertexCount)
		{
			Load();
			GRAPHICS.DrawLines(Material, vertexCount);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawPoints(int vertexCount)
		{
			Load();
			GRAPHICS.DrawPoints(Material, vertexCount);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawTriangles(RENDERTEXTURE renderTexture, int vertexCount)
		{
			Load();
			var rt = GRAPHICS.GetRenderTarget();
			GRAPHICS.SetRenderTarget(renderTexture);
			GRAPHICS.DrawTriangles(Material, vertexCount);
			GRAPHICS.SetRenderTarget(rt);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawLines(RENDERTEXTURE renderTexture, int vertexCount)
		{
			Load();
			var rt = GRAPHICS.GetRenderTarget();
			GRAPHICS.SetRenderTarget(renderTexture);
			GRAPHICS.DrawLines(Material, vertexCount);
			GRAPHICS.SetRenderTarget(rt);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public bool DrawPoints(RENDERTEXTURE renderTexture, int vertexCount)
		{
			Load();
			var rt = GRAPHICS.GetRenderTarget();
			GRAPHICS.SetRenderTarget(renderTexture);
			GRAPHICS.DrawPoints(Material, vertexCount);
			GRAPHICS.SetRenderTarget(rt);
			Call();

			return true;
		}
		//-----------------------------------------------------------------------------------------------------
		public void SetRandomWriteTarget(int index, RENDERTEXTURE texture)
		{
			Load();
			UnityEngine.Graphics.SetRandomWriteTarget(index, texture);
			RandomWriteTargetFlag = true;
		}
		//-----------------------------------------------------------------------------------------------------
//		public void SetRandomWriteTarget(int index, COMPUTEBUFFER buffer)
//		{
//			Load();
//			Graphics.SetRandomWriteTarget(index, buffer);
//			RandomWriteTargetFlag = true;
//		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetInt(string name, int value)
		{
			Load();
			Material.SetInt(name, value);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetFloat(string name, float value)
		{
			Load();
			Material.SetFloat(name, value);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetVector(string name, float2 vector)
		{
			Load();
			Material.SetVector(name, vector);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetVector(string name, float3 vector)
		{
			Load();
			Material.SetVector(name, vector);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetVector(string name, float4 vector)
		{
			Load();
			Material.SetVector(name, vector);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetMatrix(string name, float4x4 matrix)
		{
			Load();
			Material.SetMatrix(name, matrix);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetTexture(string name, TEXTURE texture)
		{
			Load();
			Material.SetTexture(name, texture);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetTexture(string name, TEXARRAY texArray)
		{
			Load();
			Material.SetTexture(name, texArray);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetBuffer(string name, BUFFER buffer)
		{
			Load();
			Material.SetBuffer(name, buffer);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetArray(string name, BUFFER buffer)
		{
			Load();
			Material.SetBuffer(name, buffer);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public SHADER SetColor(string name, COLOR color)
		{
			Load();
			Material.SetColor(name, color);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		void Call()
		{
			CallCount++;
			if (RandomWriteTargetFlag) ClearRandomWriteTargets();
		}
		//-----------------------------------------------------------------------------------------------------
		void ClearRandomWriteTargets()
		{
			UnityEngine.Graphics.ClearRandomWriteTargets();
		}
		//-----------------------------------------------------------------------------------------------------
		public static implicit operator Shader(SHADER shader)
		{
			if (shader == null) return null;
			return shader.Shader;
		}
		//-----------------------------------------------------------------------------------------------------
		public static implicit operator SHADER(string fileName)
		{
			return new SHADER(fileName);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
