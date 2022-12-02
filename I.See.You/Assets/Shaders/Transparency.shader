Shader "Custom/Transparency"
{
    Properties{
      _MainTex("Texture", 2D) = "white" {}
    _Color("Color (RGBA", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
          Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "LightMode" = "ForwardBase" }
        Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

          CGPROGRAM
    //#pragma surface surf Lambert
    #pragma surface surf Lambert alpha:fade
    #pragma surface surf Lambert fullforwardshadows
//        #pragma target 4.0
//#pragma vertex vert
//#pragma fragment frag
      //#pragma vertex vert
      //#pragma fragment frag
      #include "UnityCG.cginc"

    struct Input {
    //float2 uv_MainTex;
float4 color: _Color;
  };

//sampler2D _MainTex;
float4 _Color;

void surf(Input IN, inout SurfaceOutput o) {
    //o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
    o.Albedo = _Color;
    //o.Albedo = tex2D(_Color, IN.uv_Color).rgb;
    o.Alpha = _Color.a;
}
ENDCG
    }
        Fallback "Diffuse"

}
