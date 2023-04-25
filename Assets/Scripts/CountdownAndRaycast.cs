using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountdownAndRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private Image fpCrosshair;
    [SerializeField] private TMP_Text uiText;
    [SerializeField] private GameObject cavnasRaycast;
    public float Duration;

    private float remainingDuration;
    private bool crosshairStatus;
    private GameObject fpObject;
    private float fpTimer;
    private ScoreSystem sc;

    private void Start()
    {
        cavnasRaycast.SetActive(false);
        sc = FindObjectOfType<ScoreSystem>();
        remainingDuration = Duration;
    }

    private void LateUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Cloth"))
            {
                fpObject = hit.collider.gameObject;
                TimeCrosshairOn();
                if (crosshairStatus)
                {
                    fpTimer += Time.deltaTime;
                    uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                    remainingDuration -= Time.deltaTime;
                    fpCrosshair.fillAmount = fpTimer / Duration;
                }

                if (fpTimer >= Duration)
                {
                    sc.Scoring(1);
                    fpObject.GetComponent<BoxCollider>().enabled = false;
                    TimeCrosshairOff();
                }
            }
        }
        else
        {
            TimeCrosshairOff();
        }
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        //End Time, if want Do something
        Debug.Log("End");
    }

    public void Being(float second)
    {
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
    }

    public void TimeCrosshairOn()
    {
        crosshairStatus = true;
        cavnasRaycast.SetActive(true);

    }

    public void TimeCrosshairOff()
    {
        crosshairStatus = false;
        fpTimer = 0;
        fpCrosshair.fillAmount = 0;
        remainingDuration = Duration;
        cavnasRaycast.SetActive(false);

    }

}
