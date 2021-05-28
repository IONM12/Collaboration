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
	public class GAMEOBJECT
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public GameObject GameObject;
		//----------------------------------------------------------------------------------------------------
		public string tag
		{
			get { return GameObject.tag; }
			set { GameObject.tag = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public int layer
		{
			get { return GameObject.layer; }
			set { GameObject.layer = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public TRANSFORM transform
		{
			get { return new TRANSFORM(GameObject.transform); }
		}
		//-----------------------------------------------------------------------------------------------------
		public string name
		{
			get { return GameObject.transform.name; }
			set { GameObject.transform.name = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public void Destroy()
		{
			GAMEOBJECT.Destroy(this);
		}
		//-----------------------------------------------------------------------------------------------------
		public void SetActive(bool flag)
		{
			GameObject.SetActive(flag);
		}
		//-----------------------------------------------------------------------------------------------------
		public Component[] GetAllComponents()
		{
			var list = new List<Component>();
			foreach (var comp in GameObject.GetComponents<Component>())
			{
				if (!(comp is Transform))
				{
					list.Add(comp);
				}
			}

			return list.ToArray();
		}
		//-----------------------------------------------------------------------------------------------------
		public void DestroyImmediate()
		{
			GAMEOBJECT.DestroyImmediate(this);
		}
		//-----------------------------------------------------------------------------------------------------
		public COLLIDER collider
		{
			get { return new COLLIDER(GameObject.GetComponent<Collider>()); }
		}
		//-----------------------------------------------------------------------------------------------------
		public CAMERA camera
		{
			get { return new CAMERA(GameObject.GetComponent<Camera>()); }
		}
		//-----------------------------------------------------------------------------------------------------
		public AUDIOSOURCE audioSource
		{
			get { return new AUDIOSOURCE(GameObject.GetComponent<AudioSource>()); }
		}
		//-----------------------------------------------------------------------------------------------------
		public MESHFILTER meshFilter
		{
			get
			{
				var meshFilter = GameObject.GetComponent<MeshFilter>();

				if (meshFilter == null)
				{
					meshFilter = GameObject.AddComponent<MeshFilter>();
				}

				return new MESHFILTER(meshFilter);
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public MESHCOLLIDER meshCollider
		{
			get
			{
				var meshCollider = GameObject.GetComponent<MeshCollider>();

				if (meshCollider == null)
				{
					meshCollider = GameObject.AddComponent<MeshCollider>();
				}

				return new MESHCOLLIDER(meshCollider);
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public MESHRENDERER renderer
		{
			get
			{
				var renderer = GameObject.GetComponent<MeshRenderer>();

				if (renderer == null)
				{
					renderer = GameObject.AddComponent<MeshRenderer>();
				}

				return new MESHRENDERER(renderer);
			}
		}
		//-----------------------------------------------------------------------------------------------------
		public RIGIDBODY rigidbody
		{
			get
			{
				var rigidbody = GameObject.GetComponent<Rigidbody>();

				if (rigidbody == null)
				{
					rigidbody = GameObject.AddComponent<Rigidbody>();
				}

				return new RIGIDBODY(rigidbody);
			}
		}
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public GAMEOBJECT()
		{
		}
		//====================================================================================================
		public GAMEOBJECT(string name)
		{
			GameObject = new GameObject(name);
		}
		//====================================================================================================
		internal GAMEOBJECT(GameObject gameObject)
		{
			GameObject = gameObject;
		}
		//====================================================================================================
		public GAMEOBJECT[] GetChildArray()
		{
			List<GAMEOBJECT> list = new List<GAMEOBJECT>();

			foreach (Transform child in GameObject.transform)
			{
				list.Add(new GAMEOBJECT(child.gameObject));
			}

			return list.ToArray();
		}
		//====================================================================================================
		public static GAMEOBJECT Instantiate(GAMEOBJECT obj)
		{
			var clone = GameObject.Instantiate(obj.GameObject);

			return new GAMEOBJECT(clone);
		}
		//====================================================================================================
		public static GAMEOBJECT Instantiate(GAMEOBJECT obj, float3 position, Quaternion quaternion)
		{
			var clone = GameObject.Instantiate(obj.GameObject, position, quaternion);

			return new GAMEOBJECT(clone);
		}
		//====================================================================================================
		public static GAMEOBJECT LoadPrefab(string path)
		{
			var obj = Resources.Load<GameObject>(path);
			if (obj == null)
			{
				Debug.Log("Prefab dont load ! : " + path);
			}

			return new GAMEOBJECT(obj);
		}
		//====================================================================================================
		public T AddComponent<T>() where T : Component
		{
			return GameObject.AddComponent<T>();
		}
		//====================================================================================================
		public T GetComponent<T>() where T : Component
		{
			return GameObject.GetComponent<T>();
		}
		//====================================================================================================
		public T GetComponentAdd<T>() where T : Component
		{
			var component = GameObject.GetComponent<T>();
			if (component == null) component = GameObject.AddComponent<T>();

			return component;
		}
		//====================================================================================================
		static public GAMEOBJECT Find(string name)
		{
			var obj = GameObject.Find(name);

			if (obj == null)
			{
				return null;
			}
			else
			{
				return new GAMEOBJECT(obj);
			}
		}
		//====================================================================================================
		static public GAMEOBJECT FindCreate(string name)
		{
			var obj = GameObject.Find(name);

			if (obj == null)
			{
				obj = new GameObject(name);
			}

			return new GAMEOBJECT(obj);
		}
		//====================================================================================================
		static public void DestroyImmediate(GAMEOBJECT obj)
		{
			GameObject.DestroyImmediate(obj.GameObject);
		}
		//====================================================================================================
		static public void Destroy(GAMEOBJECT obj)
		{
			GameObject.Destroy(obj.GameObject);
		}
		//====================================================================================================
		public void AddRigidbody()
		{
			GameObject.AddComponent<Rigidbody>();
		}
		//====================================================================================================
		public void AddMeshCollider()
		{
			GameObject.AddComponent<MeshCollider>();
		}
		//====================================================================================================
		static public void Destroy(GAMEOBJECT obj, float time)
		{
			GameObject.Destroy(obj.GameObject, time);
		}
		//====================================================================================================
		public static implicit operator GAMEOBJECT(GameObject gameObject)
		{
			return new GAMEOBJECT(gameObject);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
