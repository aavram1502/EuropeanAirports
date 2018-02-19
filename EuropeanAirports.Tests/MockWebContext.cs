using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace EuropeanAirports.Tests
{
    public class MockWebContext
    {
        public Mock<RequestContext> RoutingRequestContext { get; }
        public Mock<HttpContextBase> Http { get; }
        public Mock<HttpServerUtilityBase> Server { get; }
        public Mock<HttpResponseBase> Response { get; }
        public Mock<HttpRequestBase> Request { get; }
        public Mock<HttpSessionStateBase> Session { get; }
        public Mock<ActionExecutingContext> ActionExecuting { get; }
        public HttpCookieCollection Cookies { get; }

        public MockWebContext()
        {
            RoutingRequestContext = new Mock<RequestContext>(MockBehavior.Loose);
            ActionExecuting = new Mock<ActionExecutingContext>(MockBehavior.Loose);
            Http = new Mock<HttpContextBase>(MockBehavior.Loose);
            Server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            Response = new Mock<HttpResponseBase>(MockBehavior.Loose);
            Request = new Mock<HttpRequestBase>(MockBehavior.Loose);
            Session = new Mock<HttpSessionStateBase>(MockBehavior.Loose);
            Cookies = new HttpCookieCollection();

            RoutingRequestContext.SetupGet(c => c.HttpContext).Returns(Http.Object);
            ActionExecuting.SetupGet(c => c.HttpContext).Returns(Http.Object);
            Http.SetupGet(c => c.Request).Returns(Request.Object);
            Http.SetupGet(c => c.Response).Returns(Response.Object);
            Http.SetupGet(c => c.Server).Returns(Server.Object);
            Http.SetupGet(c => c.Session).Returns(Session.Object);
            Response.Setup(c => c.Cookies).Returns(Cookies);
        }

        public static ControllerContext BasicContext()
        {
            return new ControllerContext
            {
                HttpContext = new MockWebContext().Http.Object
            };
        }
    }
}
