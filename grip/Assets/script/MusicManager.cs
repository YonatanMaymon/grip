using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioManager adm;

    private void Awake()
    {
        adm.Play("music", true);
    }

}
