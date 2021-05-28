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
using System.Runtime.InteropServices;
///////////////////////////////////////////////////////////////////////////////////////////////////////
//automatikusan valt a null az array es a buffer object kozott, eloszor a nullaval kezd, igy nem foglal le memoriat
//majd hasznalat kozben atkapcsol array es buffer kozott , attol fuggoen hogy hasznaljuk
//a sima ARRAY float4 tipusu, kompatibilis a TEXARRAY-al
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public class ARRAY : ARRAY<float4>
	{
		public ARRAY(int count) : base(count)
		{ 
		
		}
	}

	public class ARRAY<T> where T : struct
	{
		class OBJECT
		{
			public ARRAY<T> Parent;
			public int Count;

			public virtual T GetDataArray(int index) { return default; }
			public virtual void SetDataArray(int index, T value) { }
			public virtual T GetData(int index) { return default; }
			public virtual void SetData(int index, T value) { }
			public virtual T[] GetArray() { return null; }
			public virtual BUFFER GetBuffer() { return null; }
			public virtual void Release() { }
			public virtual void Clear(T value) { }

		}
		class NULLOBJECT : OBJECT
		{
			public NULLOBJECT(ARRAY<T> parent, int count)
			{
				Parent = parent;
				Count = count;
			}
			public override T GetDataArray(int index)
			{
				Parent.Object = new ARRAYOBJECT(Parent, Count);

				return Parent.Object.GetDataArray(index);
			}
			public override void SetDataArray(int index, T value)
			{
				Parent.Object = new ARRAYOBJECT(Parent, Count);

				Parent.Object.SetDataArray(index, value);
			}
			public override T GetData(int index)
			{
				Parent.Object = new ARRAYOBJECT(Parent, Count);

				return Parent.Object.GetDataArray(index);
			}
			public override void SetData(int index, T value)
			{
				Parent.Object = new ARRAYOBJECT(Parent, Count);

				Parent.Object.SetDataArray(index, value);
			}
			public override T[] GetArray()
			{
				Parent.Object = new ARRAYOBJECT(Parent, Count);

				return Parent.Object.GetArray(); 
			}
			public override BUFFER GetBuffer()
			{
				Parent.Object = new BUFFEROBJECT(Parent, Count);
	
				return Parent.Object.GetBuffer();
			}
			public override void Clear(T value)
			{
				var array = new T[Count];
				for (int i = 0; i < Count; i++)
				{
					array[i] = value;
				}

				Parent.Object = new BUFFEROBJECT(Parent, array);
			}
		}

		class ARRAYOBJECT : OBJECT
		{
			T[] Array;

			public ARRAYOBJECT(ARRAY<T> parent, int count)
			{
				Parent = parent;
				Count = count;

				Array = new T[Count];
			}
			public ARRAYOBJECT(ARRAY<T> parent, T[] array)
			{
				Parent = parent;
				Count = array.Length;

				Array = array;
			}
			public override T GetDataArray(int index)
			{
				return Array[index];
			}
			public override void SetDataArray(int index, T value)
			{
				Array[index] = value;
			}
			public override T GetData(int index)
			{
				return Array[index];
			}
			public override void SetData(int index, T value)
			{
				Array[index] = value;
			}
			public override T[] GetArray()
			{
				return Array;
			}
			public override BUFFER GetBuffer()
			{
				Parent.Object = new BUFFEROBJECT(Parent, Array);
	
				return Parent.Object.GetBuffer();
			}
			public override void Clear(T value)
			{
				for (int i = 0; i < Count; i++)
				{
					Array[i] = value;
				}
			}
		}
		class BUFFEROBJECT : OBJECT
		{
			BUFFER Buffer;

			public BUFFEROBJECT(ARRAY<T> parent, int count)
			{
				Parent = parent;
				Count = count;

				Buffer = new BUFFER(count, Marshal.SizeOf(default(T)));

				BUFFERMANAGER.AddBuffer(Buffer);
			}
			public BUFFEROBJECT(ARRAY<T> parent, T[] array)
			{
				Parent = parent;
				Count = array.Length;

				Buffer = new BUFFER(Count, Marshal.SizeOf(default(T)));
				Buffer.SetData(array);

				BUFFERMANAGER.AddBuffer(Buffer);
			}
			~BUFFEROBJECT()
			{
				BUFFERMANAGER.AddRemoveBuffer(Buffer);
			}
			public override T GetDataArray(int index)
			{
				var array = new T[Count];
				Buffer.GetData(array);
				Buffer.Release();
				Parent.Object = new ARRAYOBJECT(Parent, array);

				return Parent.Object.GetDataArray(index);
			}
			public override void SetDataArray(int index, T value)
			{
				var array = new T[Count];
				Buffer.GetData(array);
				Buffer.Release();
				Parent.Object = new ARRAYOBJECT(Parent, array);

				Parent.Object.SetDataArray(index, value);
			}
			public override T GetData(int index)
			{
				var data = new T[1];
				Buffer.GetData(data, 0, index, 1);
				return data[0];
			}
			public override void SetData(int index, T value)
			{
				var data = new T[1];
				data[0] = value;
				Buffer.SetData(data, 0, index, 1);
			}
			public override T[] GetArray()
			{
				var array = new T[Count];
				Buffer.GetData(array);

				return array;
			}
			public override BUFFER GetBuffer()
			{
				return Buffer;
			}
			public override void Release()
			{
				var array = new T[Count];
				Buffer.GetData(array);
				Parent.Object = new ARRAYOBJECT(Parent, array);

				Buffer.Release();
			}
			public override void Clear(T value)
			{
				var array = new T[Count];
				for (int i = 0; i < Count; i++)
				{
					array[i] = value;
				}

				Buffer.SetData(array);
			}
		}


		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		OBJECT Object;
		//----------------------------------------------------------------------------------------------------
		public int Count;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public ARRAY(int count)
		{
			Count = count;
			Object = new NULLOBJECT(this, Count);
		}
		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public ARRAY(T value)
		{
			Count = 1;
			Object = new ARRAYOBJECT(this, Count);
			Object.SetData(0, value);
		}
		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public ARRAY(T[] array)
		{
			Count = array.Length;
			var tempArray = new T[Count];
			array.CopyTo(tempArray, 0);
			Object = new ARRAYOBJECT(this, tempArray);
		}
		//====================================================================================================
		// ■ CONSTRUCTOR
		//====================================================================================================
		public ARRAY(List<T> list)
		{
			Count = list.Count;
			var tempArray = new T[Count];
			list.CopyTo(tempArray, 0);
			Object = new ARRAYOBJECT(this, tempArray);
		}
		//====================================================================================================
		// ■ CLEAR
		//====================================================================================================
		public void Clear(T value)
		{
			Object.Clear(value);
		}
		//====================================================================================================
		public T[] GetArray()
		{
			return Object.GetArray();
		}
		//====================================================================================================
		public void GetArray(Array array)
		{
			var buffer = Object.GetBuffer();
			buffer.GetData(array);
		}
		//====================================================================================================
		//mindenkeppen array muvelet, letolti gpu-bol a buffert
		//====================================================================================================
		public T this[int i]
		{
			get
			{
				return Object.GetDataArray(i);
			}
			set
			{
				Object.SetDataArray(i, value);
			}
		}
		//====================================================================================================
		public T GetData(int index)
		{
			return Object.GetData(index);
		}
		//====================================================================================================
		public void SetData(int index, T value)
		{
			Object.SetData(index, value);
		}
		//====================================================================================================
		public void Release()
		{
			Object.Release();
		}
		//====================================================================================================
/*		public static implicit operator ARRAY<T>(T value)
		{
			var array = new ARRAY<T>(value);

			return array;
		}
		//====================================================================================================
		public static implicit operator ARRAY<T>(T[] inputArray)
		{
			var array = new ARRAY<T>(inputArray);

			return array;
		}
		//====================================================================================================
		public static implicit operator ARRAY<T>(List<T> list)
		{
			var array = new ARRAY<T>(list);

			return array;
		}
*/		//====================================================================================================
		public static implicit operator BUFFER(ARRAY<T> array)
		{
			return array.Object.GetBuffer();
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
