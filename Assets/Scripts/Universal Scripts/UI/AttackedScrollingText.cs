using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedScrollingText : MonoBehaviour
{
    public ScrollingText Text;
    public Color TextColor;
    public float yOffset;

    public void OnAttack(float damage)
    {
        var text = damage.ToString();

        var scrollingText = Instantiate(Text, transform.position + Vector3.up * yOffset, Quaternion.identity);
        scrollingText.SetText(text);
        scrollingText.SetColor(TextColor);
    }
}
