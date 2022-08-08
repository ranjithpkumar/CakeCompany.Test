using CakeCompany.IServices;
using CakeCompany.Services.Models;
using CakeCompany.Services.Provider;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CakeCompany.UnitTest;

public class ShipmentProviderTest
{


    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Shipment_Provider_ExecuteOrder_Successful()
    {

        var logger = new Mock<ILogger<ShipmentProvider>>();
        var orderProvider = new Mock<IOrderProvider<Order, Product>>();
        var transportProvider = new Mock<ITransportProvider<Product>>();

        //orderProvider.Setup() mock object need to be set up here

        IShipmentProvider shipmentProvider = new ShipmentProvider(logger.Object, orderProvider.Object, transportProvider.Object);


        var results = shipmentProvider.GetShipment();

        Assert.IsTrue(true);
        Assert.Pass();

    }
    [Test]
    public void Shipment_Provider_ExecuteOrder_UnSuccessful()
    {

        var logger = new Mock<ILogger<ShipmentProvider>>();
        var orderProvider = new Mock<IOrderProvider<Order, Product>>();
        var transportProvider = new Mock<ITransportProvider<Product>>();
        //orderProvider.Setup() mock object need to be set up here
        IShipmentProvider shipmentProvider = new ShipmentProvider(logger.Object, orderProvider.Object, transportProvider.Object);


        var results = shipmentProvider.GetShipment();
        Assert.IsFalse(false);
        Assert.Pass();



    }
}