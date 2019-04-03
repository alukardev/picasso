namespace Assets.Scripts.Core.MVC
{
    public class BaseController<TModel>
    {
        protected TModel Model;
        public virtual void Setup(TModel model)
        {
            Model = model;
        }
    }
}