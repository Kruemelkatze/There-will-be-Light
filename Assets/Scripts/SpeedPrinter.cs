using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPrinter : MonoBehaviour
{

    public Text text;
    public bool Enabled = true;

    private Rigidbody2D rigid;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Enabled)
        {
            text.text = $"{rigid.velocity.x} {rigid.velocity.y}";
        } else
        {
            text.text = "";
        }
    }
}
