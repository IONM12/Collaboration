//////////////////////////////////////////////////////////////////////////////////////////////////////
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
using System.Collections;
using System.Collections.Generic;
///////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public class SCENE
	{
		//-----------------------------------------------------------------------------------------------------
		static public bool Changed
		{
			get { return GUI.changed; }
			set { GUI.changed = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		static public COLOR color
		{
			set
			{
				Gizmos.color = value;
				GUI.color = value;

				Handles.color = value;
			}

		}
		//-----------------------------------------------------------------------------------------------------
		static public GUISkin skin
		{
			set
			{
				GUI.skin = value;
			}
		}
		//-----------------------------------------------------------------------------------------------------
		static public COLOR backgroundColor
		{
			set
			{
				GUI.backgroundColor = value;
			}
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawTexture(RECTANGLE rectangle, TEXTURE texture, bool consoleText = true)
		{
			if (texture == null)
			{
				if (consoleText) Debug.Log("Texture is null ! ");

				return;
			}

			GUI.DrawTexture(rectangle, texture);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawLines(float3[] array)
		{
			int count = array.Length;
			var lineArray = new Vector3[count];
			for (int i = 0; i < count; i++) { lineArray[i] = array[i]; }

			Handles.DrawLines(lineArray);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawSolidDisc(float3 center, float3 normal, float radius)
		{
			Handles.DrawSolidDisc(center, normal, radius);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawLines(float width, float3[] array)
		{
			int count = array.Length;
			var lineArray = new Vector3[count];
			for (int i = 0; i < count; i++) { lineArray[i] = array[i]; }

			Handles.DrawAAPolyLine(width, lineArray);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawLine(float width, float3 p1, float3 p2)
		{
			var array = new Vector3[2];
			array[0] = p1;
			array[1] = p2;

			Handles.DrawAAPolyLine(width, array);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawCircle(float3 position, quaternion rotation, float size, float width = 2)
		{
			int count = 50;
			var array = new Vector3[count + 1];
			for (int i = 0; i <= count; i++)
			{
				float t = i * 2 * (float)MATH.PI / count;
				var x = MATH.sin(t);
				var y = MATH.cos(t);

				array[i] = position + size * new float3(x, y, 0);
			}

			Handles.DrawAAPolyLine(width, array);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawCircleArea(float2 position, float size, float width = 2)
		{
			int count = 50;
			var array = new Vector3[count + 1];
			for (int i = 0; i <= count; i++)
			{
				float t = i * 2 * (float)MATH.PI / count;
				var x = MATH.sin(t);
				var y = MATH.cos(t);

				var p = position + size * new float2(x, y);

				var result = GetSceneHitGround(p);

				if (!result.hit) return;
				array[i] = result.point;
			}

			Handles.DrawAAPolyLine(width, array);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawSphere(float3 center, float radius)
		{
			Gizmos.DrawSphere(center, radius);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Label(RECTANGLE rectangle, string text)
		{
			GUI.Label(rectangle, text);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Label(RECTANGLE rectangle, string text, GUIStyle style)
		{
			GUI.Label(rectangle, text, style);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void HorizontalScrollBar(RECTANGLE rectangle, ref float value, float size, float leftValue, float rightValue)
		{
			value = GUI.HorizontalScrollbar(rectangle, value, size, leftValue, rightValue);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void VerticalScrollBar(RECTANGLE rectangle, ref float value, float size, float leftValue, float rightValue)
		{
			value = GUI.VerticalScrollbar(rectangle, value, size, leftValue, rightValue);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void HorizontalSlider(RECTANGLE rectangle, ref float value, float leftValue, float rightValue)
		{
			value = GUI.HorizontalSlider(rectangle, value, leftValue, rightValue);
		}
		//-----------------------------------------------------------------------------------------------------
		static public bool Button(RECTANGLE rectangle, string text)
		{
			return GUI.Button(rectangle, text);
		}
		//-----------------------------------------------------------------------------------------------------
		static public bool Button(RECTANGLE rectangle, TEXTURE texture, bool consoleText = true)
		{
			if (texture == null)
			{
				if (consoleText) Debug.Log("Button texture is null ! ");

				return false;
			}

			return GUI.Button(rectangle, texture);
		}
		//-----------------------------------------------------------------------------------------------------
		static public int GetControlID()
		{
			return GUIUtility.GetControlID(FocusType.Passive);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void SetHotControl(int controlID)
		{
			GUIUtility.hotControl = controlID;
		}
		//-----------------------------------------------------------------------------------------------------
		static public RAY GUIPointToWorldRay(float2 position)
		{
			var ray = HandleUtility.GUIPointToWorldRay(position);

			return new RAY(ray.origin, ray.direction);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void AddCursorRect(RECTANGLE rectangle, MouseCursor cursor)
		{
			EditorGUIUtility.AddCursorRect(rectangle, cursor);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void BeginGUI()
		{
			Handles.BeginGUI();
		}
		//-----------------------------------------------------------------------------------------------------
		static public void EndGUI()
		{
			Handles.EndGUI();
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Repaint()
		{
			HandleUtility.Repaint();
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawDottedLines(float3[] lineSegments, float screenSpaceSize)
		{
			int count = lineSegments.Length;

			var segments = new Vector3[count];

			for (int i = 0; i < count; i++)
			{
				segments[i] = lineSegments[i];
			}

			Handles.DrawDottedLines(segments, screenSpaceSize);
		}
		//-----------------------------------------------------------------------------------------------------
		static public float2 GetSceneUIPosition(float2 mousePosition)
		{
			float y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;

			return new float2(mousePosition.x, y);
		}
		//-----------------------------------------------------------------------------------------------------
		static public float3 PositionHandle(float3 position, quaternion rotation, float size)
		{
			Vector3 snap = Vector3.one * 0.5f;
			return Handles.FreeMoveHandle(position, Quaternion.identity, size, snap, Handles.RectangleHandleCap);
		}
		//-----------------------------------------------------------------------------------------------------
		static public quaternion RotationHandle(float3 position, quaternion rotation, float size)
		{
			var r = Handles.FreeRotateHandle(rotation, position, size);

			return r;
		}
		//-----------------------------------------------------------------------------------------------------
		static public float ScaleHandle(float scale, float3 position, float3 direction, float size)
		{
			float snap = 0.5f;
			var s = Handles.ScaleSlider(scale, position, direction, Quaternion.identity, size, snap);

			return s;
		}
		//-----------------------------------------------------------------------------------------------------
		/*		static public void DrawSpline(SPLINE spline)
				{
					var array = spline.GetSplinePointArray();
					var pointArray = array.pointArray;
					var indexArray = array.indexArray;

					int count = pointArray.Length;

					var points = new Vector3[count];
					for (int i = 0; i < count; i++)
					{
						points[i] = pointArray[i];
					}

					Handles.DrawAAPolyLine(points);
				}
		*/        //====================================================================================================
		static public RAYCASTHIT GetSceneHitGround(float2 mousePosition, int layerMask = -1)
		{
			//mouse position
			var ray = SCENE.GUIPointToWorldRay(mousePosition);

			var raycastHit = PHYSICS.Raycast(ray, layerMask);

			if (raycastHit.hit) return raycastHit;

			float d = -ray.origin.y / ray.direction.y;
			var gridPoint = ray.origin + d * ray.direction;
			var localPoint = gridPoint;
			var localNormal = new float3(0, 1, 0);

			if (d <= 0)
			{
				raycastHit.hit = false;
			}
			else
			{
				raycastHit.hit = true;
				raycastHit.point = localPoint;
			}

			return raycastHit;
		}
		//====================================================================================================
		static public RAYCASTHIT GetSceneHit(float2 mousePosition, int layerMask = -1)
		{
			//mouse position
			var ray = SCENE.GUIPointToWorldRay(mousePosition);

			var raycastHit = PHYSICS.Raycast(ray, layerMask);

			return raycastHit;
		}
		//====================================================================================================
		static public void LoadScene(string name)
		{
			SceneManager.LoadScene(name);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>