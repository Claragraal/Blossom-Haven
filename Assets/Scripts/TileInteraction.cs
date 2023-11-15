using UnityEngine;

public class TileInteraction : MonoBehaviour
{
    public Sprite dirtSprite;
    public Sprite grassSprite;
    public Sprite shoveledDirtSprite;
    public Sprite seededDirtSprite;

private void OnMouseDown()
{
    // Check if shovel or seed is equipped or not
    ShovelItem shovelItem = FindObjectOfType<ShovelItem>();
    SeedPlant seedPlant = FindObjectOfType<SeedPlant>();

    if (shovelItem != null && shovelItem.IsShovelActive())
    {
        Debug.Log("Shovel is active");
        ShovelAction();
    }
    else if (seedPlant != null && seedPlant.IsSeedActive())
    {
        Debug.Log("Seed is active");
        
        // If shovel is active, deactivate it before handling seed action
        if (shovelItem != null)
        {
            shovelItem.DeactivateShovel();
        }
        
        SeedAction();
    }
    else
    {
        Debug.Log("Nothing is active");
    }
}

    private void ShovelAction()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            if (spriteRenderer.sprite == grassSprite)
            {
                spriteRenderer.sprite = dirtSprite;
                Debug.Log("Changed to dirt");
            }
            else if (spriteRenderer.sprite == dirtSprite)
            {
                spriteRenderer.sprite = shoveledDirtSprite;
                Debug.Log("Changed to shoveled dirt");
            }
            // Add more conditions if needed for other tile types
            // Plants won't be tiles, but rather separate objects on top of them
            else
            {
                Debug.Log("No matching texture found");
            }
        }
        else
        {
            Debug.LogError("SpriteRenderer not found!");
        }
    }

    private void SeedAction()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            if (spriteRenderer.sprite == shoveledDirtSprite)
            {
                spriteRenderer.sprite = seededDirtSprite;
            }
        }
    }
}
