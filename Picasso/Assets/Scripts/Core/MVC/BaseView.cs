using UnityEngine;

namespace Assets.Scripts.Core.MVC
{
    public class BaseView<TController, TModel> : MonoBehaviour
    where TController : BaseController<TModel>, new()
    where TModel : BaseModel, new()
    {
        [SerializeField]
        protected TModel Model;
        protected TController Controller;

        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            Model = new TModel();

            Controller = new TController();
            Controller.Setup(Model);
        }
    }
}