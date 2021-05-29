///////////////////////////////////////////////////////////////////////////////////////////////////////
using Ion;
///////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
///////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  webm vagy mp4 videot jatszik le, a chrome alatt inkabb a webm mukodik, firefox alatt nem, az mp4 neha jo neha nem bugos
//
///////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Collaboration
{
	public class VIDEOPLAYER : MonoBehaviour
	{
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■
		//----------------------------------------------------------------------------------------------------
		public bool PlayFromWeb = false;
		//----------------------------------------------------------------------------------------------------
		public bool PlayAwake = false;
		//----------------------------------------------------------------------------------------------------
		public bool Show = false;
		//----------------------------------------------------------------------------------------------------
		public bool Loop = false;
		//----------------------------------------------------------------------------------------------------
		public VideoClip VideoToPlay;
		//----------------------------------------------------------------------------------------------------
		public string URL = "http://holographics.xyz/sample.mp4";
		//----------------------------------------------------------------------------------------------------
		VideoPlayer videoPlayer;
		//----------------------------------------------------------------------------------------------------
		AudioSource audioSource;
		//----------------------------------------------------------------------------------------------------
		Texture movieTexture;
		//----------------------------------------------------------------------------------------------------
		// ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■


		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void Start()
		{
			//Add VideoPlayer to the GameObject
			videoPlayer = gameObject.AddComponent<VideoPlayer>();

			//Add AudioSource
			audioSource = gameObject.AddComponent<AudioSource>();

			//Disable Play on Awake for both Video and Audio
			videoPlayer.playOnAwake = false;
			audioSource.playOnAwake = false;
			audioSource.Pause();

			//Set Audio Output to AudioSource
			videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

			//Assign the Audio from Video to AudioSource to be played
			videoPlayer.EnableAudioTrack(0, true);
			videoPlayer.SetTargetAudioSource(0, audioSource);

			if (PlayAwake)
			{
				Play();
			}
		}
		//====================================================================================================
		// ■ UPDATE
		//====================================================================================================
		void Update()
		{
		}
		//====================================================================================================
		// ■ GUI
		//====================================================================================================
		void OnGUI()
		{
			GUI.depth = 0;

			if (Show)
			{
				if (movieTexture != null)
				{
					if (movieTexture.width > 0)
					{
						var r = new Rect(100, Screen.height * 0.5f - movieTexture.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.2f);

						GUI.DrawTexture(r, movieTexture);
					}
				}
			}

		}
		//====================================================================================================
		// ■ DRAW
		//====================================================================================================
		public void Draw(RECTANGLE rectangle)
		{
			if (movieTexture != null)
			{
				if (movieTexture.width > 0)
				{
					GUI.DrawTexture(rectangle, movieTexture);
				}
			}

		}
		//====================================================================================================
		// ■ PLAYVIDEO
		//====================================================================================================
		IEnumerator playVideo()
		{
			//play videoclip from web or not
			if (PlayFromWeb == false)
			{
				//We want to play from video clip not from url
				videoPlayer.source = VideoSource.VideoClip;
				videoPlayer.clip = VideoToPlay;
			}
			else
			{
				// Video clip from Url
				videoPlayer.source = VideoSource.Url;

				videoPlayer.url = URL;

				//if (Application.isEditor) videoPlayer.url = "http://holographics.xyz/sample.mp4";
				//else videoPlayer.url = "http://holographics.xyz/sample.webm";
			}

			//Set video To Play then prepare Audio to prevent Buffering
			videoPlayer.Prepare();

			Debug.Log("Preparing Video");

			while (!videoPlayer.isPrepared)
			{
				yield return null;
			}

			Debug.Log("Done Preparing Video");

			//Assign the Texture from Video to RawImage to be displayed
			movieTexture = videoPlayer.texture;

			while (Loop)
			{
				//Play Video
				videoPlayer.Play();

				//Play Sound
				audioSource.Play();

				Debug.Log("Playing Video");
				while (videoPlayer.isPlaying)
				{
					//			Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
					yield return null;
				}
				Debug.Log("Done Playing Video");
			}
		}
		//====================================================================================================
		// ■ GET TEXTURE
		//====================================================================================================
		public Texture GetTexture()
		{
			return movieTexture;
		}
		//====================================================================================================
		// ■ ISPLAYING
		//====================================================================================================
		public bool IsPlaying()
		{
			return videoPlayer.isPlaying;
		}
		//====================================================================================================
		// ■ PLAY
		//====================================================================================================
		public void Play()
		{
			Stop();

			if (PlayFromWeb == false)
			{
				if (VideoToPlay != null) StartCoroutine(playVideo());
			}
			else
			{
				if (URL != "") StartCoroutine(playVideo());
			}

		}
		//====================================================================================================
		// ■ PLAY
		//====================================================================================================
		public void Play(VideoClip video)
		{
			Stop();
			PlayFromWeb = false;
			VideoToPlay = video;
			StartCoroutine(playVideo());
		}
		//====================================================================================================
		// ■ PLAY URL
		//====================================================================================================
		public void Play(string url)
		{
			Stop();
			PlayFromWeb = true;
			URL = url;
			StartCoroutine(playVideo());
		}
		//====================================================================================================
		// ■ STOP
		//====================================================================================================
		public void Stop()
		{
			videoPlayer.Stop();
			StopCoroutine(playVideo());
		}
		//====================================================================================================
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////
