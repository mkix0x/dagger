using UnityEngine;
using UnityEngine.UI;

internal class ExperiencePresenter : MonoBehaviour
{
    [SerializeField]
    private Experience experience;

    [SerializeField]
    private Image bar;

    private void OnEnable()
    {
        experience.Changed += Refresh;
    }

    private void OnDisable()
    {
        experience.Changed += Refresh;
    }

    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        bar.fillAmount = experience.GetExperienceProgress();
    }
}
