using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

public string areaToLoad; //within unity type the name of the scene to load exactly as you've written it.
public string areaTransitionName; //This I use to ensure I start at an exact point in the next scene so for now you can skip this one.


private void OnTriggerEnter2D(Collider2D other) //
{
if(other.tag == "Player") //telling the OnTriggerEvent if something tagged "Player" collides then do the following. In this case
//we tell it to LoadScene using areaToLoad variable we created
{
SceneManager.LoadScene(areaToLoad);

}
}
}