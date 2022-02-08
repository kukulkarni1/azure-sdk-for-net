﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Tests.Helper
{
    public static class ResourceDataHelper
    {
        public static ProfileData CreateProfileData(SkuName skuName) => new ProfileData(AzureLocation.WestUS, new Models.Sku { Name = skuName });

        public static ProfileData CreateAfdProfileData(SkuName skuName) => new ProfileData("Global", new Models.Sku { Name = skuName })
        {
            OriginResponseTimeoutSeconds = 60
        };

        public static CdnEndpointData CreateEndpointData() => new CdnEndpointData(AzureLocation.WestUS)
        {
            IsHttpAllowed = true,
            IsHttpsAllowed = true,
            OptimizationType = OptimizationType.GeneralWebDelivery
        };

        public static AfdEndpointData CreateAfdEndpointData() => new AfdEndpointData(AzureLocation.WestUS);

        public static DeepCreatedOrigin CreateDeepCreatedOrigin() => new DeepCreatedOrigin("testOrigin")
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net",
            Priority = 3,
            Weight = 100
        };

        public static DeepCreatedOriginGroup CreateDeepCreatedOriginGroup() => new DeepCreatedOriginGroup("testOriginGroup")
        {
            HealthProbeSettings = new HealthProbeParameters
            {
                ProbePath = "/healthz",
                ProbeRequestType = HealthProbeRequestType.Head,
                ProbeProtocol = ProbeProtocol.Https,
                ProbeIntervalInSeconds = 60
            }
        };

        public static CdnOriginData CreateOriginData() => new CdnOriginData
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net",
            Priority = 1,
            Weight = 150
        };

        public static AfdOriginData CreateAfdOriginData() => new AfdOriginData
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net"
        };

        public static CdnOriginGroupData CreateOriginGroupData() => new CdnOriginGroupData();

        public static AfdOriginGroupData CreateAfdOriginGroupData() => new AfdOriginGroupData
        {
            HealthProbeSettings = new HealthProbeParameters
            {
                ProbePath = "/healthz",
                ProbeRequestType = HealthProbeRequestType.Head,
                ProbeProtocol = ProbeProtocol.Https,
                ProbeIntervalInSeconds = 60
            },
            LoadBalancingSettings = new LoadBalancingSettingsParameters
            {
                SampleSize = 5,
                SuccessfulSamplesRequired = 4,
                AdditionalLatencyInMilliseconds = 200
            }
        };

        public static CustomDomainOptions CreateCdnCustomDomainData(string hostName) => new CustomDomainOptions
        {
            HostName = hostName
        };

        public static AfdCustomDomainData CreateAfdCustomDomainData(string hostName) => new AfdCustomDomainData
        {
            HostName = hostName,
            TlsSettings = new AfdCustomDomainHttpsParameters(AfdCertificateType.ManagedCertificate)
            {
                MinimumTlsVersion = AfdMinimumTlsVersion.Tls12
            },
            AzureDnsZone = new WritableSubResource
            {
                Id = new ResourceIdentifier("/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/cdntest/providers/Microsoft.Network/dnszones/azuretest.net")
            }
        };

        public static AfdRuleData CreateAfdRuleData() => new AfdRuleData
        {
            Order = 1
        };

        public static DeliveryRuleCondition CreateDeliveryRuleCondition() => new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersTypeName.DeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any));

        public static DeliveryRuleAction CreateDeliveryRuleOperation() => new DeliveryRuleRouteConfigurationOverrideAction(new RouteConfigurationOverrideActionParameters(RouteConfigurationOverrideActionParametersTypeName.DeliveryRuleRouteConfigurationOverrideActionParameters)
        {
            CacheConfiguration = new CacheConfiguration()
            {
                QueryStringCachingBehavior = RuleQueryStringCachingBehavior.IgnoreSpecifiedQueryStrings,
                QueryParameters = "a=test",
                IsCompressionEnabled = RuleIsCompressionEnabled.Enabled,
                CacheBehavior = RuleCacheBehavior.HonorOrigin
            }
        });

        public static AfdRouteData CreateAfdRouteData(AfdOriginGroup originGroup) => new AfdRouteData
        {
            OriginGroup = new WritableSubResource
            {
                Id = originGroup.Id
            },
            LinkToDefaultDomain = LinkToDefaultDomain.Enabled,
            EnabledState = EnabledState.Enabled
        };

        public static AfdSecurityPolicyData CreateAfdSecurityPolicyData(AfdEndpoint endpoint) => new AfdSecurityPolicyData
        {
            Parameters = new SecurityPolicyWebApplicationFirewallParameters
            {
                WafPolicy = new WritableSubResource
                {
                    Id = new ResourceIdentifier("/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/CdnTest/providers/Microsoft.Network/frontdoorWebApplicationFirewallPolicies/testAFDWaf")
                }
            }
        };

        public static AfdSecretData CreateAfdSecretData() => new AfdSecretData
        {
            Parameters = new CustomerCertificateParameters(new WritableSubResource
            {
                Id = new ResourceIdentifier("/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/CdnTest/providers/Microsoft.KeyVault/vaults/testKV4AFDTest/certificates/testCertificate")
            })
            {
                UseLatestVersion = true
            }
        };

        public static CdnWebApplicationFirewallPolicyData CreateCdnWebApplicationFirewallPolicyData() => new CdnWebApplicationFirewallPolicyData("Global", new Models.Sku
        {
            Name = SkuName.StandardMicrosoft
        });

        public static void AssertValidProfile(Profile model, Profile getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Sku.Name, getResult.Data.Sku.Name);
            Assert.AreEqual(model.Data.Kind, getResult.Data.Kind);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.FrontDoorId, getResult.Data.FrontDoorId);
            Assert.AreEqual(model.Data.OriginResponseTimeoutSeconds, getResult.Data.OriginResponseTimeoutSeconds);
            if (model.Data.Identity != null || getResult.Data.Identity != null)
            {
                Assert.NotNull(model.Data.Identity);
                Assert.NotNull(getResult.Data.Identity);
                Assert.AreEqual(model.Data.Identity.Type, getResult.Data.Identity.Type);
                Assert.AreEqual(model.Data.Identity.TenantId, getResult.Data.Identity.TenantId);
                Assert.AreEqual(model.Data.Identity.PrincipalId, getResult.Data.Identity.PrincipalId);
                Assert.AreEqual(model.Data.Identity.UserAssignedIdentities, getResult.Data.Identity.UserAssignedIdentities);
            }
        }

        public static void AssertProfileUpdate(Profile updatedProfile, ProfileUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedProfile.Data.Tags.Count, updateOptions.Tags.Count);
            foreach (var kv in updatedProfile.Data.Tags)
            {
                Assert.True(updateOptions.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateOptions.Tags[kv.Key]);
            }
        }

        public static void AssertValidEndpoint(CdnEndpoint model, CdnEndpoint getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.OriginPath, getResult.Data.OriginPath);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.IsCompressionEnabled, getResult.Data.IsCompressionEnabled);
            Assert.AreEqual(model.Data.IsHttpAllowed, getResult.Data.IsHttpAllowed);
            Assert.AreEqual(model.Data.IsHttpsAllowed, getResult.Data.IsHttpsAllowed);
            Assert.AreEqual(model.Data.QueryStringCachingBehavior, getResult.Data.QueryStringCachingBehavior);
            Assert.AreEqual(model.Data.OptimizationType, getResult.Data.OptimizationType);
            Assert.AreEqual(model.Data.ProbePath, getResult.Data.ProbePath);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            //Todo: ContentTypesToCompress, GeoFilters, DefaultOriginGroup, UrlSigningKeys, DeliveryPolicy, WebApplicationFirewallPolicyLink, Origins, OriginGroups
        }

        public static void AssertEndpointUpdate(CdnEndpoint updatedEndpoint, EndpointUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedEndpoint.Data.IsHttpAllowed, updateOptions.IsHttpAllowed);
            Assert.AreEqual(updatedEndpoint.Data.OriginPath, updateOptions.OriginPath);
            Assert.AreEqual(updatedEndpoint.Data.OriginHostHeader, updateOptions.OriginHostHeader);
        }

        public static void AssertValidAfdEndpoint(AfdEndpoint model, AfdEndpoint getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
        }

        public static void AssertAfdEndpointUpdate(AfdEndpoint updatedAfdEndpoint, AfdEndpointUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedAfdEndpoint.Data.Tags.Count, updateOptions.Tags.Count);
            foreach (var kv in updatedAfdEndpoint.Data.Tags)
            {
                Assert.True(updateOptions.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateOptions.Tags[kv.Key]);
            }
        }

        public static void AssertValidOrigin(CdnOrigin model, CdnOrigin getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.HttpPort, getResult.Data.HttpPort);
            Assert.AreEqual(model.Data.HttpsPort, getResult.Data.HttpsPort);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.Priority, getResult.Data.Priority);
            Assert.AreEqual(model.Data.Weight, getResult.Data.Weight);
            Assert.AreEqual(model.Data.Enabled, getResult.Data.Enabled);
            Assert.AreEqual(model.Data.PrivateLinkAlias, getResult.Data.PrivateLinkAlias);
            Assert.AreEqual(model.Data.PrivateLinkResourceId, getResult.Data.PrivateLinkResourceId);
            Assert.AreEqual(model.Data.PrivateLinkLocation, getResult.Data.PrivateLinkLocation);
            Assert.AreEqual(model.Data.PrivateLinkApprovalMessage, getResult.Data.PrivateLinkApprovalMessage);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.PrivateEndpointStatus, getResult.Data.PrivateEndpointStatus);
        }

        public static void AssertOriginUpdate(CdnOrigin updatedOrigin, OriginUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedOrigin.Data.HttpPort, updateOptions.HttpPort);
            Assert.AreEqual(updatedOrigin.Data.HttpsPort, updateOptions.HttpsPort);
            Assert.AreEqual(updatedOrigin.Data.Priority, updateOptions.Priority);
            Assert.AreEqual(updatedOrigin.Data.Weight, updateOptions.Weight);
        }

        public static void AssertValidAfdOrigin(AfdOrigin model, AfdOrigin getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if (model.Data.AzureOrigin != null || getResult.Data.AzureOrigin != null)
            {
                Assert.NotNull(model.Data.AzureOrigin);
                Assert.NotNull(getResult.Data.AzureOrigin);
                Assert.AreEqual(model.Data.AzureOrigin.Id, getResult.Data.AzureOrigin.Id);
            }
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.HttpPort, getResult.Data.HttpPort);
            Assert.AreEqual(model.Data.HttpsPort, getResult.Data.HttpsPort);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.Priority, getResult.Data.Priority);
            Assert.AreEqual(model.Data.Weight, getResult.Data.Weight);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            //Todo:SharedPrivateLinkResource
        }

        public static void AssertAfdOriginUpdate(AfdOrigin updatedAfdOrigin, AfdOriginUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedAfdOrigin.Data.Priority, updateOptions.Priority);
            Assert.AreEqual(updatedAfdOrigin.Data.Weight, updateOptions.Weight);
        }

        public static void AssertValidOriginGroup(CdnOriginGroup model, CdnOriginGroup getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if (model.Data.HealthProbeSettings != null || getResult.Data.HealthProbeSettings != null)
            {
                Assert.NotNull(model.Data.HealthProbeSettings);
                Assert.NotNull(getResult.Data.HealthProbeSettings);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeIntervalInSeconds, getResult.Data.HealthProbeSettings.ProbeIntervalInSeconds);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbePath, getResult.Data.HealthProbeSettings.ProbePath);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeProtocol, getResult.Data.HealthProbeSettings.ProbeProtocol);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeRequestType, getResult.Data.HealthProbeSettings.ProbeRequestType);
            }
            Assert.AreEqual(model.Data.Origins.Count, getResult.Data.Origins.Count);
            for (int i = 0; i < model.Data.Origins.Count; ++i)
            {
                Assert.AreEqual(model.Data.Origins[i].Id, getResult.Data.Origins[i].Id);
            }
            Assert.AreEqual(model.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes, getResult.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            //Todo: ResponseBasedOriginErrorDetectionSettings
        }

        public static void AssertOriginGroupUpdate(CdnOriginGroup updatedOriginGroup, OriginGroupUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbePath, updateOptions.HealthProbeSettings.ProbePath);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeRequestType, updateOptions.HealthProbeSettings.ProbeRequestType);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeProtocol, updateOptions.HealthProbeSettings.ProbeProtocol);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeIntervalInSeconds, updateOptions.HealthProbeSettings.ProbeIntervalInSeconds);
        }

        public static void AssertValidAfdOriginGroup(AfdOriginGroup model, AfdOriginGroup getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if (model.Data.LoadBalancingSettings != null || getResult.Data.LoadBalancingSettings != null)
            {
                Assert.NotNull(model.Data.LoadBalancingSettings);
                Assert.NotNull(getResult.Data.LoadBalancingSettings);
                Assert.AreEqual(model.Data.LoadBalancingSettings.SampleSize, getResult.Data.LoadBalancingSettings.SampleSize);
                Assert.AreEqual(model.Data.LoadBalancingSettings.SuccessfulSamplesRequired, getResult.Data.LoadBalancingSettings.SuccessfulSamplesRequired);
                Assert.AreEqual(model.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds, getResult.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds);
            }
            if (model.Data.HealthProbeSettings != null || getResult.Data.HealthProbeSettings != null)
            {
                Assert.NotNull(model.Data.HealthProbeSettings);
                Assert.NotNull(getResult.Data.HealthProbeSettings);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeIntervalInSeconds, getResult.Data.HealthProbeSettings.ProbeIntervalInSeconds);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbePath, getResult.Data.HealthProbeSettings.ProbePath);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeProtocol, getResult.Data.HealthProbeSettings.ProbeProtocol);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeRequestType, getResult.Data.HealthProbeSettings.ProbeRequestType);
            }
            Assert.AreEqual(model.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes, getResult.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes);
            Assert.AreEqual(model.Data.SessionAffinityState, getResult.Data.SessionAffinityState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            //Todo: ResponseBasedAfdOriginErrorDetectionSettings
        }

        public static void AssertAfdOriginGroupUpdate(AfdOriginGroup updatedAfdOriginGroup, AfdOriginGroupUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedAfdOriginGroup.Data.LoadBalancingSettings.SampleSize, updateOptions.LoadBalancingSettings.SampleSize);
            Assert.AreEqual(updatedAfdOriginGroup.Data.LoadBalancingSettings.SuccessfulSamplesRequired, updateOptions.LoadBalancingSettings.SuccessfulSamplesRequired);
            Assert.AreEqual(updatedAfdOriginGroup.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds, updateOptions.LoadBalancingSettings.AdditionalLatencyInMilliseconds);
        }

        public static void AssertValidCustomDomain(CdnCustomDomain model, CdnCustomDomain getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.CustomHttpsProvisioningState, getResult.Data.CustomHttpsProvisioningState);
            Assert.AreEqual(model.Data.CustomHttpsProvisioningSubstate, getResult.Data.CustomHttpsProvisioningSubstate);
            Assert.AreEqual(model.Data.ValidationData, getResult.Data.ValidationData);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
        }

        public static void AssertValidAfdCustomDomain(AfdCustomDomain model, AfdCustomDomain getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.TlsSettings.CertificateType, getResult.Data.TlsSettings.CertificateType);
            Assert.AreEqual(model.Data.TlsSettings.MinimumTlsVersion, getResult.Data.TlsSettings.MinimumTlsVersion);
            if (model.Data.TlsSettings.Secret != null || getResult.Data.TlsSettings.Secret != null)
            {
                Assert.NotNull(model.Data.TlsSettings.Secret);
                Assert.NotNull(getResult.Data.TlsSettings.Secret);
                Assert.AreEqual(model.Data.TlsSettings.Secret.Id, getResult.Data.TlsSettings.Secret.Id);
            }
            if (model.Data.AzureDnsZone != null || getResult.Data.AzureDnsZone != null)
            {
                Assert.NotNull(model.Data.AzureDnsZone);
                Assert.NotNull(getResult.Data.AzureDnsZone);
                Assert.AreEqual(model.Data.AzureDnsZone.Id, getResult.Data.AzureDnsZone.Id);
            }
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.DomainValidationState, getResult.Data.DomainValidationState);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            if (model.Data.ValidationProperties != null || getResult.Data.ValidationProperties != null)
            {
                Assert.NotNull(model.Data.ValidationProperties);
                Assert.NotNull(getResult.Data.ValidationProperties);
                Assert.AreEqual(model.Data.ValidationProperties.ValidationToken, getResult.Data.ValidationProperties.ValidationToken);
                Assert.AreEqual(model.Data.ValidationProperties.ExpirationDate, getResult.Data.ValidationProperties.ExpirationDate);
            }
        }

        public static void AssertAfdDomainUpdate(AfdCustomDomain updatedAfdDomain, AfdCustomDomainUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedAfdDomain.Data.TlsSettings.CertificateType, updateOptions.TlsSettings.CertificateType);
            Assert.AreEqual(updatedAfdDomain.Data.TlsSettings.MinimumTlsVersion, updateOptions.TlsSettings.MinimumTlsVersion);
        }

        public static void AssertValidAfdRuleSet(AfdRuleSet model, AfdRuleSet getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertValidAfdRule(AfdRule model, AfdRule getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Order, getResult.Data.Order);
            Assert.AreEqual(model.Data.Conditions.Count, getResult.Data.Conditions.Count);
            for (int i = 0; i < model.Data.Conditions.Count; ++i)
            {
                Assert.AreEqual(model.Data.Conditions[i].Name, getResult.Data.Conditions[i].Name);
            }
            Assert.AreEqual(model.Data.Actions.Count, getResult.Data.Actions.Count);
            for (int i = 0; i < model.Data.Actions.Count; ++i)
            {
                Assert.AreEqual(model.Data.Actions[i].Name, getResult.Data.Actions[i].Name);
            }
            Assert.AreEqual(model.Data.MatchProcessingBehavior, getResult.Data.MatchProcessingBehavior);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertAfdRuleUpdate(AfdRule updatedRule, RuleUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedRule.Data.Order, updateOptions.Order);
        }

        public static void AssertValidAfdRoute(AfdRoute model, AfdRoute getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.CustomDomains.Count, getResult.Data.CustomDomains.Count);
            for (int i = 0; i < model.Data.CustomDomains.Count; ++i)
            {
                Assert.AreEqual(model.Data.CustomDomains[i].Id, getResult.Data.CustomDomains[i].Id);
            }
            Assert.AreEqual(model.Data.OriginGroup.Id, getResult.Data.OriginGroup.Id);
            Assert.AreEqual(model.Data.OriginPath, getResult.Data.OriginPath);
            Assert.AreEqual(model.Data.RuleSets.Count, getResult.Data.RuleSets.Count);
            for (int i = 0; i < model.Data.RuleSets.Count; ++i)
            {
                Assert.AreEqual(model.Data.RuleSets[i].Id, getResult.Data.RuleSets[i].Id);
            }
            Assert.AreEqual(model.Data.SupportedProtocols.Count, getResult.Data.SupportedProtocols.Count);
            for (int i = 0; i < model.Data.SupportedProtocols.Count; ++i)
            {
                Assert.AreEqual(model.Data.SupportedProtocols[i], getResult.Data.SupportedProtocols[i]);
            }
            Assert.AreEqual(model.Data.PatternsToMatch.Count, getResult.Data.PatternsToMatch.Count);
            for (int i = 0; i < model.Data.PatternsToMatch.Count; ++i)
            {
                Assert.AreEqual(model.Data.PatternsToMatch[i], getResult.Data.PatternsToMatch[i]);
            }
            Assert.AreEqual(model.Data.EndpointName, getResult.Data.EndpointName);
            Assert.AreEqual(model.Data.ForwardingProtocol, getResult.Data.ForwardingProtocol);
            Assert.AreEqual(model.Data.LinkToDefaultDomain, getResult.Data.LinkToDefaultDomain);
            Assert.AreEqual(model.Data.HttpsRedirect, getResult.Data.HttpsRedirect);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertAfdRouteUpdate(AfdRoute updatedRoute, RouteUpdateOptions updateOptions)
        {
            Assert.AreEqual(updatedRoute.Data.EnabledState, updateOptions.EnabledState);
        }

        public static void AssertValidAfdSecurityPolicy(AfdSecurityPolicy model, AfdSecurityPolicy getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.Parameters.Type, getResult.Data.Parameters.Type);
        }

        public static void AssertAfdSecurityPolicyUpdate(AfdSecurityPolicy updatedSecurityPolicy, SecurityPolicyUpdateOptions updateOptions)
        {
            Assert.AreEqual(((SecurityPolicyWebApplicationFirewallParameters)updatedSecurityPolicy.Data.Parameters).Associations.Count, 1);
            Assert.AreEqual(((SecurityPolicyWebApplicationFirewallParameters)updatedSecurityPolicy.Data.Parameters).Associations[0].Domains.Count, 2);
        }

        public static void AssertValidPolicy(CdnWebApplicationFirewallPolicy model, CdnWebApplicationFirewallPolicy getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Etag, getResult.Data.Etag);
            Assert.AreEqual(model.Data.Sku.Name, getResult.Data.Sku.Name);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            //Todo: PolicySettings, RateLimitRules, CustomRules, ManagedRules, EndpointLinks
        }

        public static void AssertPolicyUpdate(CdnWebApplicationFirewallPolicy updatedPolicy, CdnWebApplicationFirewallPolicyPatchOptions updateOptions)
        {
            Assert.AreEqual(updatedPolicy.Data.Tags.Count, updateOptions.Tags.Count);
            foreach (var kv in updatedPolicy.Data.Tags)
            {
                Assert.True(updateOptions.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateOptions.Tags[kv.Key]);
            }
        }

        public static void AssertValidAfdSecret(AfdSecret model, AfdSecret getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.Parameters.Type, getResult.Data.Parameters.Type);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).SecretVersion, ((CustomerCertificateParameters)getResult.Data.Parameters).SecretVersion);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).CertificateAuthority, ((CustomerCertificateParameters)getResult.Data.Parameters).CertificateAuthority);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).UseLatestVersion, ((CustomerCertificateParameters)getResult.Data.Parameters).UseLatestVersion);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).SecretSource.Id.Name.ToString().ToLower(), ((CustomerCertificateParameters)getResult.Data.Parameters).SecretSource.Id.Name.ToString().ToLower());
            Assert.True(((CustomerCertificateParameters)model.Data.Parameters).SubjectAlternativeNames.SequenceEqual(((CustomerCertificateParameters)getResult.Data.Parameters).SubjectAlternativeNames));
        }
    }
}
