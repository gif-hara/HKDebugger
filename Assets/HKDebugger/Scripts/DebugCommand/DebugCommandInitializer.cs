using UnityEngine;

namespace HKDebugger.DebugCommand
{
    [CreateAssetMenu]
    public class DebugCommandInitializer : Initializer
    {
        [SerializeField]
        private DebugCommandDocument documentPrefab;

        public override Presenter CreatePresenter()
        {
            return new DebugCommandPresenter(this.documentPrefab);
        }
    }
}
