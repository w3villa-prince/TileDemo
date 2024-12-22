using UnityEngine;

public class BrickPatternGenerator : MonoBehaviour
{
    public GameObject brickPrefab; // Assign the BrickPrefab
    public Transform container; // Assign the container Transform
    public float brickHeight = 0.5f;
    public float minBrickWidth = 1f;
    public float maxBrickWidth = 2f;
    public float gap = 0.1f;

    public void GeneratePattern(Texture2D texture)
    {
        // Clear existing bricks
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        float containerWidth = 10f; // Example width
        float currentX = 0f;
        float currentY = 0f;

        while (currentY < containerWidth)
        {
            float brickWidth = Random.Range(minBrickWidth, maxBrickWidth);

            // Check if brick overflows the container
            if (currentX + brickWidth + gap > containerWidth)
            {
                currentX = 0f;
                currentY += brickHeight + gap;
            }

            // Create a new brick
            GameObject brick = Instantiate(brickPrefab, container);
            brick.transform.localScale = new Vector3(brickWidth, brickHeight, 1);
            brick.transform.localPosition = new Vector3(currentX + brickWidth / 2, -currentY, 0);

            // Assign texture
            if (texture != null)
            {
                Renderer renderer = brick.GetComponent<Renderer>();
                renderer.material.mainTexture = texture;
            }

            currentX += brickWidth + gap;
        }
    }
}