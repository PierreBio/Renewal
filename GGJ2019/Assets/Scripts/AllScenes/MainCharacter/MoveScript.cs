using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    /// <summary>
    /// 1 - La vitesse de déplacement
    /// </summary>
    public Vector2 speed = new Vector2(50, 0);
    public Rigidbody2D rigidbody2d;

    // 2 - Stockage du mouvement
    private Vector2 movement;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // 3 - Récupérer les informations du clavier/manette
        float inputX = Input.GetAxis("Horizontal");

        // 4 - Calcul du mouvement
        movement = new Vector2(
          speed.x * inputX,
          speed.y);

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );

    }

    void FixedUpdate()
    {
        // 5 - Déplacement
        rigidbody2d.velocity = movement;
    }
}
