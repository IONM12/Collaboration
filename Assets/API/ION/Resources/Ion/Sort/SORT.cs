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
//eloszor a floating point szamokat atkonvertaljuk integer formaba, ugy hogy a byteokat elerhessuk
//aztan minden bytera futtatjuk a sort  algoritmust, ami berendezi byte alapjan az adatokat
//minden sort elott  le kell futtatni egy counting-ot , minden threadre es azon belul az osszes byte ertekre
//igy thread * 256 meretu tombbe, minden threadnel megszamoljuk hogy az adott byte tipusbol hany darab van , ezt kiirjuk
//majd a sumarray algoritmussal ezt a tombot osszeadjuk es lepesenkent kiirjuk az osszeget, ez adja az offsetet 
//majd osszeadjuk a teljes sumot is ami az osszes thread teljes offsetjet adja, byte ertekenkent
//a sort algoritmus a (sumArray + sum) offset ertekre kerul kiirasra , ugy hogy a lokalis index novelesre kerul, ami a sumArrayban van
//ebben az algoritmusban nincs atomic muvelet, minden thread fuggetlen egymastol
//csak pozitiv ertekekre mukodik, a 0 -val vigyazzunk 
//a negativ ertekeknel  kell egy minimum kereses csinalnit a tombbre, majd hozzaadni azt minden elemhez, igy pozitiv lesz mindegyik
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public partial class DATA
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		static COMPUTE SortIntegerCompute = "Ion/Sort/Compute/IntegerCompute";
		static COMPUTE SortSumCompute = "Ion/Sort/Compute/SumCompute";
		static COMPUTE SortSumArrayCompute = "Ion/Sort/Compute/SumArrayCompute";
		static COMPUTE SortCounting1Compute = "Ion/Sort/Compute/Counting1Compute";
		static COMPUTE SortCounting2Compute = "Ion/Sort/Compute/Counting2Compute";
		static COMPUTE SortCounting3Compute = "Ion/Sort/Compute/Counting3Compute";
		static COMPUTE SortCounting4Compute = "Ion/Sort/Compute/Counting4Compute";
		//----------------------------------------------------------------------------------------------------
		static COMPUTE Sort1Compute = "Ion/Sort/Compute/Sort1Compute";
		static COMPUTE Sort2Compute = "Ion/Sort/Compute/Sort2Compute";
		static COMPUTE Sort3Compute = "Ion/Sort/Compute/Sort3Compute";
		static COMPUTE Sort4Compute = "Ion/Sort/Compute/Sort4Compute";
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■

		//-----------------------------------------------------------------------------------------
		public static int[] Sort(float[] array)
		{
			int count = array.Length;

			byte[] ByteArray = new byte[count * 4];
			System.Buffer.BlockCopy(array, 0, ByteArray, 0, ByteArray.Length);

			int[] indexArrayA = new int[count];
			int[] indexArrayB = new int[count];

			int[] count0 = new int[256];
			int[] count1 = new int[256];
			int[] count2 = new int[256];
			int[] count3 = new int[256];

			int[] localCount0 = new int[256];
			int[] localCount1 = new int[256];
			int[] localCount2 = new int[256];
			int[] localCount3 = new int[256];

			//Clear Count Arrays
			for (int i = 0; i < 256; i++)
			{
				count0[i] = 0;
				count1[i] = 0;
				count2[i] = 0;
				count3[i] = 0;
				localCount0[i] = 0;
				localCount1[i] = 0;
				localCount2[i] = 0;
				localCount3[i] = 0;
			}

			//Counting
			for (int i = 0; i < count; i++)
			{
				count0[ByteArray[(i << 2) + 0]]++;
				count1[ByteArray[(i << 2) + 1]]++;
				count2[ByteArray[(i << 2) + 2]]++;
				count3[(ByteArray[(i << 2) + 3] + 127) & 255]++;
			}

			//Sum
			int sum0 = 0;
			int sum1 = 0;
			int sum2 = 0;
			int sum3 = 0;
			for (int i = 0; i < 256; i++)
			{
				int s0 = count0[i];
				int s1 = count1[i];
				int s2 = count2[i];
				int s3 = count3[i];

				count0[i] = sum0;
				count1[i] = sum1;
				count2[i] = sum2;
				count3[i] = sum3;

				sum0 += s0;
				sum1 += s1;
				sum2 += s2;
				sum3 += s3;
			}

			//First Radix
			for (int i = 0; i < count; i++)
			{
				int b = ByteArray[(i << 2) + 0];
				indexArrayA[count0[b] + localCount0[b]++] = i;
			}

			//Second Radix
			for (int i = 0; i < count; i++)
			{
				int b = ByteArray[(indexArrayA[i] << 2) + 1];
				indexArrayB[count1[b] + localCount1[b]++] = indexArrayA[i];
			}

			//Third Radix
			for (int i = 0; i < count; i++)
			{
				int b = ByteArray[(indexArrayB[i] << 2) + 2];
				indexArrayA[count2[b] + localCount2[b]++] = indexArrayB[i];
			}

			//Fourth Radix
			for (int i = 0; i < count; i++)
			{
				int b = (ByteArray[(indexArrayA[i] << 2) + 3] + 127) & 255;
				indexArrayB[count3[b] + localCount3[b]++] = indexArrayA[i];
			}

			return indexArrayB;
		}
		//-----------------------------------------------------------------------------------------
		// Radix Sort
		//-----------------------------------------------------------------------------------------------------
		public static void Sort(ARRAY<int> indexBuffer, ARRAY<float> sourceBuffer, int threadCount = 256)
		{
			if (indexBuffer.Count == sourceBuffer.Count)
			{
				int count = sourceBuffer.Count;

				//Create CountBuffers
				var countArrayBuffer = new ARRAY<int>(256 * threadCount * 16);

				//Create SumBuffers
				var sum1Buffer = new ARRAY<int>(256);
				var sum2Buffer = new ARRAY<int>(256);
				var sumArrayBuffer = new ARRAY<int>(256 * threadCount * 16);

				//Create Integer Buffers
				var integerBuffer = new ARRAY<int>(count);

				//Create TempBuffers
				var tempBuffer = new ARRAY<int>(count);

				//Integer Buffer
				var compute = SortIntegerCompute;
				compute.SetBuffer("SourceBuffer", sourceBuffer);
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Counting 1
				compute = SortCounting1Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Sum Array
				compute = SortSumArrayCompute;
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetBuffer("SumBuffer", sum1Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetInt("Count", threadCount * 16);
				compute.Run(16);

				//Sum
				compute = SortSumCompute;
				compute.SetBuffer("Sum1Buffer", sum1Buffer);
				compute.SetBuffer("Sum2Buffer", sum2Buffer);
				compute.Run(1);

				//Sort 1
				compute = Sort1Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("TargetIndexBuffer", tempBuffer);
				compute.SetBuffer("SumBuffer", sum2Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Counting 2 
				compute = SortCounting2Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("SourceIndexBuffer", tempBuffer);
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Sum Array
				compute = SortSumArrayCompute;
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetBuffer("SumBuffer", sum1Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetInt("Count", threadCount * 16);
				compute.Run(16);

				//Sum
				compute = SortSumCompute;
				compute.SetBuffer("Sum1Buffer", sum1Buffer);
				compute.SetBuffer("Sum2Buffer", sum2Buffer);
				compute.Run(1);

				//Sort 2
				compute = Sort2Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("SourceIndexBuffer", tempBuffer);
				compute.SetBuffer("TargetIndexBuffer", indexBuffer);
				compute.SetBuffer("SumBuffer", sum2Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Counting 3
				compute = SortCounting3Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("SourceIndexBuffer", indexBuffer);
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Sum Array
				compute = SortSumArrayCompute;
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetBuffer("SumBuffer", sum1Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetInt("Count", threadCount * 16);
				compute.Run(16);

				//Sum
				compute = SortSumCompute;
				compute.SetBuffer("Sum1Buffer", sum1Buffer);
				compute.SetBuffer("Sum2Buffer", sum2Buffer);
				compute.Run(1);

				//Sort 3
				compute = Sort3Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("SourceIndexBuffer", indexBuffer);
				compute.SetBuffer("TargetIndexBuffer", tempBuffer);
				compute.SetBuffer("SumBuffer", sum2Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Counting 4
				compute = SortCounting4Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("SourceIndexBuffer", tempBuffer);
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Sum Array
				compute = SortSumArrayCompute;
				compute.SetBuffer("CountArrayBuffer", countArrayBuffer);
				compute.SetBuffer("SumBuffer", sum1Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetInt("Count", threadCount * 16);
				compute.Run(16);

				//Sum
				compute = SortSumCompute;
				compute.SetBuffer("Sum1Buffer", sum1Buffer);
				compute.SetBuffer("Sum2Buffer", sum2Buffer);
				compute.Run(1);

				//Sort 4
				compute = Sort4Compute;
				compute.SetBuffer("IntegerBuffer", integerBuffer);
				compute.SetBuffer("SourceIndexBuffer", tempBuffer);
				compute.SetBuffer("TargetIndexBuffer", indexBuffer);
				compute.SetBuffer("SumBuffer", sum2Buffer);
				compute.SetBuffer("SumArrayBuffer", sumArrayBuffer);
				compute.SetFloat("Count", (float)count / (threadCount * 16));
				compute.Run(threadCount);

				//Release
				countArrayBuffer.Release();
				sum1Buffer.Release();
				sum2Buffer.Release();
				sumArrayBuffer.Release();
				integerBuffer.Release();
				tempBuffer.Release();
			}
			else
			{
				DEBUG.Log("ERROR , Compute sort index and source Buffer's count not equal !");
			}
		}
		//-----------------------------------------------------------------------------------------------------
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////

