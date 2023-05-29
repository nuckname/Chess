using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    //disable script isnt currently working and is mannualy disabled.
    private RandomiseCanMoveCircles randomiseCanMoveCircles;
    public bool enableRandomiseCircles = false;

    // Start is called before the first frame update
    private void Awake()
    {
        randomiseCanMoveCircles = FindObjectOfType<RandomiseCanMoveCircles>();
    }

    void Start()
    {
        randomiseCanMoveCircles.enabled = false;
        enableRandomiseCircles = false;
    }
}
