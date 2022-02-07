using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Unity lifecycle

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 currentPosition = transform.position;
        currentPosition.x = worldPosition.x;
        transform.position = currentPosition;
    }

    #endregion
}
