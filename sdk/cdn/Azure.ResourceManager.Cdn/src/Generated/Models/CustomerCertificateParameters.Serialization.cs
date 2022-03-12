// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    internal partial class CustomerCertificateParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("secretSource");
            JsonSerializer.Serialize(writer, SecretSource); if (Optional.IsDefined(SecretVersion))
            {
                writer.WritePropertyName("secretVersion");
                writer.WriteStringValue(SecretVersion);
            }
            if (Optional.IsDefined(CertificateAuthority))
            {
                writer.WritePropertyName("certificateAuthority");
                writer.WriteStringValue(CertificateAuthority);
            }
            if (Optional.IsDefined(UseLatestVersion))
            {
                writer.WritePropertyName("useLatestVersion");
                writer.WriteBooleanValue(UseLatestVersion.Value);
            }
            if (Optional.IsCollectionDefined(SubjectAlternativeNames))
            {
                writer.WritePropertyName("subjectAlternativeNames");
                writer.WriteStartArray();
                foreach (var item in SubjectAlternativeNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type.ToString());
            writer.WriteEndObject();
        }

        internal static CustomerCertificateParameters DeserializeCustomerCertificateParameters(JsonElement element)
        {
            WritableSubResource secretSource = default;
            Optional<string> secretVersion = default;
            Optional<string> certificateAuthority = default;
            Optional<bool> useLatestVersion = default;
            Optional<IList<string>> subjectAlternativeNames = default;
            SecretType type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("secretSource"))
                {
                    secretSource = JsonSerializer.Deserialize<WritableSubResource>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("secretVersion"))
                {
                    secretVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("certificateAuthority"))
                {
                    certificateAuthority = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("useLatestVersion"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    useLatestVersion = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("subjectAlternativeNames"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    subjectAlternativeNames = array;
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new SecretType(property.Value.GetString());
                    continue;
                }
            }
            return new CustomerCertificateParameters(type, secretSource, secretVersion.Value, certificateAuthority.Value, Optional.ToNullable(useLatestVersion), Optional.ToList(subjectAlternativeNames));
        }
    }
}
