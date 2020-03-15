using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedScrollingText : MonoBehaviour
{
    public ScrollingText Text;
    public Color normalTextColor;
    public Color criticalColor;
    public float yOffset;

    public void OnAttack(float damage, bool critical)
    {
        var text = damage.ToString();

        if (critical)
        {
            Debug.Log("Critical damage: " + text);
        }
        else
        {
            Debug.Log("Normal damage: " + text);
        }

        if (Text)
        {
            var scrollingText = Instantiate(Text, transform.position + Vector3.up * yOffset, Quaternion.identity);
            scrollingText.SetText(text);
            if (critical)
            {
                scrollingText.SetColor(criticalColor);
                scrollingText.GetComponent<Animation>().Play();
            }
            else
            {
                scrollingText.SetColor(normalTextColor);
            }
        }   
    }
}
