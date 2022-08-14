using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Phone_Book.Api2.Attributes
{
    public class FromMultiSourceAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource { get; }
            = CompositeBindingSource.Create(new[] { BindingSource.Path, BindingSource.Query }
        , nameof(FromMultiSourceAttribute));
    }

}
