using UnityEngine;
using System.Collections;  

namespace AR_Assessment.Ui
{
    public class HintPopupController : MonoBehaviour
    {
        public GameObject scanPopup, placePopup;

        void Start()
        {
            
            StartCoroutine(ShowHintPopups());
        }

        IEnumerator ShowHintPopups()
        {
            yield return new WaitForSeconds(5f);
            scanPopup.SetActive(false);
            placePopup.SetActive(true);

            yield return new WaitForSeconds(3f);
            placePopup.SetActive(false);
        }
    }
}