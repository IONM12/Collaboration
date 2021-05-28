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
		Blend Off
		Ztest Off
		Zwrite On

		Pass
	{
		CGPROGRAM

#pragma glsl
#pragma target 3.0

#pragma vertex vert
#pragma fragment frag

	//---------------------------------------------------------------------------------------------
	float4 Color;
	//---------------------------------------------------------------------------------------------
	struct VSINPUT
	{
		float4 vertex : POSITION;
	};
	//---------------------------------------------------------------------------------------------
	struct PSINPUT
	{
		float4 position : SV_POSITION;
	};
	//---------------------------------------------------------------------------------------------
	PSINPUT vert(VSINPUT input)
	{
		PSINPUT output;

		output.position = UnityObjectToClipPos(input.vertex);

		return output;
	}
	//---------------------------------------------------------------------------------------------
	float4 frag(PSINPUT input) : COLOR0
	{
		float4 output;

	output = Color;

	return output;
	}
		//---------------------------------------------------------------------------------------------

		ENDCG
	}
	}
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////
