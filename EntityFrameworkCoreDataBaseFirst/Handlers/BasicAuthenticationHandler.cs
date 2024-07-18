//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Options;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Text.Encodings.Web;

//namespace EntityFrameworkCoreDataBaseFirst.Handlers
//{
//    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        public BasicAuthenticationHandler(
//            IOptionsMonitor<AuthenticationSchemeOptions> options,
//            ILoggerFactory logger,
//            UrlEncoder encoder,
//            ISystemClock clock
//            ) : base(options, logger, encoder, clock) { }

//        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            //to set up authorization
//            if(Request.Headers.ContainsKey("Authorization"))
//                 return AuthenticateResult.Fail("need to impliment");

//            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);//reading the authorization add
//            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);//convert from base64 to bytes
//            //convert bytes to proper string
//            string credentials = Encoding.UTF8.GetString(bytes);
//            await Console.Out.WriteLineAsync(credentials);
//            return AuthenticateResult.Fail("authentication success full");

//        }
//    }
//}
