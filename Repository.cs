using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RestClientExample
{
    [DataContract(Name = "repo")]
    public class Repository
    {
        [DataMember(Name = "name")]
        public string Name
        {
            get { return this._name;  }
            set { this._name = value; }
        }
        private string _name;
    }
}
