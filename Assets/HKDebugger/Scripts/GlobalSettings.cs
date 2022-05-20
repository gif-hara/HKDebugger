using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HKDebugger
{
    public class GlobalSettings : ScriptableObject
    {
        public static GlobalSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<GlobalSettings>("HKDebugger.GlobalSettings");
                }

                return instance;
            }
        }
        private static GlobalSettings instance = null;

        [SerializeField]
        private List<Initializer> initializers;
        public IReadOnlyList<Initializer> Initializers => this.initializers;
    }
}
