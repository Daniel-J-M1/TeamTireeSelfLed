// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/EnemyWallOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AltTex("Texture", 2D) = "white" {}
        [Space(10)]
        _OutColor ("Outline Colour", Color) = (1, 1, 1, 1)
        _OutValue ("Outline Value", Range(0.0, 0.2)) = 0.1
        _Colour ("Color (RGBA", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        /*Pass for Outline*/
        Pass
        {
            Tags
            {
                "Queue" = "Transparent"
            }

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _OutColor;
            float _OutValue;

            float4 outline(float4 VertexPos, float outValue) 
            {
                float4x4 Scale = float4x4
                    (
                        1 + outValue, 0, 0, 0,
                        0, 1 + outValue, 0, 0,
                        0, 0, 1 + outValue, 0,
                        0, 0, 0, 1 + outValue
                        );
                    return mul(Scale, VertexPos);
            }



            v2f vert (appdata v)
            {
                v2f o;
                float4 VertexPos = outline(v.vertex, _OutValue);
                o.vertex = UnityObjectToClipPos(VertexPos);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                return float4(_OutColor.r, _OutColor.g, _OutColor.b, col.a);
            }
                
                ENDCG
                ZTest Greater
                //Lighting Off
                //Color[_OutColor]
        }



        //    //Pass for Outline Middle
        //Pass
        //{
        //    Tags
        //    {
        //        "Queue" = "Transparent"
        //        "IgnoreProjector" = "True"
        //        "RenderType" = "Transparent"
        //    }

        //    Blend SrcAlpha OneMinusSrcAlpha
        //    ZWrite Off
        //    Cull front
        //    LOD 100


        //    CGPROGRAM
        //    #pragma vertex vert alpha
        //    #pragma fragment frag alpha
        //    #include "UnityCG.cginc"

        //    struct appdata_t
        //    {
        //        float4 vertex : POSITION;
        //        float2 texcoord : TEXCOORD0;
        //    };

        //    struct v2f
        //    {
        //        float4 vertex : SV_POSITION;
        //        half2 texcoord : TEXCOORD0;
        //    };

        //    sampler2D _MainTex;
        //    float4 _MainTex_ST;
        //    float4 _Colour;

        //    v2f vert(appdata_t v)
        //    {
        //        v2f o;

        //        o.vertex = UnityObjectToClipPos(v.vertex);
        //        v.texcoord.x = 1 - v.texcoord.x;
        //        o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
        //        return o;
        //    }

        //    fixed4 frag(v2f i) : SV_Target
        //    {
        //        // sample the texture
        //        fixed4 col = tex2D(_MainTex, i.texcoord) * _Colour;
        //        return col;
        //    }

        //                    ENDCG
        //                    ZTest Greater
        //                    Lighting Off
        //        SetTexture[_MainTex]{ combine texture }
        //            }

        //Pass for Texture
        Pass
        {
                Tags
                {
                    "Queue" = "Transparent + 1"
                }



            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
                Blend SrcAlpha OneMinusSrcAlpha
                ZTest Greater
                //SetTexture [_MainTex] {combine texture}
        }
            //Pass for Texture
        Pass
        {
                Tags
                {
                    "Queue" = "Transparent + 1"
                }

                

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"


            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
                Blend SrcAlpha OneMinusSrcAlpha
                ZTest Less
                //SetTexture [_MainTex] {combine texture}
        }
    }
}
