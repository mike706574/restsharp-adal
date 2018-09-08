namespace Mike.RestSharp.ActiveDirectory
{
    public class ClientCredentials
    {
        public string Authority { get; }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string Resource { get; }

        public ClientCredentials(string authority, string clientId, string clientSecret, string resource)
        {
            Authority = authority;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Resource = resource;
        }

        private bool Equals(ClientCredentials other)
        {
            return string.Equals(Authority, other.Authority) && string.Equals(ClientId, other.ClientId) && string.Equals(ClientSecret, other.ClientSecret) && string.Equals(Resource, other.Resource);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ClientCredentials) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Authority != null ? Authority.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ClientId != null ? ClientId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ClientSecret != null ? ClientSecret.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Resource != null ? Resource.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Authority)}: {Authority}, {nameof(ClientId)}: {ClientId}, {nameof(Resource)}: {Resource}";
        }
    }
}