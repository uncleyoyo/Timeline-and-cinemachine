using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform shipTransform;
    [SerializeField] float followSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
      
        if (shipTransform == null)
            Debug.LogError("ship transform not found");
    }

    // Update is called once per frame
    void Update()
    {
        if (shipTransform != null)
            MoveCamera(shipTransform);
    }

    void MoveCamera(Transform parentTransform)
    {
        Vector3 targetPostion = shipTransform.position;

        parentTransform.position = Vector3.Lerp(parentTransform.position, targetPostion, followSpeed* Time.deltaTime);
    }
}
