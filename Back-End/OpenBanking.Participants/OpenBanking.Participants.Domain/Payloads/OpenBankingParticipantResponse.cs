using OpenBanking.Participants.Domain.Entities;

namespace OpenBanking.Participants.Domain.Payloads
{
    public class OpenBankingParticipantResponse
    {
        public string OrganisationId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string OrganisationName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string LegalEntityName { get; set; } = string.Empty;
        public string CountryOfRegistration { get; set; } = string.Empty;
        public string CompanyRegister { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public string? Size { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string RegistrationId { get; set; } = string.Empty;
        public string RegisteredName { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty; 
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty; 
        public string ParentOrganisationReference { get; set; } = string.Empty; 
        public List<AuthorisationServer> AuthorisationServers { get; set; } = new List<AuthorisationServer>();
        public List<OrgDomainClaim> OrgDomainClaims { get; set; } = new List<OrgDomainClaim>();
        public List<OrgDomainRoleClaim> OrgDomainRoleClaims { get; set; } = new List<OrgDomainRoleClaim>();

        public class ApiDiscoveryEndpoint
        {
            public string ApiDiscoveryId { get; set; } = string.Empty;
            public string ApiEndpoint { get; set; } = string.Empty;
        }

        public class ApiResource
        {
            public string ApiResourceId { get; set; } = string.Empty;
            public string ApiVersion { get; set; } = string.Empty;
            public bool FamilyComplete { get; set; }
            public string ApiCertificationUri { get; set; } = string.Empty;
            public string CertificationStatus { get; set; } = string.Empty; 
            public string CertificationStartDate { get; set; } = string.Empty;
            public string CertificationExpirationDate { get; set; } = string.Empty;
            public string ApiFamilyType { get; set; } = string.Empty;
            public List<ApiDiscoveryEndpoint> ApiDiscoveryEndpoints { get; set; } = new List<ApiDiscoveryEndpoint>();
        }

        public class AuthorisationServer
        {
            public string AuthorisationServerId { get; set; } = string.Empty;
            public bool AutoRegistrationSupported { get; set; }
            public bool? AutoRegistrationNotificationWebhook { get; set; }
            public bool SupportsCiba { get; set; }
            public bool SupportsDCR { get; set; }
            public bool SupportsRedirect { get; set; }
            public string CustomerFriendlyDescription { get; set; } = string.Empty;
            public string CustomerFriendlyLogoUri { get; set; } = string.Empty;
            public string CustomerFriendlyName { get; set; } = string.Empty;
            public string DeveloperPortalUri { get; set; } = string.Empty; 
            public string TermsOfServiceUri { get; set; } = string.Empty;
            public string? NotificationWebhookAddedDate { get; set; }
            public string? OpenIDDiscoveryDocument { get; set; }
            public string? Issuer { get; set; }
            public string? FederationId { get; set; }
            public string? FederationEndpoint { get; set; }
            public string PayloadSigningCertLocationUri { get; set; } = string.Empty;
            public double CreatedAt { get; set; }
            public string? ParentAuthorisationServerId { get; set; }
            public string? DeprecatedDate { get; set; }
            public string? RetirementDate { get; set; }
            public string? SupersededByAuthorisationServerId { get; set; }
            public List<ApiResource> ApiResources { get; set; } = new List<ApiResource>();
            public List<AuthorisationServerCertification> AuthorisationServerCertifications { get; set; } = new List<AuthorisationServerCertification>();
        }

        public class AuthorisationServerCertification
        {
            public string CertificationStartDate { get; set; } = string.Empty;
            public string CertificationExpirationDate { get; set; } = string.Empty;
            public string CertificationId { get; set; } = string.Empty;
            public string AuthorisationServerId { get; set; } = string.Empty; 
            public string Status { get; set; } = string.Empty;
            public string ProfileVariant { get; set; } = string.Empty; 
            public string ProfileType { get; set; } = string.Empty;
            public double ProfileVersion { get; set; }
            public string CertificationURI { get; set; } = string.Empty;
        }

        public class OrgDomainClaim
        {
            public string AuthorisationDomainName { get; set; } = string.Empty;
            public string AuthorityName { get; set; } = string.Empty;
            public string RegistrationId { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }

        public class OrgDomainRoleClaim
        {
            public string Status { get; set; } = string.Empty;
            public string AuthorisationDomain { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
            public string RegistrationId { get; set; } = string.Empty;
            public List<Authorisation> Authorisations { get; set; } = new List<Authorisation>();
            public string RoleType { get; set; } = string.Empty;
            public bool Exclusive { get; set; }
            public List<string> Metadata { get; set; } = new List<string>();
        }

        public class Authorisation
        {
            public string Status { get; set; } = string.Empty;
            public string MemberState { get; set; } = string.Empty;
        }

        public static explicit operator Participant(OpenBankingParticipantResponse participantResponse)
        {
            AuthorisationServer authorisationServer = participantResponse.AuthorisationServers.First();

            return new()
            {
                Name = participantResponse.OrganisationName,
                DiscoveryUrl = authorisationServer.OpenIDDiscoveryDocument ?? string.Empty,
                LogoUrl = authorisationServer.CustomerFriendlyLogoUri,
                Id = participantResponse.OrganisationId
            };
        }
    }
}
