using MyWorld.SO;
using UnityEngine;

namespace MyWorld.Interface
{
    [ExecuteInEditMode]
    public class DrawGUI : MonoBehaviour
    {
        [SerializeField] private IntValue playerHealth;
        [SerializeField] private Light light;
        [SerializeField] private Color myColor;
        [SerializeField] private IntEventChannel healthChanged;
        [SerializeField] private int buttonDamage;

        private float rectDist = 20;
        
        private void OnGUI()
        {
            myColor = RGBSlider(new Rect(10, 10, 200, 20), myColor,"Light Filter Sliders: ");
            HealthBar(new Rect(Screen.width - 100, 0, 100, 50), "Health");
            if (GUI.changed)
            {
                light.color = myColor;
            }

            if (DMGButton(new Rect(Screen.width - 100, 50, 100, 50), "Get Damage","Let's Get DMG"))
            {
                healthChanged.RaiseEvent(buttonDamage);
            }
        }

        private Color RGBSlider(Rect screenRect, Color rgba,string sliderLabel)
        {
            GUILayout.Label(sliderLabel);
            screenRect.y += rectDist;
            rgba.r = LabelSlider(screenRect, rgba.r, .1f,1.0f, "Red"); 
            screenRect.y += rectDist;
            rgba.g = LabelSlider(screenRect, rgba.g, .1f,1.0f, "Green"); 
            screenRect.y += rectDist;
            rgba.b = LabelSlider(screenRect, rgba.b, .1f,1.0f, "Blue");
            screenRect.y += rectDist;
            rgba.a = LabelSlider(screenRect, rgba.a, .1f,1.0f, "Alpha");
            return rgba;
        }

        private float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
        {
            GUI.Label(screenRect, labelText);
            screenRect.x += screenRect.width;
            sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
            return sliderValue;
        }

        private void HealthBar(Rect screenRect, string barText)
        {
            GUI.Box(screenRect, barText);
            screenRect.y += rectDist;
            GUI.Label(screenRect, playerHealth.Value.ToString());
        }

        private bool DMGButton(Rect screenRect, string buttonText,string labelText)
        {
            GUI.Label(screenRect, labelText);
            screenRect.y += rectDist;
            var button = GUI.Button(screenRect, buttonText);
            return button;
        }
    }
}

