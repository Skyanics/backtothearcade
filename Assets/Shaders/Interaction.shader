// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32850,y:32688,varname:node_4013,prsc:2|emission-7307-OUT,clip-7007-A;n:type:ShaderForge.SFN_Tex2d,id:7007,x:32402,y:32630,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_7007,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bf512205d73e8544b871c5b3bda8698a,ntxv:0,isnm:False|UVIN-1981-OUT;n:type:ShaderForge.SFN_VertexColor,id:5120,x:32402,y:32793,varname:node_5120,prsc:2;n:type:ShaderForge.SFN_Color,id:1596,x:32402,y:32942,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1596,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.8758622,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:5950,x:32402,y:33112,ptovrint:False,ptlb:Emissive Value,ptin:_EmissiveValue,varname:node_5950,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:7307,x:32626,y:32826,varname:node_7307,prsc:2|A-7007-RGB,B-5120-RGB,C-1596-RGB,D-5950-OUT,E-6161-OUT;n:type:ShaderForge.SFN_Multiply,id:6161,x:32664,y:33234,varname:node_6161,prsc:2|A-7007-A,B-3312-R;n:type:ShaderForge.SFN_Tex2d,id:3312,x:32402,y:33219,ptovrint:False,ptlb:Emissive Alpha,ptin:_EmissiveAlpha,varname:node_3312,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9470468fda72f4773a90a0306decbf0f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:1981,x:32115,y:32656,varname:node_1981,prsc:2|A-9487-OUT,B-6557-OUT;n:type:ShaderForge.SFN_Multiply,id:6557,x:31850,y:32714,varname:node_6557,prsc:2|A-528-T,B-8910-OUT;n:type:ShaderForge.SFN_Time,id:528,x:31485,y:32668,varname:node_528,prsc:2;n:type:ShaderForge.SFN_Append,id:8910,x:31629,y:32807,varname:node_8910,prsc:2|A-2676-OUT,B-6314-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2676,x:31376,y:32866,ptovrint:False,ptlb:U Speed (Main),ptin:_USpeedMain,varname:node_2676,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:6314,x:31376,y:32965,ptovrint:False,ptlb:V Speed (Main),ptin:_VSpeedMain,varname:node_6314,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Lerp,id:9487,x:32022,y:32365,varname:node_9487,prsc:2|A-1705-UVOUT,B-5457-OUT,T-4522-R;n:type:ShaderForge.SFN_Tex2d,id:4522,x:31729,y:32388,ptovrint:False,ptlb:Noise Mask,ptin:_NoiseMask,varname:node_4522,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0b4c1564f776ac24f9df3708f138aeb6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:5457,x:31729,y:32228,varname:node_5457,prsc:2|A-7241-UVOUT,B-9922-R,T-6841-OUT;n:type:ShaderForge.SFN_TexCoord,id:1705,x:31729,y:32068,varname:node_1705,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:9922,x:31409,y:32303,ptovrint:False,ptlb:Noise Texture,ptin:_NoiseTexture,varname:node_9922,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1592-OUT;n:type:ShaderForge.SFN_Slider,id:6841,x:31330,y:32527,ptovrint:False,ptlb:Noise Amount,ptin:_NoiseAmount,varname:node_6841,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_TexCoord,id:7241,x:31409,y:32117,varname:node_7241,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:1592,x:31110,y:32308,varname:node_1592,prsc:2|A-7710-UVOUT,B-4632-OUT;n:type:ShaderForge.SFN_TexCoord,id:7710,x:30837,y:32032,varname:node_7710,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4632,x:30855,y:32382,varname:node_4632,prsc:2|A-1756-T,B-4192-OUT;n:type:ShaderForge.SFN_Time,id:1756,x:30573,y:32281,varname:node_1756,prsc:2;n:type:ShaderForge.SFN_Append,id:4192,x:30677,y:32554,varname:node_4192,prsc:2|A-2689-OUT,B-539-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2689,x:30412,y:32511,ptovrint:False,ptlb:U Speed (Noise),ptin:_USpeedNoise,varname:node_2689,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:539,x:30412,y:32598,ptovrint:False,ptlb:V Speed (Noise),ptin:_VSpeedNoise,varname:node_539,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:7007-1596-5950-3312-2676-6314-4522-9922-6841-2689-539;pass:END;sub:END;*/

