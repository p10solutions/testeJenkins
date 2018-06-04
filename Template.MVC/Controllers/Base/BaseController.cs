using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Template.MVC.Controllers.Base
{
    public class BaseController: Controller
    {
        public string ObterErroModel(ModelStateDictionary modelState, object viewModel)
        {
            foreach (var campo in modelState)
                if (modelState[campo.Key].Errors.Count > 0)
                    return $"{modelState[campo.Key].Errors[0].ErrorMessage} : {ObterDisplayName(campo.Key, viewModel)}";

            return "";
        }

        public string ObterDisplayName(string campo, object objeto)
        {
            if (campo == null)
                return null;

            string campoSubObjeto = null;
            if (campo.Contains("."))
            {
                var splitCampo = campo.Split('.');
                campo = splitCampo[0];
                campoSubObjeto = splitCampo[1];
            }

            var property = objeto.GetType().GetProperty(campo);

            DisplayAttribute DisplayName = null;

            if (property == null)
                return campo;

            if (!property.DeclaringType.IsClass || property.PropertyType == typeof(string) || property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                DisplayName = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            else
                return ObterDisplayName(campoSubObjeto, objeto.GetType().GetProperty(campo).GetValue(objeto));

            return DisplayName != null ? DisplayName.Name : campo;
        }
    }
}
