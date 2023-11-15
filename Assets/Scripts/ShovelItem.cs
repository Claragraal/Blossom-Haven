using UnityEngine;
using UnityEngine.UI;

public class ShovelItem : MonoBehaviour
{
    public Texture2D shovelCursorTexture;
    public Texture2D defaultCursorTexture;

    private bool isShovelActive = false;

    private void Start()
    {
        // Get hotkey button the shovel is on
        Button button = GetComponentInParent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(ToggleShovel);
        }
        else
        {
            Debug.LogError("Button component not found in parent!");
        }
    }

    private void ToggleShovel()
    {
        // If the seed is active, deactivate it
        SeedPlant seedPlant = FindObjectOfType<SeedPlant>();
        if (seedPlant != null && seedPlant.IsSeedActive())
        {
            seedPlant.DeactivateSeed();
        }

        // Active shovel & change cursor
        isShovelActive = !isShovelActive;

        if (isShovelActive)
        {
            Cursor.SetCursor(shovelCursorTexture, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    public bool IsShovelActive()
    {
        return isShovelActive;
    }

    public void DeactivateShovel()
    {
        // Deactivate shovel & set default cursor
        isShovelActive = false;
        Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
