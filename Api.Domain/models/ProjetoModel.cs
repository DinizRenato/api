namespace Api.Domain.models
{
    public class ProjetoModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
