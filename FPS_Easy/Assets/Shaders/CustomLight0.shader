Shader "Custom/CustomLight"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Normalmap", 2D) = "bump" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

		CGPROGRAM
		#pragma surface surf Test noambient

		sampler2D _MainTex;
		sampler2D _BumpMap;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Emission = c.rgb;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			o.Alpha = c.a;
		}
		float4 LightingTest(SurfaceOutput s, float3 lightDir, float atten) {
			return float4(1, 0, 0, 1);
		}
		ENDCG
	}
		FallBack "Diffuse"
}
