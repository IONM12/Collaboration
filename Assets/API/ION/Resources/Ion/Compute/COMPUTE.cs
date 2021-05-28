///////////////////////////////////////////////////////////////////////////////////////////////////////
/******************************************************************************************************
 * 
 * ----------------------------------------------
 * M-12 technology Incorporated , [2012] - [2014]
 * ----------------------------------------------
 * 
 * NOTICE:  All information contained herein is, and remains
 * the property of M-12 technology Incorporated and its suppliers,
 * if any.  The intellectual and technical concepts contained
 * herein are proprietary to M-12 Technology Incorporated
 * and its suppliers and may be covered by U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from M-12 technology Incorporated.
 * 
 * Facebook : https://www.facebook.com/m12.technology
 * 
 * Email : m-12.software.technology@gmail.com
 * 
 * Web : www.m12technology.com
 * 
 * Developer : versION#
 * 
 * Date : 5 / 10 / 2014
 * 
 * ----------------------------------------------------------------------
 * Copyright (C) 2014 M-12 technology Incorporated - All Rights Reserved.
 * ----------------------------------------------------------------------
 * 
 *****************************************************************************************************/
///////////////////////////////////////////////////////////////////////////////////////////////////////
// Engine
///////////////////////////////////////////////////////////////////////////////////////////////////////
using MONOBEHAVIOUR = UnityEngine.MonoBehaviour;
using TEXTURE = UnityEngine.Texture;
using TEXTUREFORMAT = UnityEngine.TextureFormat;
using TEXTURE2D = UnityEngine.Texture2D;
using MATERIAL = UnityEngine.Material;
using SHADER = UnityEngine.Shader;
using RENDERTEXTURE = UnityEngine.RenderTexture;
using RECTANGLE = UnityEngine.Rect;
using GAMEOBJECT = UnityEngine.GameObject;
using SCREEN = UnityEngine.Screen;
using VECTOR2 = UnityEngine.Vector2;
using VECTOR3 = UnityEngine.Vector3;
using VECTOR4 = UnityEngine.Vector4;
using MATRIX4x4 = UnityEngine.Matrix4x4;
using QUATERNION = UnityEngine.Quaternion;
using OPENGL = UnityEngine.GL;
using ENUMERATOR = System.Collections.IEnumerator;
using APPLICATION = UnityEngine.Application;
using COLOR = UnityEngine.Color;
using WAIT = UnityEngine.WaitForSeconds;
using GUI = UnityEngine.GUI;
using MATH = UnityEngine.Mathf;
using TIME = UnityEngine.Time;
using MESH = UnityEngine.Mesh;
using MESHFILTER = UnityEngine.MeshFilter;
using MESHRENDERER = UnityEngine.MeshRenderer;
using TRANSFORM = UnityEngine.Transform;
using COLLIDER = UnityEngine.Collider;
using INPUT = UnityEngine.Input;
using KEY = UnityEngine.KeyCode;
using AUDIOCLIP = UnityEngine.AudioClip;
using AUDIOSOURCE = UnityEngine.AudioSource;
using GUISTYLE = UnityEngine.GUIStyle;
using RESOURCE = UnityEngine.Resources;
using GUILAYOUT = UnityEngine.GUILayout;
using RENDERTEXTUREFORMAT = UnityEngine.RenderTextureFormat;
using CAMERA = UnityEngine.Camera;
using UNITYGRAPHICS = UnityEngine.Graphics;
using EVENT = UnityEngine.Event;
using EVENTTYPE = UnityEngine.EventType;
using DEBUG = UnityEngine.Debug;
using SCALEMODE = UnityEngine.ScaleMode;
using TEXTANCHOR = UnityEngine.TextAnchor;
using RECTOFFSET = UnityEngine.RectOffset;
using SERIALIZE = UnityEngine.SerializeField;
using GUILAYOUTUTILITY = UnityEngine.GUILayoutUtility;
using PLANE = UnityEngine.Plane;
using RAY = UnityEngine.Ray;
using RAYCASTHIT = UnityEngine.RaycastHit;
using GUISKIN = UnityEngine.GUISkin;
using GUIUTILITY = UnityEngine.GUIUtility;
using RANDOM = UnityEngine.Random;
using MESHCOLLIDER = UnityEngine.MeshCollider;
using COMPUTEBUFFER = UnityEngine.ComputeBuffer;
using COMPUTEBUFFERTYPE = UnityEngine.ComputeBufferType;
using COMPUTESHADER = UnityEngine.ComputeShader;
using MESHTOPOLOGY = UnityEngine.MeshTopology;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Runtime.InteropServices;
using System.Collections;
using System;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
    public class COMPUTE
    {
        //*********************************************************************************************
        public string Name;
        //---------------------------------------------------------------------------------------------
        string Path;
        //---------------------------------------------------------------------------------------------
        int ActiveKernelIndex = 0;
        //---------------------------------------------------------------------------------------------
        internal COMPUTESHADER ComputeShader;
        //---------------------------------------------------------------------------------------------
        public float ExecutionTime = 0;
		public int CallCount = 0;
		//---------------------------------------------------------------------------------------------
		public int ThreadGroupCount
		{
			get
			{
				if (ComputeShader != null)
				{
					uint x, y, z;

					ComputeShader.GetKernelThreadGroupSizes(ActiveKernelIndex, out x, out y, out z);

					return (int)(x * y * z);
				}
				else
				{
					return 0;
				}
			}
		}
		//-----------------------------------------------------------------------------------------------------

		//*********************************************************************************************

		//-----------------------------------------------------------------------------------------------------
		public COMPUTE(string path)
		{
			Name = System.IO.Path.GetFileName(path);
			Path = path;
        }
		//-----------------------------------------------------------------------------------------------------
		void Load()
		{
            if (ComputeShader == null)
            {
				if (UnityEngine.SystemInfo.supportsComputeShaders)
				{
					ComputeShader = RESOURCE.Load<COMPUTESHADER>(Path);

					if (ComputeShader == null)
					{
						DEBUG.LogError("ERROR : Compute Shader cannot load , Name : " + Name + " , Path : " + Path);
					}
				}
				else
				{
					DEBUG.Log("Compute Shader not supported , Name : " + Name + " , Path : " + Path);
				}
			}
        }
        //-----------------------------------------------------------------------------------------------------
 		public void SetKernel(string name)
		{
            Load();

			if (ComputeShader != null)
			{
				if (ComputeShader.HasKernel(name))
				{
					ActiveKernelIndex = ComputeShader.FindKernel(name);
				}
				else
				{
					DEBUG.Log("ERROR , Compute has not kernel name : " + name);
				}
			}
		}
		//-----------------------------------------------------------------------------------------------------
		// ha lefut a compute shader true-val ter vissza
		//-----------------------------------------------------------------------------------------------------
		public bool Run(int threadCount)
		{
            Load();

			if (ComputeShader != null)
			{
				var time = TIME.realtimeSinceStartup;

				ComputeShader.Dispatch(ActiveKernelIndex, threadCount, 1, 1);

				ExecutionTime = TIME.realtimeSinceStartup - time;
				CallCount++;

				return true;
			}
			else
			{
				return false;
			}
		}
		//-----------------------------------------------------------------------------------------------------
		// ha lefut a compute shader true-val ter vissza
		//-----------------------------------------------------------------------------------------------------
		public bool Run(int threadX, int threadY, int threadZ)
		{
            Load();

			if (ComputeShader != null)
			{
				var time = TIME.realtimeSinceStartup;

				ComputeShader.Dispatch(ActiveKernelIndex, threadX, threadY, threadZ);

				ExecutionTime = TIME.realtimeSinceStartup - time;
				CallCount++;

				return true;
			}

			else
			{
				return false;
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetInt(string name, int value)
		{
            Load();
			if (ComputeShader != null) ComputeShader.SetInt(name, value);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetFloat(string name, float value)
		{
            Load();
			if (ComputeShader != null) ComputeShader.SetFloat(name, value);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetVector(string name, float2 vector)
        {
            Load();
			if (ComputeShader != null) ComputeShader.SetVector(name, new float4(vector, 0, 1));

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetVector(string name, float3 vector)
		{
			Load();
			if (ComputeShader != null) ComputeShader.SetVector(name, new float4(vector, 1));

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetColor(string name, COLOR color)
		{
			Load();
			if (ComputeShader != null) ComputeShader.SetVector(name, new float4(color.r, color.g, color.b, color.a));

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetVector(string name, float4 vector)
        {
            Load();
			if (ComputeShader != null) ComputeShader.SetVector(name, vector);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetMatrix(string name, MATRIX4x4 matrix)
		{
            Load();
			if (ComputeShader != null) ComputeShader.SetMatrix(name, matrix);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetTexture(string name, TEXTURE texture)
		{
            Load();
			if (ComputeShader != null) ComputeShader.SetTexture(ActiveKernelIndex, name, texture);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetBuffer(string name, BUFFER buffer)
		{
			Load();
			if (ComputeShader != null) ComputeShader.SetBuffer(ActiveKernelIndex, name, buffer.Buffer);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public COMPUTE SetArray(string name, BUFFER buffer)
		{
			Load();
			if (ComputeShader != null) ComputeShader.SetBuffer(ActiveKernelIndex, name, buffer.Buffer);

			return this;
		}
		//-----------------------------------------------------------------------------------------------------
		public static implicit operator COMPUTE(string fileName)
        {
            return new COMPUTE(fileName);
        }
        //-----------------------------------------------------------------------------------------------------
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
