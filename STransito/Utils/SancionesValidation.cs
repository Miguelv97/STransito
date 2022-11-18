using FluentValidation;
using STransito.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STransito.Utils
{
    public class SancionesValidation : AbstractValidator<DTOSanciones>
    {
        public SancionesValidation()
        {
            RuleFor(s => s.ConductorId).NotEmpty().WithMessage("Este Campo es Obligatorio");
            RuleFor(s => s.Sancion).NotEmpty().WithMessage("Debe especificar la sancion si no tiene, escriba, No");
            RuleFor(s => s.Sancion).MaximumLength(100).WithMessage("Maximo 100 caracteres");
            RuleFor(s => s.Observacion).NotEmpty().WithMessage("Este Campo es Obligatorio");
            //RuleFor(s => s.Observacion).MaximumLength(20).WithMessage("Máximo 20 caracteres");
            
        }
    }
}
