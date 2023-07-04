using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { White, Black, Won, Lost }

public class TurnSystem : MonoBehaviour
{
    public State state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = State.White;
    }

}