Shader "Shader Forge/Interaction" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (0,1,0.8758622,1)
        _EmissiveValue ("Emissive Value", Float ) = 2
        _EmissiveAlpha ("Emissive Alpha", 2D) = "white" {}
        _USpeedMain ("U Speed (Main)", Float ) = 0.1
        _VSpeedMain ("V Speed (Main)", Float ) = 0.1
        _NoiseMask ("Noise Mask", 2D) = "white" {}
        _NoiseTexture ("Noise Texture", 2D) = "white" {}
        _NoiseAmount ("Noise Amount", Range(0, 1)) = 1
        _USpeedNoise ("U Speed (Noise)", Float ) = 0.1
        _VSpeedNoise ("V Speed (Noise)", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _Color;
            uniform float _EmissiveValue;
            uniform sampler2D _EmissiveAlpha; uniform float4 _EmissiveAlpha_ST;
            uniform float _USpeedMain;
            uniform float _VSpeedMain;
            uniform sampler2D _NoiseMask; uniform float4 _NoiseMask_ST;
            uniform sampler2D _NoiseTexture; uniform float4 _NoiseTexture_ST;
            uniform float _NoiseAmount;
            uniform float _USpeedNoise;
            uniform float _VSpeedNoise;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 node_1756 = _Time;
                float2 node_1592 = (i.uv0+(node_1756.g*float2(_USpeedNoise,_VSpeedNoise)));
                float4 _NoiseTexture_var = tex2D(_NoiseTexture,TRANSFORM_TEX(node_1592, _NoiseTexture));
                float4 _NoiseMask_var = tex2D(_NoiseMask,TRANSFORM_TEX(i.uv0, _NoiseMask));
                float4 node_528 = _Time;
                float2 node_1981 = (lerp(i.uv0,lerp(i.uv0,float2(_NoiseTexture_var.r,_NoiseTexture_var.r),_NoiseAmount),_NoiseMask_var.r)+(node_528.g*float2(_USpeedMain,_VSpeedMain)));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_1981, _Texture));
                clip(_Texture_var.a - 0.5);
////// Lighting:
////// Emissive:
                float4 _EmissiveAlpha_var = tex2D(_EmissiveAlpha,TRANSFORM_TEX(i.uv0, _EmissiveAlpha));
                float3 emissive = (_Texture_var.rgb*i.vertexColor.rgb*_Color.rgb*_EmissiveValue*(_Texture_var.a*_EmissiveAlpha_var.r));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _USpeedMain;
            uniform float _VSpeedMain;
            uniform sampler2D _NoiseMask; uniform float4 _NoiseMask_ST;
            uniform sampler2D _NoiseTexture; uniform float4 _NoiseTexture_ST;
            uniform float _NoiseAmount;
            uniform float _USpeedNoise;
            uniform float _VSpeedNoise;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_1756 = _Time;
                float2 node_1592 = (i.uv0+(node_1756.g*float2(_USpeedNoise,_VSpeedNoise)));
                float4 _NoiseTexture_var = tex2D(_NoiseTexture,TRANSFORM_TEX(node_1592, _NoiseTexture));
                float4 _NoiseMask_var = tex2D(_NoiseMask,TRANSFORM_TEX(i.uv0, _NoiseMask));
                float4 node_528 = _Time;
                float2 node_1981 = (lerp(i.uv0,lerp(i.uv0,float2(_NoiseTexture_var.r,_NoiseTexture_var.r),_NoiseAmount),_NoiseMask_var.r)+(node_528.g*float2(_USpeedMain,_VSpeedMain)));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_1981, _Texture));
                clip(_Texture_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
