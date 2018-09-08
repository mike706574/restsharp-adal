using Microsoft.IdentityModel.Clients.ActiveDirectory;
using RestSharp;
using RestSharp.Authenticators;

namespace Mike.RestSharp.ActiveDirectory
{
    public class ActiveDirectoryJwtAuthenticator : IAuthenticator
    {
        private readonly AuthenticationContext _authenticationContext;

        private readonly ClientCredential _clientCredential;

        private readonly string _resource;

        public ActiveDirectoryJwtAuthenticator(ClientCredentials _credentials)
        {
            _authenticationContext = new AuthenticationContext(_credentials.Authority);
            _clientCredential = new ClientCredential(_credentials.ClientId, _credentials.ClientSecret);
            _resource = _credentials.Resource;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            string accessToken = _authenticationContext.AcquireTokenAsync(_resource, _clientCredential)
                .Result
                .AccessToken;

            JwtAuthenticator _jwtAuthenticator = new JwtAuthenticator(accessToken);

            _jwtAuthenticator.Authenticate(client, request);
        }
    }
}