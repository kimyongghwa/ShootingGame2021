Shader "Custom/fire"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_MainTex2("Albedo (RGB)", 2D) = "black" {}
		_Bright("Bright", Range(-1, 1)) = 0
		_Wrinkle("Wrinkle", Range(0, 1)) = 0
		_UVPos("UV", Range(-1, 1)) = 0
	}
		SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 200
		CGPROGRAM
		#pragma surface surf Standard alpha:fade

		sampler2D _MainTex;
		sampler2D _MainTex2;
		float _Bright;
		float _Wrinkle;
		float _UVPos;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_MainTex2;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 d = tex2D(_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y+ _Time.y));
			float e = 0;
			fixed4 c = tex2D(_MainTex, saturate(IN.uv_MainTex + (d.r * _Wrinkle) + _UVPos));
			o.Emission = c.rgb + _Bright;
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}

