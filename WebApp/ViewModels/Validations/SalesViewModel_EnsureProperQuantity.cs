using System.ComponentModel.DataAnnotations;
using CoreBusiness;
using UseCases;

namespace WebApp.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

            if (salesViewModel != null)
            {
                if (salesViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("出售数量必须大于零。");
                }
                else
                {
                    var getProductByIdUseCase = validationContext.GetService(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase;

                    if (getProductByIdUseCase != null)
                    {
                        var product = getProductByIdUseCase.Execute(salesViewModel.SelectedProductId);

                        if (product != null)
                        {
                            if (product.Quantity < salesViewModel.QuantityToSell)
                            {
                                return new ValidationResult($"{product.Name} 只剩下 {product.Quantity}，数量不足");
                            }
                        }
                        else
                        {
                            return new ValidationResult("选择的产品不存在。");
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
