// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33001,y:32663,varname:node_4013,prsc:2|diff-3055-OUT,emission-3055-OUT,alpha-4726-OUT;n:type:ShaderForge.SFN_Fresnel,id:6203,x:31977,y:32635,varname:node_6203,prsc:2|EXP-1679-OUT;n:type:ShaderForge.SFN_Slider,id:1679,x:31654,y:32662,ptovrint:False,ptlb:node_1679,ptin:_node_1679,varname:node_1679,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8290598,max:1;n:type:ShaderForge.SFN_Fresnel,id:6218,x:32140,y:32635,varname:node_6218,prsc:2|EXP-6203-OUT;n:type:ShaderForge.SFN_OneMinus,id:1497,x:32300,y:32635,varname:node_1497,prsc:2|IN-6218-OUT;n:type:ShaderForge.SFN_Add,id:4463,x:32471,y:32635,varname:node_4463,prsc:2|A-1497-OUT,B-1497-OUT;n:type:ShaderForge.SFN_Blend,id:3055,x:32709,y:32727,varname:node_3055,prsc:2,blmd:10,clmp:True|SRC-4463-OUT,DST-6881-OUT;n:type:ShaderForge.SFN_Color,id:3166,x:32140,y:32882,ptovrint:False,ptlb:node_3166,ptin:_node_3166,varname:node_3166,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1740377,c2:0.5626298,c3:0.6397059,c4:1;n:type:ShaderForge.SFN_Fresnel,id:5452,x:32140,y:33028,varname:node_5452,prsc:2|EXP-1679-OUT;n:type:ShaderForge.SFN_Slider,id:4726,x:32295,y:33091,ptovrint:False,ptlb:node_4726,ptin:_node_4726,varname:node_4726,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4921859,max:1;n:type:ShaderForge.SFN_Lerp,id:6881,x:32424,y:32913,varname:node_6881,prsc:2|A-3166-RGB,B-5452-OUT,T-4726-OUT;proporder:1679-3166-4726;pass:END;sub:END;*/

Shader "Shader Forge/Nut" {
    Properties {
        _node_1679 ("node_1679", Range(0, 1)) = 0.8290598
        _node_3166 ("node_3166", Color) = (0.1740377,0.5626298,0.6397059,1)
        _node_4726 ("node_4726", Range(0, 1)) = 0.4921859
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
            uniform float _node_1679;
            uniform float4 _node_3166;
            uniform float _node_4726;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
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
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_1497 = (1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_1679)));
                float node_5452 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_1679);
                float3 node_3055 = saturate(( lerp(_node_3166.rgb,float3(node_5452,node_5452,node_5452),_node_4726) > 0.5 ? (1.0-(1.0-2.0*(lerp(_node_3166.rgb,float3(node_5452,node_5452,node_5452),_node_4726)-0.5))*(1.0-(node_1497+node_1497))) : (2.0*lerp(_node_3166.rgb,float3(node_5452,node_5452,node_5452),_node_4726)*(node_1497+node_1497)) ));
                float3 diffuseColor = node_3055;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_3055;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,_node_4726);
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
            uniform float _node_1679;
            uniform float4 _node_3166;
            uniform float _node_4726;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
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
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_1497 = (1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_1679)));
                float node_5452 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_1679);
                float3 node_3055 = saturate(( lerp(_node_3166.rgb,float3(node_5452,node_5452,node_5452),_node_4726) > 0.5 ? (1.0-(1.0-2.0*(lerp(_node_3166.rgb,float3(node_5452,node_5452,node_5452),_node_4726)-0.5))*(1.0-(node_1497+node_1497))) : (2.0*lerp(_node_3166.rgb,float3(node_5452,node_5452,node_5452),_node_4726)*(node_1497+node_1497)) ));
                float3 diffuseColor = node_3055;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * _node_4726,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
