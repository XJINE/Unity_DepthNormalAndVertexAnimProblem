# Unity_DepthNormalAndVertexAnimProblem

<img src="https://github.com/XJINE/Unity_DepthNormalAndVertexAnimProblem/blob/main/01_DepthNormals.png" width="100%" height="auto" />

```c
// Object shader
v2f vert (appdata_base v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex * 2);
    return o;
}

// ImageEffect shader
sampler2D _CameraDepthNormalsTexture;

float4 frag(v2f_img input) : SV_Target
{
    float  depth;
    float3 normal;

    DecodeDepthNormal(tex2D(_CameraDepthNormalsTexture, input.uv), depth, normal);

    return float4(depth.rrr, 1);
    return float4(normal, 1);
}
```

`_CameraDepthNormalsTexture` shows object depth( and normal) as it is even its modified in vertex shader.

<img src="https://github.com/XJINE/Unity_DepthNormalAndVertexAnimProblem/blob/main/02_DepthTexture.png" width="100%" height="auto" />

```c
camera.depthTextureMode = DepthTextureMode.Depth;

colorTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);
depthTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.Depth);

camera.SetTargetBuffers(colorTexture.colorBuffer, depthTexture.depthBuffer);
```

By using `SetTargetBuffers`, the depth looks correct. But it cannot get normal.
