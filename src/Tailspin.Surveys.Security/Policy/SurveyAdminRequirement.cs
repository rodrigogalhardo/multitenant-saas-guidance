﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Security.Claims;
using Microsoft.AspNet.Authorization;

namespace Tailspin.Surveys.Security.Policy
{
    /// <summary>
    /// This basic <see cref="IAuthorizationRequirement"/> functions as an <see cref="IAuthorizationHandler"/> that
    /// validates that the signed in user has a SurveyAdmin role claim.
    /// </summary>
    public class SurveyAdminRequirement : AuthorizationHandler<SurveyAdminRequirement>, IAuthorizationRequirement
    {
        protected override void Handle(AuthorizationContext context, SurveyAdminRequirement requirement)
        {
            //Check user claims for Role
            if (!context.User.HasClaim(ClaimTypes.Role, Roles.SurveyAdmin))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}