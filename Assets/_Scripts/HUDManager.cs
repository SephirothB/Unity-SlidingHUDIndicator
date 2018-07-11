using System;
using System.Collections;
using UnityEngine;

namespace GameKit.Manager {

    public class HUDManager : MonoBehaviour {
        
        [SerializeField]
        private GameObject sliderObjectPrefab;

        [SerializeField]
        private Sprite[] icons;


        private int countMoney;
        private float displayTime = 1.25f;
        private float displayTimePassed = 0; 
        private Coroutine slideRoutine;


        private void Awake() {
            if (sliderObjectPrefab == null) {
                throw new NotImplementedException("Slider Object Prefab Not Found.");
            }



            //deactivate, we aren't showing
            sliderObjectPrefab.SetActive(false);
        }


        void Start() {
            if (DataManager.s_InstanceExists) {
                DataManager.s_Instance.onMoneyCountChanged += OnMoneyCountChanged_EventListener;
                countMoney = DataManager.s_Instance.Money;
            } else {
                throw new NotImplementedException("DataManager Not Found.");
            }



        }


        #region Event Listeners
        void OnMoneyCountChanged_EventListener(int newValue) {

            sliderObjectPrefab.SetActive(true);
            if (slideRoutine == null) {
                displayTimePassed = 0;
                slideRoutine = StartCoroutine(ToggleSlide(newValue));

            } else {

                //just resest the time passes so the slider stays on screen
                displayTimePassed = 0;
                countMoney = newValue;
                sliderObjectPrefab.GetComponent<SliderObject>().SetText(countMoney.ToString());
            }
           
        }
        #endregion

        //private GameObject NewSliderObject(Sprite icon, string text){
        //    GameObject obj = Instantiate(sliderObjectPrefab);
        //    if (obj == null) return null;
        //    SliderObject sliderObject = obj.GetComponent<SliderObject>();
        //    sliderObject.SetSliderObject(icon, text);
         
        //    return obj;
        //}

        private IEnumerator ToggleSlide(int newAmount) {

            sliderObjectPrefab.GetComponent<Animator>().SetFloat("Speed", 1);
            sliderObjectPrefab.GetComponent<Animator>().SetBool("Show", true);
            yield return new WaitForSeconds(1.75f);

            countMoney = newAmount;
            sliderObjectPrefab.GetComponent<SliderObject>().SetText(countMoney.ToString());

            while (displayTimePassed < displayTime) {
                displayTimePassed += Time.deltaTime;
                yield return null;
            }

            sliderObjectPrefab.GetComponent<Animator>().SetFloat("Speed", -1);
            yield return new WaitForSeconds(1.75f);
            sliderObjectPrefab.GetComponent<Animator>().SetBool("Show", false);
            slideRoutine = null;
            yield return new WaitForSeconds(1.25f);
            //deactivate, we aren't showing
            sliderObjectPrefab.SetActive(false);

        }


    }
}