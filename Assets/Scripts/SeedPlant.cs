using UnityEngine;
using UnityEngine.UI;

public class SeedPlant : MonoBehaviour
{
    public Texture2D seedCursorTexture;
    public Texture2D defaultCursorTexture;

    private bool isSeedActive = false;

    private void Start()
    {
        // Get hotkey button the seed is on
        Button button = GetComponentInParent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(ToggleSeed);
        }
        else
        {
            Debug.LogError("Button component not found in parent!");
        }
    }

    private void ToggleSeed()
{
    // If the shovel is active, deactivate it
    ShovelItem shovelItem = FindObjectOfType<ShovelItem>();
    if (shovelItem != null && shovelItem.IsShovelActive())
    {
        shovelItem.DeactivateShovel();
    }

    // Active seed & change cursor
    isSeedActive = !isSeedActive;

    if (isSeedActive)
    {
        Cursor.SetCursor(seedCursorTexture, Vector2.zero, CursorMode.Auto);
    }
    else
    {
        // Make sure this line sets the cursor to the default texture
        Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
    }
}


    public bool IsSeedActive()
    {
        return isSeedActive;
    }

    // Add this method to deactivate the seed
    public void DeactivateSeed()
    {
        isSeedActive = false;
        // Add any other necessary cleanup or actions for deactivating the seed
    }
}
