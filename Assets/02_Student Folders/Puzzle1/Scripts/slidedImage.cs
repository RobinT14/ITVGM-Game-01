using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidedImage : MonoBehaviour
{

    public event System.Action<slidedImage> chosenElement;

    public void Init(Texture2D image) {
      GetComponent<MeshRenderer>().material.mainTexture = image;
    }

    void OnMouseDown()
    {
      if (chosenElement != null)   
        chosenElement(this);
    }

    public static Texture2D[,] SliceImage(Texture2D image, int numberOfQuads)
    {
      int imageSize = Mathf.Min(image.width, image.height);
      int quadSize = imageSize / numberOfQuads;

      Texture2D[,] quads = new Texture2D[numberOfQuads, numberOfQuads];
      for(int j = 0; j < numberOfQuads; j++)  
      {
         for(int i = 0; i < numberOfQuads; i++)   
         {
           Texture2D quad = new Texture2D(quadSize, quadSize);
           quad.wrapMode = TextureWrapMode.Clamp;
           quad.SetPixels(image.GetPixels(i*quadSize,j*quadSize, quadSize, quadSize));
           quad.Apply();
           quads[i,j] = quad;
         }
       }
       return quads;
    }
}
