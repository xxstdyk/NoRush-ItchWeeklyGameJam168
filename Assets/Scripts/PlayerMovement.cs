using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 1f;

    void Start() {

    }

    void Update() {

    }

    void FixedUpdate() {

        float leftRight = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(leftRight, 0f))
            leftRight = leftRight < 0f ? -1f : 1f;

        Vector2 targetVelocity = new Vector2()

    }

}
