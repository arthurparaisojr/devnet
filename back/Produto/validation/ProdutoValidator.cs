using FluentValidation;
using Produto.models;

namespace Produtos.validation
{
    public class ProdutoValidator : AbstractValidator<ProdutoBO>
    {
        public ProdutoValidator()
        {
            RuleFor(produto => produto.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(produto => produto.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            RuleFor(produto => produto.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser negativa.");
        }
    }
}
