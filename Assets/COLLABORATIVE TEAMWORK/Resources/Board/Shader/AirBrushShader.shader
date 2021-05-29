// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
/**************************************************************************************************************
*
* ----------------------------------------------
* M-12 Technology Incorporated , [2012] - [2014]
* ----------------------------------------------
*
* NOTICE:  All information contained herein is, and remains
* the property of M-12 Technology Incorporated and its suppliers,
* if any.  The intellectual and technical concepts contained
* herein are proprietary to M-12 Technology Incorporated
* and its suppliers and may be covered by U.S. and Foreign Patents,
* patents in process, and are protected by trade secret or copyright law.
* Dissemination of this information or reproduction of this material
* is strictly forbidden unless prior written permission is obtained
* from M-12 Technology Incorporated.
*
* Facebook : https://www.facebook.com/pages/M-12-Technology-Inc/244882162229445
*
* Email : m-12.software.technology@gmail.com
*
* Developer : versION#
*
* Date : 10 / 10 / 2013
*
* ---------------------------------------------------------------------
* Copyright (C) 2013 M-12 Technology Incorporated - All Rights Reserved
* ---------------------------------------------------------------------
*
*************************************************************************************************************/
///////////////////////////////////////////////////////////////////////////////////////////////////////////
Shader ""
{
	SubShader
	{
		Cull Off

		Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency

		//		BlendOp Add, Max
		//		Blend  SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha // Traditional transparency
		//		Blend Off
		//		BlendOp Add, Add
		//		Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha // Traditional transparency
		//		AlphaToMask On
		//		BlendOp Add, Add
		//		Blend OneMinusDstColor One, SrcAlpha OneMinusSrcAlpha // Traditional transparency
		//		Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency
		//		Blend One OneMinusSrcAlpha // Premultiplied tranparency
		//		Blend One One // Additive
		//		Blend OneMinusDstColor One // Soft Additive
		//		Blend DstColor Zero // Multiplicative
		//		Blend DstColor SrcColor // 2x Multiplicative
				ZTest Off
				ZWrite Off

				Pass
			{
				CGPROGRAM

		#pragma glsl
		#pragma target 3.5

		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"


				//---------------------------------------------------------------------------------------------
				sampler2D SourceTexture;
				float4 Color;
				float2 Position;
				float Size;
				float Aspect;
				//---------------------------------------------------------------------------------------------
				struct VSINPUT
				{
					float4 vertex : POSITION;
				};
				//---------------------------------------------------------------------------------------------
				struct PSINPUT
				{
					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0;
				};
				//---------------------------------------------------------------------------------------------
				PSINPUT vert(VSINPUT input)
				{
					PSINPUT output;

					uint u = input.vertex.x;					

					float2 local;
					if (u == 0) local = float2(0, 0);
					if (u == 1) local = float2(0, 1);
					if (u == 2) local = float2(1, 1);
					if (u == 3) local = float2(1, 1);
					if (u == 4) local = float2(1, 0);
					if (u == 5) local = float2(0, 0);

					float2 localPosition = local + float2(-0.5, -0.5);
					localPosition.y = localPosition.y * Aspect;

					float2 position = Position + localPosition * Size;

					output.position = float4(position, 0, 1);
					output.uv = local;

					return output;
				}
				//---------------------------------------------------------------------------------------------
				float4 frag(PSINPUT input) : COLOR
				{
					float4 output;

					float4 color = tex2D(SourceTexture, input.uv);

					output.a = color.a;
					output.rgb = color.rgb * Color.rgb;

					return output;

				}
					//---------------------------------------------------------------------------------------------

					ENDCG
				}
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////

//  colorA * alphaA + (1 - alphaA) * colorB * alphaB
//  ------------------------------------------------
//    alphaA + (1 - alphaA) * alphaB



//1 output = lerp(texture1.rgb, background.rgb, texture1.a)
//2 output = lerp(texture2.rgb, output.rgb, texture2.a)
//3 output = lerp(texture3.rgb, output.rgb, texture3.a)

//kifejteve 2 texturara:
//
//output = texture2.rgb x texture2.a + texture1.rgb x texture1.a x (1 - texture2.a) +
//			+ background.rgb x (1 - texture1.a) x (1 - texture2.a)
//
// kulonvalaszthato a texturak kiszaloasa es utolag hozzaadasa a backgroundhoz

//az atlatszo retegek 1-es alfanal atlatszoak, nullanal telitettek

// kifejtve, hatulrol indulva, az alfaba rakjuk az alfas szorzatokat, es igy osszeadhatunk barmennyi transparent reteget
// output = háttér.rgb * (1 - texture1.a) * (1 - texture2.a) * (1 - texture3.a)* (1 - texture4.a)
// + (texture1.rgb * texture1.a * (1 - texture2.a) * (1 - texture3.a)
// + texture2.rgb * texture2.a * (1 - texture3.a)
// + texture3.rgb * texture3.a ) * (1 - texture4.a)

// + texture4.rgb * texture4.a


