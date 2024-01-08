using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashingSystem : MonoBehaviour
{
    private Texture2D currentMask;
    [SerializeField] private Texture2D og_Mask;
    private Renderer render;
    public Texture2D[] splashs;
    
    private Color32[] currentTextureColors;
    public Vector2 lastCoordsHit;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    //Agregar funcion para no reemplazar textura original

    public void SplashOnTexture(Vector3 textureCoord, Material render, Color c)
    {
        Texture2D mask = render.GetTexture("_StainMask") as Texture2D;
        if (mask is null) return;
        if (render.GetFloat("_Stainable") < 0.5) return;

        currentMask = new Texture2D(mask.width, mask.height, mask.format, mask.mipmapCount > 1);
        render.SetTexture("_StainMask", currentMask);
        
        Texture2D splash = splashs[Random.Range(0, splashs.Length)];

        currentTextureColors = splash.GetPixels32();

        for (int i = 0; i < currentTextureColors.Length; i++)
            if (currentTextureColors[i] == Color.white) currentTextureColors[i] = c;
        mask.SetPixels32((int)(textureCoord.x * mask.width), (int)(textureCoord.z * mask.height), splash.width, splash.height, currentTextureColors);
        mask.Apply();
        render.SetTexture("_StainMask", mask);
    }

    private void Splash(Texture2D texture, Vector3 coordinates, Color32[] pixels)
    {
        currentMask.SetPixels32((int)(coordinates.x * texture.width), (int)(coordinates.z * texture.height), texture.width, texture.height, currentTextureColors);
        currentMask.Apply();
        render.material.SetTexture("_StainMask", currentMask);
    }
}
