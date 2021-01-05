using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDisappear : MonoBehaviour
{
    public float lifeTime = 1;
    void Start()
    {
        Invoke("DestroyEff", lifeTime);
    }

    void DestroyEff(){
        Destroy(gameObject);
    }
}
