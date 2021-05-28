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
using UnityEngine;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Ion
{
	public class DEBUG_SRC
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		static bool WarningEnableFlag = true;
		static bool LinkEnableFlag = true;
		static bool ErrorEnableFlag = true;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■

		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void Log(string text)
		{
			Debug.Log(text);
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void DrawLine(Vector3 start, Vector3 end)
		{
			Debug.DrawLine(start, end);
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void DrawRay(Vector3 start, Vector3 dir)
		{
			Debug.DrawRay(start, dir);
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void Break()
		{
			Debug.Break();
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void ClearDeveloperConsole()
		{
			Debug.ClearDeveloperConsole();
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void DebugBreak()
		{
			Debug.DebugBreak();
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void LogError(string text)
		{
			if (ErrorEnableFlag)
			{
				var color = new Color(0.7f, 0, 0, 1);
				Debug.LogError(string.Format("<color=#{0:X2}{1:X2}{2:X2}>{3}</color>", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), "ERROR : " + text));
			}
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void LogLink(string text)
		{
			if (LinkEnableFlag)
			{
				Log("<b>" + "LINK : " + text + "</b>");
			}
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void LogWarning(string text)
		{
			if (WarningEnableFlag)
			{
				Debug.LogWarning("WARNING : " + text);
			}
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void ShowCallerInfo(string message,
					[System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
					[System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
					[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
		{

			var callerTypeName = System.IO.Path.GetFileNameWithoutExtension(sourceFilePath);

			string text = "<b>" + "CALLER INFO : " + message + "</b>" + System.Environment.NewLine + "Class : " + callerTypeName + "." + memberName + System.Environment.NewLine + "Line : " + sourceLineNumber + System.Environment.NewLine + "Path : " + sourceFilePath + System.Environment.NewLine;
	
			Log(text);
		}
		//====================================================================================================
		[System.Diagnostics.Conditional("DEBUG"), System.Diagnostics.Conditional("UNITY_EDITOR")]
		public static void ShowParentCallerInfo(string message,
					[System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
					[System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
					[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
		{

			var callerTypeName = System.IO.Path.GetFileNameWithoutExtension(sourceFilePath);

			string text = "<b>" + "CALLER INFO : " +  message + "</b>" + System.Environment.NewLine + "Class : " + callerTypeName + "." + memberName + System.Environment.NewLine + "Line : " + sourceLineNumber + System.Environment.NewLine + "Path : " + sourceFilePath;

			// frame 1, true for source info
			var frame = new System.Diagnostics.StackFrame(2, true);
			if (frame.GetMethod() == null)
			{
				text += System.Environment.NewLine + System.Environment.NewLine + "CALLER : " + System.Environment.NewLine + System.Environment.NewLine + "WARNING : caller is Unity" + System.Environment.NewLine;
			}
			else
			{
				var parentMemberName = frame.GetMethod().Name;
				var parentSourceFilePath = frame.GetFileName();
				var parentSourceLineNumber = frame.GetFileLineNumber();

				var parentCallerTypeName = System.IO.Path.GetFileNameWithoutExtension(parentSourceFilePath);
				text += System.Environment.NewLine + System.Environment.NewLine + "CALLER : " + System.Environment.NewLine + System.Environment.NewLine + "Class : " + parentCallerTypeName + "." + parentMemberName + System.Environment.NewLine + "Line : " + parentSourceLineNumber + System.Environment.NewLine + "Path : " + parentSourceFilePath + System.Environment.NewLine;
			}

			Log(text);
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <image url="C:\Users\ION\Desktop\Visual Studio Documentation\logo.jpg" scale="0.5"  opacity="0.8"/>
