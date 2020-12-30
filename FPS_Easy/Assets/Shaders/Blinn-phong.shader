Shader "Custom/Blinn-phong"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

		CGPROGRAM
		#pragma surface surf BlinnPhong

		sampler2D _MainTex;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Emission = c.rgb;
			o.Specular = 0.5;
			o.Gloss = 1;
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}