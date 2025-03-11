using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private int amountToFed = 3;
    [SerializeField] private int currentFedAmount = 0;


    public void FeedAnimal()
    {
        if (currentFedAmount < amountToFed)
        {
            currentFedAmount++;
            hungerSlider.value = currentFedAmount;
            if (currentFedAmount == amountToFed)
            {
                Destroy(gameObject);
                EventManager.TriggerScoreIncrease();
            }
        }
    }
}
