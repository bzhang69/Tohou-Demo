Shader "Custom/White_Transparent" 
{
	Properties 
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}

	SubShader 
	{
		Pass
		{
			Tags
			{
				
			}
			LOD 200
			ZWrite Off

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"

			struct vertex_in
			{
				float4 pos : POSITION;
				float4 texcoord : TEXCOORD0;
			};

			struct vertex_out
			{
				float4 pos : SV_POSITION;
				float4 uv : TEXCOORD0;
			};

			vertex_out vert(vertex_in input)
			{
				vertex_out o;
				o.pos = UnityObjectToClipPos(input.pos);
				o.uv = float4( input.texcoord.xy, 0, 0);
				return o;
			}

			sampler2D _MainTex;

			half4 frag(vertex_out input) : SV_Target
			{
				half4 c = tex2D(_MainTex, input.uv.xy);

				if(c.r > 0.5 && c.g > 0.5 && c.b > 0.5)
				{
					discard;
				}
				
				return c;
			}

			ENDCG
		}
	}
	
}
