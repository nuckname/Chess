using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampersand : MonoBehaviour
{
    // Start is called before the first frame update
    public void SpawnGameObjectBehindTile()
    {
        Instantiate(gameObject, new Vector3(-1, -1, -3), Quaternion.identity);
    }
}
