using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyAnim : MonoBehaviour
{
    public Bird bird;

    void OnGetRadyAnimEnds()
    {
        bird.OnGetReadyAnimFinished();
    }
}
