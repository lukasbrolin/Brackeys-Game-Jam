using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    public Transform car;

    // Update is called once per frame
    private void Awake()
    {
        this.transform.position = new Vector2(car.position.x, car.position.y);
    }

    void Update()
    {
        this.transform.position = new Vector2(car.position.x, car.position.y);
        Debug.Log(car.position);
    }
}
