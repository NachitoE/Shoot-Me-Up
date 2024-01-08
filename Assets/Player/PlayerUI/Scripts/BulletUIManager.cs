using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUIManager : MonoBehaviour
{
    public SGController shotgun;
    public GameObject bulletTexture;
    public List<GameObject> bullets = new List<GameObject>();

    public void Start()
    {
        for(int i = 0; i < shotgun.Ammo; i++)
        {
            bullets.Add(Instantiate(bulletTexture, transform));
            if(i!=0) bullets[i].transform.position += (new Vector3(bullets[i - 1].transform.position.x - 10, 0, 0));

        }
        shotgun.OnShot += UpdateBulletIndicator;

    }

    private void UpdateBulletIndicator()
    {
        if(shotgun.currAmmo < shotgun.Ammo)
        {
            bullets[shotgun.currAmmo].SetActive(false);
            if (shotgun.currAmmo <= 0) StartCoroutine(WaitForReload());
        }
    }

    IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(shotgun.reloadTime);
        foreach (GameObject b in bullets) b.SetActive(true);
    }
}
