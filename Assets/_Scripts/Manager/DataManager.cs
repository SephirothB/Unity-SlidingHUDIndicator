using System;
using System.Collections.Generic;
using UnityEngine;


using GameKit.Common;
namespace GameKit.Manager {
    public class DataManager : Singleton<DataManager> {


        public Action<int> onMoneyCountChanged;

        private int money;
        public int Money {
            get {
                return money;
            }

            set {
                money = value;
                if(onMoneyCountChanged!=null){
                    onMoneyCountChanged(money);
                }
            }
        }

        public void AddMoney(int amount){
            Money += amount;
        }

        public void RemoveMoney(int amount) {
            Money -= amount;
        }


    }
}