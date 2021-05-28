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
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	[Serializable]
	public class TRANSFORM
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public Transform Transform;

		//-----------------------------------------------------------------------------------------------------
		public TRANSFORM parent
		{
			get { return Transform.parent; }
			set { Transform.parent = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public GAMEOBJECT gameObject
		{
			get { return new GAMEOBJECT(Transform.gameObject); }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 position
		{
			get { return Transform.position; }
			set { Transform.position = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public quaternion rotation
		{
			get { return Transform.rotation; }
			set { Transform.rotation = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 scale
		{
			get { return Transform.localScale; }
			set { Transform.localScale = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 localScale
		{
			get { return Transform.localScale; }
			set { Transform.localScale = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 localPosition
		{
			get { return Transform.localPosition; }
			set { Transform.localPosition = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public quaternion localRotation
		{
			get { return Transform.localRotation; }
			set { Transform.localRotation = value; }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 TransformPoint(float3 position)
		{
			return Transform.TransformPoint(position);
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 TransformVector(float3 vector)
		{
			return Transform.TransformVector(vector);
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 up
		{
			get { return Transform.up; }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 right
		{
			get { return Transform.right; }
		}
		//-----------------------------------------------------------------------------------------------------
		public float3 forward
		{
			get { return Transform.forward; }
		}
		//-----------------------------------------------------------------------------------------------------
		public float4x4 localToWorldMatrix
		{
			get { return Transform.localToWorldMatrix; }
		}
		//-----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		public TRANSFORM Find(string name)
		{
			var transform = Transform.Find(name);

			if (transform == null) return null;

			return new TRANSFORM(transform);
		}
		//====================================================================================================
		public void RotateAround(float3 point, float3 axis, float angle)
		{
			Transform.RotateAround(point, axis, angle);
		}
		//====================================================================================================
		public void SetActive(bool flag)
		{
			Transform.gameObject.SetActive(flag);
		}
		//====================================================================================================
		public void Rotate(float x, float y, float z)
		{
			Transform.Rotate(x, y, z);
		}
		//====================================================================================================
		internal TRANSFORM(Transform transform)
		{
			Transform = transform;
		}
		//====================================================================================================
		public static implicit operator TRANSFORM(Transform transform)
		{
			return new TRANSFORM(transform);
		}
		//====================================================================================================
		public static implicit operator Transform(TRANSFORM transform)
		{
			return transform.Transform;
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
