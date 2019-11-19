using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public Texture2D colourTexture;
    public Renderer testCube;
    public Renderer hull;
    public Renderer gun;
    public Renderer tower;

    private Rect textureRect1 = new Rect(50, 150,150,150);
    private Rect textureRect2 = new Rect((Screen.width-200), 150, 150, 150);

    void OnGUI() {
       GUI.DrawTexture(textureRect1, colourTexture);
       GUI.DrawTexture(textureRect2, colourTexture);

        if (Event.current.type == EventType.MouseUp) {
            Vector2 mousePosition = Event.current.mousePosition;

            if (mousePosition.x < textureRect1.x || mousePosition.x > textureRect1.xMax ||
                mousePosition.y < textureRect1.y || mousePosition.y > textureRect1.yMax){
                return;
            }

            float textureUPosition = (mousePosition.x - textureRect1.x) / textureRect1.width;
            float textureVPosition = 1.0f - ((mousePosition.y - textureRect1.y) / textureRect1.height);

            Color textureColour = colourTexture.GetPixelBilinear(textureUPosition, textureVPosition);
            //testCube.sharedMaterial.color = textureColour;
            Debug.Log("Colour selected");

            //foreach (Material m in object.materials)
            //{
            //    m.color = newcolour;
            //}
        }
    }
}
