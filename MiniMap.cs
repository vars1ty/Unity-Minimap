using UnityEngine;

/// <summary>
/// A basic base for minimaps that don't rely on a second Camera with Render Textures which are both:
/// <para>1. Worse for performance as you are rendering a portion of the scene twice.</para>
/// <para>2. Worse for quality and artistic flexibility as you can't modify the Render Texture in a non-dirty way (e.g. add location names and additional details).</para>
/// <para>Made by narcotics#0911 @ https://github.com/qqtc0/Unity-Minimap</para>
/// </summary>
[DisallowMultipleComponent, AddComponentMenu("MiniMap/MiniMap Base")]
internal class MiniMap : MonoBehaviour
{
    #region Variables
    #region Editor
    [SerializeField, Tooltip("Camera transform")]
    private Transform cameraTransform;

    [SerializeField, Tooltip("Icon to move")]
    private RectTransform icon;

    [SerializeField, Tooltip("Target object to track")]
    private Transform trackTransform;

    [SerializeField, Tooltip("Icon spacing")]
    private float spacing = 5;
    #endregion
    #region Class
    /// <summary>
    /// Inverse value used in <see cref="ConvertPosition"/>.
    /// </summary>
    private Vector3 inverse;
    #endregion
    #endregion

    /// <summary>
    /// Updates the icon position.
    /// </summary>
    private void Update() => icon.anchoredPosition = ConvertPosition(trackTransform.position) * spacing;

    /// <summary>
    /// Converts world-space position to map-space position.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns>The position to be used for the map without any multiplications.</returns>
    private Vector2 ConvertPosition(Vector3 pos)
    {
        inverse = cameraTransform.InverseTransformPoint(pos);
        return new Vector2(inverse.x, inverse.z);
    }
}
