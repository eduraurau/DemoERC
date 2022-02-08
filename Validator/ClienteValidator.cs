using DemoERC.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoERC.Validator
{
    public class ClienteValidator : AbstractValidator<ClienteRequest>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.NombreCompleto)
                 .NotEmpty().WithMessage("NombreCompleto es requerido")
                .MaximumLength(200).WithMessage("NombreCompleto no debe exceder de 200 caracteres")
                .Length(2, 200);

            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("NombreCorto es requerido")
                .MaximumLength(40).WithMessage("NombreCorto no debe exceder de 40 caracteres")
                .Length(2, 40);


            RuleFor(x => x.Abreviatura)
                  .NotEmpty().WithMessage("Abreviatura es requerido")
                .MaximumLength(40).WithMessage("Abreviaturano debe exceder de 40 caracteres");


            RuleFor(x => x.Ruc).NotEmpty()
                .WithMessage("Ruc es requerido")
                .Length(11).WithMessage("Ruc debe tener {MaxLength} dígitos")
                .MaximumLength(11).WithMessage("Ruc no debe exceder de 11 dígitos")
                .Must(EsRuc).WithMessage("Ruc únicamente dígitos.");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Estado es requerido")
                   .Length(1).WithMessage("Estado no debe exceder 1 caracter");

            When(x => x.GrupoFacturacion != null, () =>
            {
                RuleFor(x => x.GrupoFacturacion)
                .NotEmpty().WithMessage("GrupoFacturacion es requerido")
            .MaximumLength(100).WithMessage("GrupoFacturacion no debe exceder de 100 caracteres");
            });


            When(x => x.CodigoSAP != null, () =>
            {
                RuleFor(x => x.CodigoSAP)
                .NotEmpty().WithMessage("CodigoSAP es requerido")
            .MaximumLength(100).WithMessage("CodigoSAP no debe exceder de 100 caracteres");
            });

        }

        private bool EsRuc(string value)
        {
            return value.All(Char.IsDigit);
        }
    }
}
