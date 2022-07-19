using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    [SerializeField] private float blinkCooldown;
    [SerializeField] private int framesPerBlink;
    [SerializeField] private List<Texture> eyeTextures;

    private int index;
    private Material eyesMaterial;

    private void Start(){
        index = 0;
        eyesMaterial = GetComponent<SkinnedMeshRenderer>().materials[1];
        ChangeTexture();
    }

    private void ChangeTexture(){
        StartCoroutine(ChangeTextureCoroutine());
    }

    private IEnumerator ChangeTextureCoroutine(){
        float frame = 0;
        while(frame < framesPerBlink){
            yield return null;
            frame++;
        }
        if(++index == eyeTextures.Count){
            index = 0;
            eyesMaterial.mainTexture = eyeTextures[index];
            yield return BlinkCooldownCoroutine();
        }else{
            eyesMaterial.mainTexture = eyeTextures[index];
        }
        ChangeTexture();
    }

    private IEnumerator BlinkCooldownCoroutine(){
        yield return new WaitForSeconds(blinkCooldown);
    }
}
