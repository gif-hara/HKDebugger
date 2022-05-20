using UnityEngine;

namespace HKDebugger
{
    public abstract class Initializer : ScriptableObject
    {
        /// <summary>
        /// プレゼンターを生成して返す
        /// </summary>
        public abstract Presenter CreatePresenter();
    }
}
