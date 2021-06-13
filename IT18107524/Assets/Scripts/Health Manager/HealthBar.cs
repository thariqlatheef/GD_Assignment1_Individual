using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image fillBar;
    public float health;

    public void loseHealth(int value)
    {
        //Do nothing if you are out of health
        if (health <= 0)
        return;

        //Reduce the health
        health -= value;

        //Refresh the UI fill bar
        fillBar.fillAmount = health / 100;

        //Check if your health is zero or less => dead
        if (health <= 0)
        {
            Debug.Log("YOU DIED");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        loseHealth(33);
    }
}
