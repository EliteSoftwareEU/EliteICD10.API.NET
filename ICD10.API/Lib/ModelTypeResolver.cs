using System;
namespace ICD10.API.Lib
{
    public class ModelTypeResolver
    {
        string _modelKlassName;

        public ModelTypeResolver(string modelKlass)
        {
            _modelKlassName = modelKlass;
        }

        public Type Resolve()
        {
            Type modelType = null;
            modelType = Type.GetType(ModelsNamespace() + _modelKlassName);
            if (modelType == null)
            {
                modelType = Type.GetType(ResponseModelsNamespace() + _modelKlassName);
            }
            return modelType;
        }

        private string ModelsNamespace()
        {
            return "ICD10.API.Models.";
        }

        private string ResponseModelsNamespace()
        {
            return ModelsNamespace() + "Response.";
        }
    }
}
