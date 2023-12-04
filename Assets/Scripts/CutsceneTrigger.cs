using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"   )  
        {
            playableDirector.Play();
        }
    }
}
