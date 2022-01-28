using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{
    // Start is called before the first frame update
    static int charId;
    void Start()
    {
        charId = -1;
    }

    void SetCharId(int id)
    {
        charId = id;
    }
}
