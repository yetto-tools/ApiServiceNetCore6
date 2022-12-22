using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ApiService
{
    public class SwaggerByGroupVersion: IControllerModelConvention
    {
        
        public void Apply(ControllerModel controller)
        {
            var namespaceController = controller.ControllerType.Namespace; 
            controller.ApiExplorer.GroupName = namespaceController?.Split('.').Last().ToLower();
        }
    }
}
