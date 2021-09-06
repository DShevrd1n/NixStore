using Moq;
using ProdStore;
using System;
using Xunit;


namespace Tests
{
    public class ProductServiceTest 
    {

        //[Fact]
        //public void GetAllByQuery_WithArticul_CallsGetAllByArticul()
        //{
        //    var productRepositoryStub = new Mock<IProductRepository>();
        //    productRepositoryStub.Setup(x => x.GetAllByArticul(It.IsAny<string>()))
        //                         .Returns(new[] { new Product(1, "", "", 0m,"") });
        //    productRepositoryStub.Setup(x => x.GetAllByName(It.IsAny<string>()))
        //                         .Returns(new[] { new Product(2, "", "", 0m, "") });
        //    var productService = new ProductService(productRepositoryStub.Object);
        //    var actual = productService.GetAllByQuery("0000000");
        //    Assert.Collection(actual, product => Assert.Equal(1, product.Id));

        //}
        //[Fact]
        //public void GetAllByQuery_WithName_CallsGetAllByName()
        //{
        //    var productRepositoryStub = new Mock<IProductRepository>();
        //    productRepositoryStub.Setup(x => x.GetAllByArticul(It.IsAny<string>()))
        //                         .Returns(new[] { new Product(1, "", "", 0m, "") });
        //    productRepositoryStub.Setup(x => x.GetAllByName(It.IsAny<string>()))
        //                         .Returns(new[] { new Product(2, "", "",0m, "") });
        //    var productService = new ProductService(productRepositoryStub.Object);
        //    var actual = productService.GetAllByQuery("Meat");
        //    Assert.Collection(actual, product => Assert.Equal(2, product.Id));

        //}
    }
}
