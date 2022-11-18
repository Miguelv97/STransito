using FluentValidation;
using STransito.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STransito.Utils
{
    public class MatriculaValidation : AbstractValidator<DTOMatricula>
    {
        public MatriculaValidation()
        {
            RuleFor(m => m.Numero).NotEmpty().WithMessage("Este Campo es Obligatorio");
            RuleFor(m => m.Numero).MaximumLength(20).WithMessage("Máximo 20 caracteres");
            RuleFor(m => m.FechaExpedicion).NotEmpty().WithMessage("Esta es Fecha Obligatoria");
            RuleFor(m => m.ValidaHasta).NotEmpty().WithMessage("Es Obligatorio Especificar Tiempo de validacion");
            RuleFor(m => m.Activo).NotEmpty().WithMessage("Debe especificar si está activo o no");
        }

    }
}
