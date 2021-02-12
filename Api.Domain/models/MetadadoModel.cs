using System;

namespace Api.Domain.models
{
    public class MetadadoModel : BaseModel
    {

        private Guid _projetoId;
        public Guid ProjetoId
        {
            get { return _projetoId; }
            set { _projetoId = value; }
        }

        private int _order;
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _options;
        public string Options
        {
            get { return _options; }
            set { _options = value; }
        }

    }
}
