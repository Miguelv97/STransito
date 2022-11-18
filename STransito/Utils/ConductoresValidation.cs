using FluentValidation;
using STransito.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STransito.Utils
{
    public class ConductoresValidation : AbstractValidator<DTOConductor>
    {
        public ConductoresValidation()
        {
            RuleFor(c => c.Identificacion).NotEmpty().WithMessage("Este Campo es Obligatorio");
            RuleFor(c => c.Identificacion).MaximumLength(15).WithMessage("Máximo 15 caracteres");
            RuleFor(c => c.Nombre).NotEmpty().WithMessage("Esta es Fecha Obligatoria");
            RuleFor(c => c.Nombre).MaximumLength(20).WithMessage("Máximo de 20 caracteres");
            RuleFor(c => c.Apellidos).NotEmpty().WithMessage("Esta es Fecha Obligatoria");
            RuleFor(c => c.Apellidos).MaximumLength(20).WithMessage("Máximo de 20 caracteres");
            RuleFor(c => c.Direccion).MaximumLength(30).WithMessage("Máximo de 30 caracteres");
            RuleFor(c => c.Telefono).MaximumLength(15).WithMessage("Máximo de 15 caracteres");
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.IdMAtricula).NotEmpty().WithMessage("Es Obligatorio especificarlo");
            RuleFor(m => m.Activo).NotEmpty().WithMessage("Debe especificar si está activo o no");
        }
    }
}
