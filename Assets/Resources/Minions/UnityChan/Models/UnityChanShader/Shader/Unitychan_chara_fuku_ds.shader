Shader "UnityChan/Clothing - Double-sided"
{
	Properties
	{
		_Color ("Main Color", Color) = (1, 1, 1, 1)
		_ShadowColor ("Shadow Color", Color) = (0.8, 0.8, 1, 1)
		_SpecularPower ("Specular Power", Float) = 20
		_EdgeThickness ("Outline Thickness", Float) = 1
				
		_MainTex ("Diffuse", 2D) = "white" {}
		_FalloffSampler ("Falloff Control", 2D) = "white" {}
		_RimLightSampler ("RimLight Control", 2D) = "white" {}
		_SpecularReflectionSampler ("Specular / Reflection Mask", 2D) = "white" {}
		_EnvMapSampler ("Environment Map", 2D) = "" {} 
		_NormalMapSampler ("Normal Map", 2D) = "" {} 

		_OutlineColor("Outline color", Color) = (0, 0.7, 0, 1)
		_OutlineWidth("Outline width", Range(1.0, 5.0)) = 1.00
	}

	SubShader
	{
		Tags
		{
			"RenderType"="Opaque"
			"Queue"="AlphaTest"
			"LightMode"="ForwardBase"
		}		

		Pass
		{
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float _OutlineWidth;
			float4 _OutlineColor;

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL; 
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float color : COLOR;
			};

			v2f vert(appdata v)
			{
				v.vertex.xyz *= _OutlineWidth;

				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = _OutlineColor;
				return o;
			}

			half4 frag() : COLOR
			{
				return _OutlineColor;
			}

			ENDCG
		}

		Pass
		{
			ZWrite On
			Cull Off
			ZTest LEqual
CGPROGRAM
#pragma multi_compile_fwdbase
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#include "AutoLight.cginc"
#include "CharaMain.cg"
ENDCG
		}

		Pass
		{
			ZWrite On
			Cull Front
			ZTest Less
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
#include "CharaOutline.cg"
ENDCG
		}

	}

	FallBack "Transparent/Cutout/Diffuse"
}
