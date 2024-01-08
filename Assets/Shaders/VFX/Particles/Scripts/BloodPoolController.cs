using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodPoolController : MonoBehaviour
{
    [SerializeField] private int maxStainInSpace;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private StainSys[] bloodStains;
    public static BloodPoolController instance;
    private int currentIndex = 0;

    private void Awake(){ instance = FindAnyObjectByType<BloodPoolController>(); }
    private void Start()
    {
        InitializePool();
    }
    public void InitializePool()
    {
        List<StainSys> textures = new();
        int rnd = 0;
        for (int i = 0; i < maxStainInSpace; i++)
        {
            rnd = Random.Range(0, prefabs.Length);
            textures.Add(Instantiate(prefabs[rnd], transform).GetComponent<StainSys>());
            textures[i].Init(lifeTime);
        }
        bloodStains = textures.ToArray();
        textures.Clear();
    }
    public void SetNewStain(Vector3 position, Vector3 direction)
    {
        currentIndex++;
        if (currentIndex == bloodStains.Length) currentIndex = 0;
        bloodStains[currentIndex].SetStain(position, direction);
    }
}
