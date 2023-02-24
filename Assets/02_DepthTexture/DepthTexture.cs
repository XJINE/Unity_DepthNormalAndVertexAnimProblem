using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DepthTexture : MonoBehaviour
{
    public Material material;

    [SerializeField] private RenderTexture colorTexture;
    [SerializeField] private RenderTexture depthTexture;

    private void Start ()
    {
        var camera = GetComponent<Camera>();
        camera.depthTextureMode = DepthTextureMode.Depth;

        colorTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);
        colorTexture.Create();

        depthTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.Depth);
        depthTexture.Create();

        camera.SetTargetBuffers(colorTexture.colorBuffer, depthTexture.depthBuffer);
    }

    private void OnPostRender()
    {
        Graphics.SetRenderTarget(null);
        Graphics.Blit(depthTexture, material);
    }

    private void OnDisable()
    {
        Destroy(colorTexture);
        Destroy(depthTexture);
    }
}