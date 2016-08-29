using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;

namespace TestServiceActivation
{
    public class DataContractSerializerBehavior: DataContractSerializerOperationBehavior
    {
        public DataContractSerializerBehavior(OperationDescription operation) : base(operation) 
        {

        }
    }
}