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
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public class INSPECTOR
	{

		//-----------------------------------------------------------------------------------------------------
		static public bool Changed
		{
			get { return GUI.changed; }
			set { GUI.changed = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		static public void HeaderLogo(string textureFileName)
		{
			GUILayout.Space(12);

			var logoTexture = new TEXTURE(textureFileName);

			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label(logoTexture, GUILayout.Width(MATH.min((float)SCREEN.width * 0.9f, 400)), GUILayout.Height(MATH.min(logoTexture.height, logoTexture.height * MATH.min((float)SCREEN.width * 0.9f, 400) / logoTexture.width)));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(8);

			GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void HeaderLogo(string textureFileName, string logo)
		{
			GUILayout.Space(12);

			TEXTURE logoTexture = null;

			if (textureFileName != null) logoTexture = new TEXTURE(textureFileName);

			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label(logoTexture, GUILayout.Width(MATH.min((float)SCREEN.width * 0.9f, 400)), GUILayout.Height(MATH.min(logoTexture.height, logoTexture.height * MATH.min((float)SCREEN.width * 0.9f, 400) / logoTexture.width)));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(8);

			GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void FooterLogo(string logoFileName)
		{
			var M12LogoTexture = new TEXTURE(logoFileName);
			GUILayoutOption[] option = { GUILayout.Width(100), GUILayout.Height(100) };

			GUILayout.Space(8);

			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label(M12LogoTexture, GUILayout.Width(100), GUILayout.Height(120));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(4);

			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("M-12 Technology Inc. 2018");
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(8);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Texture(string text, ref TEXTURE2D texture)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(text);
//			texture = new TEXTURE2D((Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), true));
			GUILayout.EndHorizontal();

			GUILayout.Space(4);

			GUILayout.BeginHorizontal();
			GUILayout.Label("", GUILayout.Width(SCREEN.width - 260));
			GUILayout.Label(texture, GUILayout.MaxWidth(200), GUILayout.MaxHeight(200));
			GUILayout.EndHorizontal();
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Mesh(string text, ref MESH mesh)
		{
			if (mesh != null)
			{
				mesh.Mesh = (Mesh)EditorGUILayout.ObjectField(text, mesh.Mesh, typeof(Mesh), true);
			}
			else
			{
				var m = (Mesh)EditorGUILayout.ObjectField(text, null, typeof(Mesh), true);
				if (m != null) mesh = new MESH(m);
			}

			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void GameObject(string text, ref GAMEOBJECT obj)
		{
			if (obj != null)
			{
				obj.GameObject = (GameObject)EditorGUILayout.ObjectField(text, obj.GameObject, typeof(GameObject), true);
			}
			else
			{
				var m = (GameObject)EditorGUILayout.ObjectField(text, null, typeof(GameObject), true);
//				if (m != null) obj = new GAMEOBJECT(m);
			}

			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void DrawTexture(TEXTURE2D texture)
		{
			GUILayout.Label(texture, GUILayout.Height(100));
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Line()
		{
			GUILayout.Space(4);
			GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void VectorField(string text, ref float2 position)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(text);
			GUILayout.FlexibleSpace();
			position = EditorGUILayout.Vector2Field("", position);
			GUILayout.EndHorizontal();
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void VectorField(string text, ref float3 position)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(text);
			GUILayout.FlexibleSpace();
			position = EditorGUILayout.Vector3Field("", position);
			GUILayout.EndHorizontal();
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void VectorField(string text, ref quaternion rotation)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(text);
			GUILayout.FlexibleSpace();
			Vector3 euler = ((Quaternion)rotation).eulerAngles;
			EditorGUI.BeginChangeCheck();
			euler = EditorGUILayout.Vector3Field("", euler);
			if (EditorGUI.EndChangeCheck())
			{
				rotation = Quaternion.Euler(euler);
			}

			GUILayout.EndHorizontal();
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Toggle(string text, ref bool value)
		{
			value = EditorGUILayout.Toggle(text, value);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void ColorField(string text, COLOR color)
		{
			EditorGUILayout.ColorField(text, color);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void ColorField(string text, ref COLOR color)
		{
			color = EditorGUILayout.ColorField(text, color);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Space(int height)
		{
			GUILayout.Space(height);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void FlexibleSpace()
		{
			GUILayout.FlexibleSpace();
		}
		//-----------------------------------------------------------------------------------------------------
		static public void BeginHorizontal()
		{
			GUILayout.BeginHorizontal();
		}
		//-----------------------------------------------------------------------------------------------------
		static public void EndHorizontal()
		{
			GUILayout.EndHorizontal();
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Dirty(Object obj)
		{
			if (GUI.changed)
			{
				EditorUtility.SetDirty(obj);
				if (!APPLICATION.isPlaying) EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
			}
		}
		//-----------------------------------------------------------------------------------------------------
		static public void FloatField(string text, float value)
		{
			EditorGUILayout.FloatField(text, value);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void FloatField(string text, ref float value, float min = float.NegativeInfinity, float max = float.PositiveInfinity)
		{
			value = EditorGUILayout.FloatField(text, value);
			value = MATH.min(max, MATH.max(min, value));
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void IntField(string text, int value)
		{
			EditorGUILayout.IntField(text, value);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void FloatSlider(string text, ref float value, float min, float max)
		{
			value = EditorGUILayout.Slider(text, value, min, max);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void IntSlider(string text, ref int value, int min, int max)
		{
			value = EditorGUILayout.IntSlider(text, value, min, max);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void IntField(string text, ref int value, int min = int.MinValue, int max = int.MaxValue)
		{
			value = EditorGUILayout.IntField(text, value);
			value = MATH.min(max, MATH.max(min, value));
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void TextField(string text, string value)
		{
			EditorGUILayout.TextField(text, value);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void TextField(string text, ref string value)
		{
			value = EditorGUILayout.TextField(text, value);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void TextArea(float height, ref string value, ref float2 scroll)
		{
			scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.Height(height));
			value = EditorGUILayout.TextArea(value, GUILayout.ExpandHeight(true));
			EditorGUILayout.EndScrollView();

			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public bool Foldout(string text, bool value)
		{
			var result = EditorGUILayout.Foldout(value, text);
			GUILayout.Space(4);

			return result;
		}
		//-----------------------------------------------------------------------------------------------------
		static public bool Foldout(string text, ref bool value)
		{
			value = EditorGUILayout.Foldout(value, text);
			GUILayout.Space(4);

			return value;
		}
		//-----------------------------------------------------------------------------------------------------
		static public void EnumPopup(string text, ref System.Enum e)
		{
			EditorGUILayout.EnumPopup(text, e);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Material(string text, ref MATERIAL material)
		{
			if (material == null) material = new MATERIAL();
			material.Material = (Material)EditorGUILayout.ObjectField(text, material.Material, typeof(Material), true);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public System.Enum EnumPopup(string text, System.Enum e)
		{
			var result = EditorGUILayout.EnumPopup(text, e);

			GUILayout.Space(4);

			return result;
		}
		//-----------------------------------------------------------------------------------------------------
		static public void EnumPopup<T>(string text, ref T e) where T : System.Enum
		{
			e = (T)EditorGUILayout.EnumPopup(text, e);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Object<T>(string text, ref T e) where T : Object
		{
			e = (T)EditorGUILayout.ObjectField(text, e, typeof(T), true);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Popup(string text, int index, string[] valueArray)
		{
			EditorGUILayout.Popup(text, index, valueArray);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Popup(string text, ref int index, string[] valueArray)
		{
			index = EditorGUILayout.Popup(text, index, valueArray);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
		static public bool Button(string text, int height)
		{
			var result = GUILayout.Button(text, GUILayout.Height(40));
			GUILayout.Space(4);

			return result;
		}
		//-----------------------------------------------------------------------------------------------------
		static public void Label(string text)
		{
			GUILayout.Label(text);
			GUILayout.Space(4);
		}
		//-----------------------------------------------------------------------------------------------------
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>