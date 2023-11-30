using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class InvincibilityEffect : MonoBehaviour
{
    private Renderer renderer;
    private CircleCollider2D circleCollider2D;

    private const float BlinkInterval = 0.15f;
    private const float PostBlinkDelay = 0.3f;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        renderer = GetComponent<Renderer>();
        // Rigidbody2Dを削除するか、無効にする
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D != null)
        {
            Destroy(rigidbody2D);
        }
    }

    public void ActivateInvincibility(int blinkCount)
    {
        circleCollider2D.enabled = false;
        StartCoroutine(StartInvincibilityEffect(blinkCount));
    }

    private IEnumerator StartInvincibilityEffect(int blinkCount)
    {
        renderer.enabled = false;

        for (int i = 0; i < blinkCount; i++)
        {
            yield return new WaitForSeconds(BlinkInterval);
            renderer.enabled = !renderer.enabled;
        }

        yield return new WaitForSeconds(PostBlinkDelay);

        renderer.enabled = true;
        circleCollider2D.enabled = true;
    }
}
