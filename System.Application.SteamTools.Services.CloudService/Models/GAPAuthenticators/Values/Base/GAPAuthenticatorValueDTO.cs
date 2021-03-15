﻿using MPIgnore = MessagePack.IgnoreMemberAttribute;
using N_JsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;
using S_JsonIgnore = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace System.Application.Models
{
    /// <summary>
    /// Class that implements base RFC 4226 an RFC 6238 authenticator
    /// </summary>
    public abstract partial class GAPAuthenticatorValueDTO : IGAPAuthenticatorValueDTO, IExplicitHasValue
    {
        /// <summary>
        /// HMAC hashing algorithm types
        /// </summary>
        public enum HMACTypes
        {
            SHA1 = 0,
            SHA256 = 1,
            SHA512 = 2
        }

        public GAPAuthenticatorValueDTO()
        {
        }

        [MPIgnore, N_JsonIgnore, S_JsonIgnore]
        public abstract GamePlatform Platform { get; }

        public long ServerTimeDiff { get; set; }

        public long LastServerTime { get; set; }

        public byte[]? SecretKey { get; set; }

        public int CodeDigits { get; set; }

        public HMACTypes HMACType { get; set; }

        public int Period { get; set; }

        protected virtual bool ExplicitHasValue()
        {
            return SecretKey != null && CodeDigits > 0 && HMACType.IsDefined() && Period > 0;
        }

        bool IExplicitHasValue.ExplicitHasValue() => ExplicitHasValue();
    }
}