using Communion.Application.Authentication.Commands.SignUp;
using Communion.Application.Authentication.Common;
using Communion.Application.Authentication.Queries.SignIn;
using Communion.Contracts.Authentication;
using Mapster;

namespace Communion.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Config for mapping SignUpCommand using SignUpRequest.
        config.NewConfig<SignUpRequest, SignUpCommand>();

        // Config for mapping SignInQuery using SignInRequest.
        config.NewConfig<SignInRequest, SignInQuery>();

        // Config for mapping AuthenticationResponse using AuthenticationResult.
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.ProfilePicture, src => src.User.ProfilePicture ?? "None", src => src.User.ProfilePicture == null)
            .Map(dest => dest, src => src.User);
    }
}