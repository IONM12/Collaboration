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
///////////////////////////////////////////////////////////////////////////////////////////////////////
using Ion;
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Collaboration
{
	public class CHAT : MONOBEHAVIOUR
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		TEXTURE PanelTexture1 = "Chat/Texture/ChatPanelTexture1";
		TEXTURE PanelTexture2 = "Chat/Texture/ChatPanelTexture2";
		TEXTURE PanelTexture3 = "Chat/Texture/ChatPanelTexture3";
		TEXTURE PanelTexture4 = "Chat/Texture/ChatPanelTexture4";
		TEXTURE PanelTexture5 = "Chat/Texture/ChatPanelTexture5";
		TEXTURE PanelTexture6 = "Chat/Texture/ChatPanelTexture6";
		//----------------------------------------------------------------------------------------------------
		TEXTURE[] PanelTextureArray;
		//----------------------------------------------------------------------------------------------------
		List<VIDEOPLAYER> VideoPlayerList;
		//----------------------------------------------------------------------------------------------------
		public float borderX = 20;
		public float borderY = 20;
		//----------------------------------------------------------------------------------------------------
		public float Size = 0.1f;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ START
		//====================================================================================================
		void Start()
		{
			VideoPlayerList = new List<VIDEOPLAYER>();

			//VideoPlayer 1
			var video1 = transform.Find("Video 1").GetComponent<VIDEOPLAYER>();
			VideoPlayerList.Add(video1);
			//VideoPlayer 1
			var video2 = transform.Find("Video 2").GetComponent<VIDEOPLAYER>();
			VideoPlayerList.Add(video2);
			//VideoPlayer 1
			var video3 = transform.Find("Video 3").GetComponent<VIDEOPLAYER>();
			VideoPlayerList.Add(video3);
			//VideoPlayer 1
			var video4 = transform.Find("Video 4").GetComponent<VIDEOPLAYER>();
			VideoPlayerList.Add(video4);
			//VideoPlayer 1
			var video5 = transform.Find("Video 5").GetComponent<VIDEOPLAYER>();
			VideoPlayerList.Add(video5);
			//VideoPlayer 1
			var video6 = transform.Find("Video 6").GetComponent<VIDEOPLAYER>();
			VideoPlayerList.Add(video6);

			PanelTextureArray = new TEXTURE[6];
			PanelTextureArray[0] = PanelTexture1;
			PanelTextureArray[1] = PanelTexture2;
			PanelTextureArray[2] = PanelTexture3;
			PanelTextureArray[3] = PanelTexture4;
			PanelTextureArray[4] = PanelTexture5;
			PanelTextureArray[5] = PanelTexture6;
		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			UI.depth = 1;

			for (int i = 0; i < VideoPlayerList.Count; i++)
			{
				float x = 30;
				float y = 100;

				if (i % 2 > 0) x = SCREEN.width - x - 600 * Size;

				var panelRectangle = new RECTANGLE(x - borderX, y + (i / 2) * SCREEN.height / 3.5f - borderY, 600 * Size + borderX * 2, 500 * Size + borderY * 2);
				UI.DrawTexture(panelRectangle, PanelTextureArray[i]);


				var videoRectangle = new RECTANGLE(x, y + (i / 2) * SCREEN.height / 3.5f, 600 * Size, 500 * Size);

				VideoPlayerList[i].Draw(videoRectangle);
			}


		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////
