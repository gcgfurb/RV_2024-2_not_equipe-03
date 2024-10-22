using UnityEngine;

public class BodyFollowRotation : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 2.0f;
    public float smoothTime = 0.5f;
    public float rotationThreshold = 1.0f;

    private float velocity;
    private float lastTargetYRotation;

    void Start()
    {
        // Armazena a rota��o inicial para comparar com futuras rota��es
        if (target != null)
            lastTargetYRotation = target.eulerAngles.y;
    }

    void Update()
    {
        if (target != null)
        {
            float targetYRotation = target.eulerAngles.y;

            // Verifica se a diferen�a de rota��o � significativa para evitar loops infinitos
            float rotationDifference = Mathf.Abs(targetYRotation - lastTargetYRotation);

            if (rotationDifference > rotationThreshold)
            {
                float currentYRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetYRotation, ref velocity, smoothTime);
                transform.rotation = Quaternion.Euler(0, currentYRotation, 0);

                // Atualiza a �ltima rota��o para comparar na pr�xima itera��o
                lastTargetYRotation = targetYRotation;
            }
        }
    }
}
