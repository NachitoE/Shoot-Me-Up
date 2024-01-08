using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainSys : MonoBehaviour
{
    public Transform textureT;
    public Renderer render;
    private float lifeTime;
    private IEnumerator behaviour;
    private Vector3 lastModifiedAngles;
    public void Init(float _lifeTime)
    {
        lifeTime = _lifeTime;
        render.material.SetFloat("_Intensity", 0);
        behaviour = StainLife();
        textureT.transform.position = new Vector3(999, 999);
    }

    public void SetStain(Vector3 position, Vector3 direction)
    {
        if(behaviour != null) StopCoroutine(behaviour);
        textureT.position = position;
        textureT.rotation = Quaternion.LookRotation(direction);
        render.material.SetFloat("_Intensity", 1);
        lastModifiedAngles = textureT.rotation.eulerAngles;
        textureT.rotation = Quaternion.Euler(new(lastModifiedAngles.x, lastModifiedAngles.y, Random.Range(0, 360)));
        StartCoroutine(behaviour);
    }


    private IEnumerator StainLife()
    {
        yield return new WaitForSeconds(lifeTime);
        float time = 0;
        float finalTime = 10;
        float currentIntensity;
        while(time < finalTime)
        {
            time += Time.fixedDeltaTime;
            currentIntensity = render.material.GetFloat("_Intensity") - (Time.fixedDeltaTime / finalTime);
            render.material.SetFloat("_Intensity", currentIntensity);
            yield return null;
        }
    }
}
