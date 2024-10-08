using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovimentForCam : MonoBehaviour
{
    public float gridSize = 1.0f;
    public float moveSpeed = 5.0f;

    private Vector3 targetPosition;
    public GameObject inicial;

    public Vector3 cellSize = new Vector3(1.0f, 1.0f, 1.0f);
    public LayerMask groundLayer;

    void Start()
    {
        inicial = GameObject.FindGameObjectWithTag("Inicial");

        if (inicial != null)
        {
            Vector3 alignedStartPos = AlignToGrid(inicial.transform.position);
            transform.position = alignedStartPos;
            targetPosition = alignedStartPos;
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.W))
                direction = Vector3.forward;
            else if (Input.GetKeyDown(KeyCode.S))
                direction = Vector3.back;
            else if (Input.GetKeyDown(KeyCode.A))
                direction = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.D))
                direction = Vector3.right;

            if (direction != Vector3.zero)
            {
                Vector3 nextPosition = AlignToGrid(targetPosition + direction * gridSize);

                if (LogCurrentBlock(nextPosition))
                {
                    targetPosition = nextPosition;
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    Vector3 AlignToGrid(Vector3 position)
    {
        float x = Mathf.Floor(position.x / gridSize) * gridSize + gridSize / 2;
        float y = this.transform.position.y;
        float z = Mathf.Floor(position.z / gridSize) * gridSize + gridSize / 2;
        return new Vector3(x, y, z);
    }

    bool LogCurrentBlock(Vector3 position)
    {
        RaycastHit hit;
        Vector3 checkPosition = new Vector3(position.x, position.y + 0.5f, position.z);

        if (Physics.Raycast(checkPosition, Vector3.down, out hit, 1.0f, groundLayer))
        {
            Debug.Log("Pos " + position + " nome: " + hit.collider.gameObject.name);
            return true;
        }
        else
        {
            Debug.Log("Sem Chao " + position);
            return false;
        }
    }
}
