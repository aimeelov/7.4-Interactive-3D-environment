using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Mono.Reflection;
using static UnityEngine.InputSystem.Controls.AxisControl;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerActions : MonoBehaviour
{
    public TextMeshPro UseText; // Drag your TextMeshProUGUI element to this field in Inspector
    //public string targetTag = "Lamp"; // The tag of the object you want to detect
    //public float raycastLength = 100f; // The length of the raycast
    public Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen space, then convert that position to a ray
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        // Cast the ray
        //if (Physics.Raycast(ray, out hit, raycastLength))
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            // If the ray hits an object with the specified tag
            if (hit.collider.gameObject.CompareTag("Lamp"))
            {
                // Update the TextMeshProUGUI text
                UseText.text = ("Press E to switch light on and off");
                //gameObject.GetComponent<TextMeshProUGUI>().text = ("Press E on your keyboard to switch light");
            }

            if (hit.collider.gameObject.CompareTag("TV"))
            {
                // Update the TextMeshProUGUI text
                UseText.text = ("Press R to turn TV on and off");
                //gameObject.GetComponent<TextMeshProUGUI>().text = ("Press E on your keyboard to switch light");
            }

            if (hit.collider.gameObject.CompareTag("Cat"))
            {
                // Update the TextMeshProUGUI text
                UseText.text = ("Greet Cat");
                //gameObject.GetComponent<TextMeshProUGUI>().text = ("Press E on your keyboard to switch light");
            }
            //else
            //{
            //UseText.text = "";
            //}
            UseText.gameObject.SetActive(true);
            UseText.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.01f;
            UseText.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
        }
        else
        {
            UseText.gameObject.SetActive(false);
        }

    }
}


    
//    public TextMeshPro UseText; // Drag your Text element into this field in the Inspector
///    public float interactDistance = 5f; // The max distance the player can interact with the lamp
//    private Transform Camera;
//
    // Update is called once per frame
//    void Update()
//    {
   
       // Raycast forward from the player's position
//        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, interactDistance))
//        {
            // Check if the raycast hit the lamp
//            if (hit.collider.gameObject.CompareTag("Lamp")) // Ensure the lamp has a tag "Lamp"
//            {
//                UseText.text = "Press "\E" to switch light";
//            }
//        }
//        else
//        {
//            // If the player is not looking at the lamp, clear the text
//            UseText.text = "";
//        }
//    }
//}





//    [SerializeField]
//    private TextMeshPro UseText;
 //   [SerializeField]
 //   private Transform Camera;
//    [SerializeField]
//    private float MaxUseDistance = 5f;
//    [SerializeField]
//    private LayerMask UseLayers;

    //public void OnUse()
    //{
    //    if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
   //     {
   //         if (hit.collider.TryGetComponent <Light> (out Light light))
   //         {
    //            if (light.IsOn)
   //             {
  //                  light.lightOff();
  //              }
  //              else
  //              {
  //                  light.lightOn();
  //              }
  //          }
  //      }
  //  }

 //   private void Update()
 //   {
//        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers)
 //           && hit.collider.TryGetComponent<Light>(out Light light))
 //       {
 //           if (light.IsOn)
 //           {
 //               UseText.SetText("Turn Off \"E\"");
 //           }
 //           else
 //           {
 //               UseText.SetText("Turn On \"E\"");
 //           }
 //           UseText.gameObject.SetActive(true);
 //           UseText.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.01f;
//       }
//        else
//        {
//            UseText.gameObject.SetActive(false);
//        }
//    }

