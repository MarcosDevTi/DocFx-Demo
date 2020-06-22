using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Env.Commun
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erreurs = new List<string>();

        protected IActionResult CustomResponse(object result = null)
        {
            if (OperationInvalide())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Erreurs.ToArray() }
            }));
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AjouterErreurTraitement(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected IActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AjouterErreurTraitement(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool OperationInvalide()
        {
            return !Erreurs.Any();
        }

        protected void AjouterErreurTraitement(string erro)
        {
            Erreurs.Add(erro);
        }

        protected void ViderErreursTraitement()
        {
            Erreurs.Clear();
        }
    }
}