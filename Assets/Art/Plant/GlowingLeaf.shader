// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32880,y:32800,varname:node_4013,prsc:2|diff-4204-RGB,emission-2937-OUT,lwrap-8237-RGB,alpha-4204-A;n:type:ShaderForge.SFN_Tex2d,id:4204,x:31982,y:32772,varname:node_4204,prsc:2,tex:6fdf810f1481876409deb2dd857dc785,ntxv:0,isnm:False|TEX-6160-TEX;n:type:ShaderForge.SFN_Tex2d,id:384,x:31982,y:32964,varname:node_384,prsc:2,tex:6fdf810f1481876409deb2dd857dc785,ntxv:0,isnm:False|TEX-6160-TEX;n:type:ShaderForge.SFN_Fresnel,id:6610,x:31982,y:33135,varname:node_6610,prsc:2|EXP-9195-OUT;n:type:ShaderForge.SFN_Lerp,id:8709,x:32245,y:33051,varname:node_8709,prsc:2|A-384-RGB,B-6610-OUT,T-9195-OUT;n:type:ShaderForge.SFN_Slider,id:9195,x:31520,y:33288,ptovrint:False,ptlb:Emission Amount (Fresnel),ptin:_EmissionAmountFresnel,varname:node_9195,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8632995,max:1;n:type:ShaderForge.SFN_Multiply,id:3493,x:32422,y:33051,varname:node_3493,prsc:2|A-384-RGB,B-8709-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6160,x:31662,y:32900,ptovrint:False,ptlb:node_6160,ptin:_node_6160,varname:node_6160,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6fdf810f1481876409deb2dd857dc785,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:7481,x:32028,y:33381,ptovrint:False,ptlb:Color Combination,ptin:_ColorCombination,varname:node_7481,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:2937,x:32498,y:33265,varname:node_2937,prsc:2|A-3493-OUT,B-3877-OUT;n:type:ShaderForge.SFN_Color,id:4032,x:32028,y:33580,ptovrint:False,ptlb:Second Color,ptin:_SecondColor,varname:node_4032,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.02789795,c2:0.03424708,c3:0.9485294,c4:1;n:type:ShaderForge.SFN_Lerp,id:3877,x:32242,y:33500,varname:node_3877,prsc:2|A-7481-RGB,B-4032-RGB,T-9195-OUT;n:type:ShaderForge.SFN_LightColor,id:8237,x:32532,y:32884,varname:node_8237,prsc:2;proporder:9195-6160-7481-4032;pass:END;sub:END;*/

Shader "Shader Forge/GlowingLeaf" {
    Properties {
        _EmissionAmountFresnel ("Emission Amount (Fresnel)", Range(0, 1)) = 0.8632995
        _node_6160 ("node_6160", 2D) = "white" {}
        _ColorCombination ("Color Combination", Color) = (1,0,0,1)
        _SecondColor ("Second Color", Color) = (0.02789795,0.03424708,0.9485294,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _EmissionAmountFresnel;
            uniform sampler2D _node_6160; uniform float4 _node_6160_ST;
            uniform float4 _ColorCombination;
            uniform float4 _SecondColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = _LightColor0.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_4204 = tex2D(_node_6160,TRANSFORM_TEX(i.uv0, _node_6160));
                float3 diffuseColor = node_4204.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_384 = tex2D(_node_6160,TRANSFORM_TEX(i.uv0, _node_6160));
                float node_6610 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_EmissionAmountFresnel);
                float3 emissive = ((node_384.rgb*lerp(node_384.rgb,float3(node_6610,node_6610,node_6610),_EmissionAmountFresnel))*lerp(_ColorCombination.rgb,_SecondColor.rgb,_EmissionAmountFresnel));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,node_4204.a);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _EmissionAmountFresnel;
            uniform sampler2D _node_6160; uniform float4 _node_6160_ST;
            uniform float4 _ColorCombination;
            uniform float4 _SecondColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation,i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = _LightColor0.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float4 node_4204 = tex2D(_node_6160,TRANSFORM_TEX(i.uv0, _node_6160));
                float3 diffuseColor = node_4204.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * node_4204.a,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
